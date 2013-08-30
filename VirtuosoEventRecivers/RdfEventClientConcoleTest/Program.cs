using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using RdfEventClientServiceLib;
using System.ServiceModel.Description;

namespace RdfEventClientConcoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("net.tcp://localhost:1234");

                ServiceHost host = new ServiceHost(typeof(EventClientNetTcp), baseAddress);

                try
                {
                    //NetTcpBinding netBind = new NetTcpBinding(SecurityMode.Message);
                    //Encoding enc = new UTF8Encoding(false);
                    //wsBind.TextEncoding = enc; 
                    //netBind.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
                    //wsBind.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;

                    host.AddServiceEndpoint(typeof(IEventClientNetTcp),
                    new NetTcpBinding(),
                    "EventServiceProxy");

                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetUrl = new Uri("http://localhost:1235/EventServiceProxy");
                    smb.HttpGetEnabled = true;
                    host.Description.Behaviors.Add(smb);
                    
                    // Step 5 of the hosting procedure: Start (and then stop) the service.

                    host.Open();
                    Console.WriteLine("The service is ready.");
                    Console.WriteLine("Press <ENTER> to terminate service.");
                    Console.WriteLine();
                    Console.ReadLine();

                    // Close the ServiceHostBase to shutdown the service.
                    host.Close();

                }
                catch (CommunicationException ce)
                {
                    Console.WriteLine("An exception occurred: {0}", ce.Message);
                    host.Abort();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An exception occurred: {0}", ex.Message);
                    host.Abort();
                }
            
        }
    }
}
