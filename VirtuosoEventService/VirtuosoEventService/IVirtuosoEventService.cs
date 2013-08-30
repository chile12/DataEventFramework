using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net.Security;
using System.Data;

namespace VirtuosoEventService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVirtuosoEventService" in both code and config file together.
    [ServiceContract]
    public interface IVirtuosoEventService
    {
        [OperationContract]
        VirtuosoDataSet.VirtuosoDataTableDataTable GetEvents(int minutes);

        [OperationContract]
        VirtuosoDataSet.VirtuosoDataTableDataTable Event(int EventID);

        [OperationContract]
        //Virtuoso SOAPClient sends in Rpc!
        [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
        void InsertTriple(string graph, string subj, string pred, string obj);

        //encrption not yet implemented
        //[OperationContract(ProtectionLevel = ProtectionLevel.Sign)]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName">...</param>
        /// <param name="password">...</param>
        /// <returns>a random session number - used to identify current session</returns>
        [OperationContract]
        string LogIn(string userName, string password);

        [OperationContract]
        bool CreateNewAccount(string userName, string password);

        [OperationContract]
        VirtuosoDataSet.VirtuosoDataTableDataTable GetUsers(string searchString);

        [OperationContract]
        VirtuosoDataSet.VirtuosoDataTableDataTable CollectEvents(string UserName, string Password, int SessionNr);

        [OperationContract]
        bool ResetUserpassword(string newPass, string userName, int sessionNr, string adminName, string adminPass);

        [OperationContract]
        bool SetUserAccRights(bool right, string userName, int sessionNr, string adminName, string adminPass);

        [OperationContract]
        bool SetEventDefRights(bool right, string userName, int sessionNr, string adminName, string adminPass);
        
        [OperationContract]
        bool CreateTrigger();

        [OperationContract]
        string InsertTrigger(int DBInstance, string Tablename, string Triggername, string triggerSyntax, string procedureEndpoint = "http://localhost:8890/EventFrameworkProcedures");

        [OperationContract]
        string RegisterTrigger(int DBInstance, string Tablename, string Triggername, string procedureEndpoint = "http://localhost:8890/EventFrameworkProcedures");
        
        [OperationContract]
        string[] GetSchemaTables(string DBSchema, string procedureEndpoint = "http://localhost:8890/EventFrameworkProcedures");

        [OperationContract]
        string[] GetTriggersOfTable(string tableName, string procedureEndpoint = "http://localhost:8890/EventFrameworkProcedures");

        [OperationContract]
        VirtuosoDataSet.VirtuosoDataTableDataTable GetDatabases();

        //methodes which are called from Virtuoso use a different OperationFormatStyle and OperationFormatUse
        [OperationContract]
        [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
        void ReceiveNewEvent(int EventID, int TriggerID);

        [OperationContract]
        string GetSupportedDBs();

        [OperationContract]
        string GetRemoteProcedureEndpoint(int dbInstance);

        [OperationContract]
        string RegisterNewRemoteDB(string dbType, string description, string remoteEndpoint = "http://localhost:8890/EventFrameworkProcedures", string sparqlEndpoint = "", string graphUris = "", string catalogSchema = "DB.DBA");

        [OperationContract]
        string[][] ExecuteTestSqlQuery(string querryString, string procedureEndpoint = "http://localhost:8890/EventFrameworkProcedures");
    }
}
