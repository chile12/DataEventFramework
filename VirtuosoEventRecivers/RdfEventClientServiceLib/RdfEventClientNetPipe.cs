using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using RdfEventClientServiceLib.VirtuosoEventServiceRef;
using System.Data;

namespace RdfEventClientServiceLib
{
    [ServiceContract]
    public interface IEventClientNetTcp
    {
        [OperationContract]
        string LogIn(string Username, string Password);

        [OperationContract]
        bool CreateNewAccount(string Username, string Password);

        [OperationContract]
        bool ResetPassword(string userName, string newPass, string adminPass);

        [OperationContract]
        bool SetUserAccountRights(bool right, string userName, string adminPass);

        [OperationContract]
        bool SetEventDefinitionRights(bool right, string userName, string adminPass);

        [OperationContract]
        VirtuosoDataSet.VirtuosoDataTableDataTable GetUsers(string namePart);

        [OperationContract]
        bool RegisterTrigger(int DBInstance, string Tablename, string Triggername, string procedureEndpoint);

        [OperationContract]
        bool SetNewRdfTrigger(string procedureEndpoint);
        
        [OperationContract]
        string[] GetSchemaTables(string schema, string procedureEndpoint);

        [OperationContract]
        VirtuosoDataSet.VirtuosoDataTableDataTable GetDatabases();

        [OperationContract]
        string[] GetTriggersOfTable(string tableName, string procedureEndpoint);

        [OperationContract]
        VirtuosoDataSet.VirtuosoDataTableDataTable GetEvents(int minutes);

        [OperationContract]
        string GetSupportedDBs();

        [OperationContract]
        string GetRemoteProcedureEndpoint(int dbInstance);

        [OperationContract]
        string RegisterNewRemoteDB(string dbType, string remoteEndpoint, string description, string sparqlEndpoint = "", string graphUris = "", string catalogSchema = "DB.DBA");

        [OperationContract]
        string[][] ExecuteTestSqlQuery(string querryString, string procedureEndpoint);
    }

    [DataContract]
    [KnownType(typeof(VirtuosoDataSet.VirtuosoDataTableDataTable))]
    public class EventClientNetTcp : IEventClientNetTcp
    {
        private static int session = 0;
        private static string currentUserName = "";
        private static bool userAccountRights = false;
        private static bool eventDefinitionRights = false;
        private string procedureEndpoint = "";

        private RdfEventClientServiceLib.VirtuosoEventServiceRef.VirtuosoEventServiceClient serviceClient;

        public EventClientNetTcp()
        {
            this.procedureEndpoint = ("http://localhost:8890/EventFrameworkProcedures");
            serviceClient = new RdfEventClientServiceLib.VirtuosoEventServiceRef.VirtuosoEventServiceClient();
        }

        public string LogIn(string Username, string Password)
        {
            string zw ="000";
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                zw = serviceClient.LogIn(Username, Password);    //retuns string like xy1234567890  
                if (zw.Substring(0, 1) == "1")
                    userAccountRights = true;                           //x = UserAccountRights (as 0,1) 
                if (zw.Substring(1, 1) == "1")
                    eventDefinitionRights = true;                       //y = EventDefinitionRights
                session = int.Parse(zw.Substring(2));                   //the rest is the sessionNr
                currentUserName = Username;
            }
            return zw;
        }

        public bool CreateNewAccount(string Username, string Password)
        {
            bool zw = false;
            if (session > 0 && userAccountRights)
            {
                zw = serviceClient.CreateNewAccount(Username, Password);
            }
            return zw;
        }

        public bool ResetPassword(string userName, string newPass, string adminPass)
        {
            bool zw = false;
            if (session > 0 && userAccountRights)
                zw = serviceClient.ResetUserpassword(newPass, userName, session, currentUserName, adminPass);
            return zw;
        }

        public bool SetUserAccountRights(bool right, string userName, string adminPass)
        {
            bool zw = false;
            if (session > 0 && userAccountRights)
                zw = serviceClient.SetUserAccRights(right, userName, session, currentUserName, adminPass);
            return zw;
        }

        public bool SetEventDefinitionRights(bool right, string userName, string adminPass)
        {
            bool zw = false;
            if (session > 0 && eventDefinitionRights)
                zw = serviceClient.SetEventDefRights(right, userName, session, currentUserName, adminPass);
            return zw;
        }

        public VirtuosoDataSet.VirtuosoDataTableDataTable GetUsers(string namePart)
        {
            return serviceClient.GetUsers(namePart);
        }


        public bool SetNewRdfTrigger(string procedureEndpoint)
        {
            return serviceClient.CreateTrigger();
        }

        public string[] GetSchemaTables(string schema, string procedureEndpoint)
        {
            return serviceClient.GetSchemaTables(schema, procedureEndpoint);
        }

        public VirtuosoDataSet.VirtuosoDataTableDataTable GetDatabases()
        {
            return serviceClient.GetDatabases();
        }
        public bool RegisterTrigger(int DBInstance, string Tablename, string Triggername, string procedureEndpoint)
        {
            return bool.Parse(serviceClient.RegisterTrigger(DBInstance, Tablename, Triggername, procedureEndpoint));
        }
        public string[] GetTriggersOfTable(string tableName, string procedureEndpoint)
        {
            return serviceClient.GetTriggersOfTable(tableName, procedureEndpoint);
        }
        public VirtuosoDataSet.VirtuosoDataTableDataTable GetEvents(int minutes)
        {
            return serviceClient.GetEvents(minutes);
        }
        public string GetSupportedDBs()
        {
            return serviceClient.GetSupportedDBs();
        }
        public string GetRemoteProcedureEndpoint(int dbInstance)
        {
            return serviceClient.GetRemoteProcedureEndpoint(dbInstance);
        }
        public string RegisterNewRemoteDB(string dbType, string remoteEndpoint, string description, string sparqlEndpoint = "", string graphUris = "", string catalogSchema = "DB.DBA")
        {
            return serviceClient.RegisterNewRemoteDB(dbType, description, remoteEndpoint, sparqlEndpoint, graphUris, catalogSchema);
        }
        public string[][] ExecuteTestSqlQuery(string querryString, string procedureEndpoint)
        {
            return serviceClient.ExecuteTestSqlQuery(querryString, procedureEndpoint);
        }
    }
}
