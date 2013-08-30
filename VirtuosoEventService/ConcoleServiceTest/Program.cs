using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using VirtuosoEventService;

namespace ConcoleServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Uri baseAddress = new Uri("http://localhost:8000/VirtuosoEventService");
            ServiceHost selfHost = new ServiceHost(typeof(DistributedVirtuosoEventService), baseAddress);

            try
            {
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                //NetTcpBinding netBind = new NetTcpBinding(SecurityMode.Message);
                BasicHttpBinding wsBind = new BasicHttpBinding(BasicHttpSecurityMode.None);    //with encryption: SecurityMode.Message
                wsBind.MessageEncoding = WSMessageEncoding.Text;
            //Encoding enc = new UTF8Encoding(false);
            //wsBind.TextEncoding = enc; 
                //netBind.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
                //wsBind.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;

                selfHost.AddServiceEndpoint(
                typeof(IVirtuosoEventService),
                wsBind,
                "VirtuosoEventEndpoint");

                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5 of the hosting procedure: Start (and then stop) the service.

                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();

            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception occurred: {0}", ex.Message);
                selfHost.Abort();
            }
        }
    }
}
