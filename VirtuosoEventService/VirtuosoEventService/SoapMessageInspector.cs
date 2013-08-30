using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace VirtuosoEventService
{
    public class SoapMessageInspector : IDispatchMessageInspector
    {

        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            // Make a copy of the SOAP packet for viewing.
            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            Message msgCopy = buffer.CreateMessage();

            request = buffer.CreateMessage();

            // Get the SOAP XML content.
            string strMessage = buffer.CreateMessage().ToString();

            // Get the SOAP XML body content.
            System.Xml.XmlDictionaryReader xrdr = msgCopy.GetReaderAtBodyContents();
            string bodyData = xrdr.ReadOuterXml();

            // Replace the body placeholder with the actual SOAP body.
            strMessage = strMessage.Replace("... stream ...", bodyData);

            // Display the SOAP XML.
            System.Diagnostics.Debug.WriteLine("Received:\n" + strMessage);

            return null;
        }

        public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            // Make a copy of the SOAP packet for viewing.
            MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
            reply = buffer.CreateMessage();

            // Display the SOAP XML.
            System.Diagnostics.Debug.WriteLine("Sending:\n" +
                buffer.CreateMessage().ToString());
        }
    }

    public class ConsoleOutputBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {

            SoapMessageInspector inspector = new SoapMessageInspector();
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}