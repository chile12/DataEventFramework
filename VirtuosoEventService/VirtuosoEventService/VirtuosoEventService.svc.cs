using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net.Security;
using System.Data;
using VirtuosoEventService.VirtuosoDataSetTableAdapters;
using VirtuosoEventService.VirtuosoCentral;
using System.Configuration;
using System.Web.Configuration;

namespace VirtuosoEventService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DistributedVirtuosoEventService" in code, svc and config file together.
    /// <summary>
    /// Implements alle functions of IVirtuosoEventService. An instance of this class is needed for every Virtuopso-instance in a distributed environment
    /// </summary>
    [KnownType(typeof(VirtuosoEventService.VirtuosoDataSet.VirtuosoDataTableDataTable))] 
    public class DistributedVirtuosoEventService : IVirtuosoEventService
    {
        private VirtuosoEventService.VirtuosoDataSet.VirtuosoDataTableDataTable table = new VirtuosoEventService.VirtuosoDataSet.VirtuosoDataTableDataTable();
        private VirtuosoTableAdapter tableAdapter = new VirtuosoTableAdapter();
        private EventFrameworkProceduresDocLiteralPortTypeClient testClient = new EventFrameworkProceduresDocLiteralPortTypeClient();
        private string procdureEndpointName = ""; 
        private static Dictionary<string, List<string>> graphDict = new Dictionary<string, List<string>>();

        /// <summary>
        /// constructor: cennects to specific Virtuoso-DB 
        /// </summary>
        /// <param name="Connections">a list of connection-strings for all used Virtuoso instances including their passwords</param>
        public DistributedVirtuosoEventService()
        {
            procdureEndpointName = testClient.Endpoint.Binding.Namespace;
            testClient.Close();
        }
        
        
        public string LogIn(string userName, string password)
        {
            int sessionNr = 0;
            //CheckLogIn returns a string like '00' or '10', '01','11'
            //'1x' - user has admin-rights for user-accounts
            //'x1' - user has event-definition-rights'
            string checkedIn = tableAdapter.CheckLogIn(userName, password).ToString();

            if (checkedIn == null)
                return "000";

            tableAdapter.UpdateLogIn(userName, password);
            sessionNr = (int)tableAdapter.GetSessionNr(userName, password);
            table.Clear();

            return checkedIn + sessionNr.ToString();
        }

        public bool CreateNewAccount(string userName, string password)
        {
            if (!bool.Parse(tableAdapter.CheckIfUserNameExists(userName).ToString()))
            {      //not!
                tableAdapter.CreateNewAccount(userName, password);
                return true;
            }
            else
            {
                return false;
            }
        }


        public VirtuosoDataSet.VirtuosoDataTableDataTable GetUsers(string searchString)
        {
            table.Clear();
            table = tableAdapter.GetUsers(searchString);
            return table;
        }


        public VirtuosoDataSet.VirtuosoDataTableDataTable CollectEvents(string UserName, string Password, int SessionNr)
        {
            table.Clear();
            object zw = tableAdapter.CheckSession(UserName, Password, SessionNr);
            if(bool.Parse(zw.ToString()))
                table = tableAdapter.GetUserEvents(UserName);
            return table;
        }


        public bool ResetUserpassword(string newPass, string userName, int sessionNr, string adminName, string adminPass)
        {
            if (bool.Parse(tableAdapter.CheckSession(adminName, adminPass, sessionNr).ToString()))
            {
                tableAdapter.ResetPassword(newPass, userName);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool SetUserAccRights(bool right, string userName, int sessionNr, string adminName, string adminPass)
        {
            int rightInt = 0;
            if (right)
                rightInt = 1;

            if (bool.Parse(tableAdapter.CheckSession(adminName, adminPass, sessionNr).ToString()))
            {
                tableAdapter.SetUserAccRight(rightInt, userName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetEventDefRights(bool right, string userName, int sessionNr, string adminName, string adminPass)
        {
            int rightInt = 0;
            if (right)
                rightInt = 1;

            if (bool.Parse(tableAdapter.CheckSession(adminName, adminPass, sessionNr).ToString()))
            {
                tableAdapter.SetEventDefRight(rightInt, userName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateTrigger()
        {
            List<TriggerCondition> conditions = new List<TriggerCondition>();
            conditions.Add(new TriggerCondition(QuadComponents.G, ConditionOperators.EQ, "http://rdf.event.framework/instances", TriggerOptions.INSERT));
            conditions.Add(new TriggerCondition(QuadComponents.P, ConditionOperators.CONTA, "inDirectory", TriggerOptions.INSERT));
            conditions.Add(new TriggerCondition(QuadComponents.O, ConditionOperators.CONTA, "Root", TriggerOptions.INSERT));
            conditions.Add(new TriggerCondition(QuadComponents.P, ConditionOperators.CONTA, "version", TriggerOptions.INSERT));
            conditions.Add(new TriggerCondition(QuadComponents.O, ConditionOperators.CONTA, "3", TriggerOptions.INSERT));

            RdfTrigger trig = new RdfTrigger(1, TriggerOptions.INSERT, "(C0 AND ((C1 AND C2) OR (C3 AND C4)))", conditions);

            //TODO 
            if (trig.CreateTrigger())
            {
                trig.State = TriggerState.Created;
                return true;
            }
            else
            {
                trig.State = TriggerState.Failed;
                return false;
            }

        }

        public VirtuosoDataSet.VirtuosoDataTableDataTable GetEvents(int minutes)
        {
            VirtuosoDataSet.VirtuosoDataTableDataTable zw = tableAdapter.GetAllEventsOfLast(minutes);
            return zw;
        }

        public VirtuosoDataSet.VirtuosoDataTableDataTable Event(int EventID)
        {
            //TODO
            return new VirtuosoDataSet.VirtuosoDataTableDataTable();
        }

        public void InsertTriple(string graph, string subj, string pred, string obj)
        {
            //delete!
        }

        public string RegisterTrigger(int DBInstance, string Tablename, string Triggername, string procedureEndpoint = "http://localhost:8890/EventFrameworkProcedures")
        {
            if (Triggername.Contains('.'))
            {
                Triggername = Triggername.Substring(Triggername.IndexOf('.') + 1);
            }
            BasicHttpBinding bind = new BasicHttpBinding();
            bind.MaxBufferPoolSize = 2147483647;
            bind.MaxBufferSize = 2147483647;
            bind.MaxReceivedMessageSize = 2147483647;

            EndpointAddress addr = new EndpointAddress(procedureEndpoint);

            EventFrameworkProceduresDocLiteralPortTypeClient virtuosoSoapClient = new EventFrameworkProceduresDocLiteralPortTypeClient(bind, addr);
            if (bool.Parse(tableAdapter.CheckIfTriggernameNotExists(Triggername, Triggername).ToString()))
            {
                string syntax = virtuosoSoapClient.RDF_EVENT_FRAMEWORK_GET_TRIGGER_SYNTAX(Tablename, Triggername);
                
                virtuosoSoapClient.Close();
                virtuosoSoapClient = null;

                TriggerOptions option;
                if (syntax.Substring(syntax.ToUpper().IndexOf(" ON ") - 10, syntax.ToUpper().IndexOf(" ON ")).Contains("INSERT"))
                    option = TriggerOptions.INSERT;
                else if (syntax.Substring(syntax.ToUpper().IndexOf(" ON ") - 10, syntax.ToUpper().IndexOf(" ON ")).Contains("UPDATE"))
                    option = TriggerOptions.UPDATE;
                else
                    option = TriggerOptions.DELETE;

                int nextTrigger = (int)tableAdapter.GetNextTriggerID();
                string internalTriggerName = option.ToString() + "TRIGGER_" + DBInstance.ToString() + "_" + nextTrigger.ToString();
                string InternalDBName = tableAdapter.GetInternalDBName(DBInstance).ToString();

                tableAdapter.InsertNewTrigger(option.ToString(), internalTriggerName, Triggername, DBInstance, InternalDBName, Tablename, syntax);


                return "true";
            }
            else
                return "false";
        }

        public string SetNewTrigger(int DBInstance, string Tablename, string Triggername, string triggerSyntax, string procedureEndpoint = "http://localhost:8890/EventFrameworkProcedures")
        {
            if (Triggername.Contains('.'))
            {
                Triggername = Triggername.Substring(Triggername.IndexOf('.') + 1);
            }
            BasicHttpBinding bind = new BasicHttpBinding();
            bind.MaxBufferPoolSize = 2147483647;
            bind.MaxBufferSize = 2147483647;
            bind.MaxReceivedMessageSize = 2147483647;

            EndpointAddress addr = new EndpointAddress(procedureEndpoint);

            EventFrameworkProceduresDocLiteralPortTypeClient virtuosoSoapClient = new EventFrameworkProceduresDocLiteralPortTypeClient(bind, addr);
            if (bool.Parse(tableAdapter.CheckIfTriggernameNotExists(Triggername, Triggername).ToString()))
            {
                string syntax = virtuosoSoapClient.RDF_EVENT_FRAMEWORK_GET_TRIGGER_SYNTAX(Tablename, Triggername);

                virtuosoSoapClient.Close();
                virtuosoSoapClient = null;

                TriggerOptions option;
                if (syntax.Substring(syntax.ToUpper().IndexOf(" ON ") - 10, syntax.ToUpper().IndexOf(" ON ")).Contains("INSERT"))
                    option = TriggerOptions.INSERT;
                else if (syntax.Substring(syntax.ToUpper().IndexOf(" ON ") - 10, syntax.ToUpper().IndexOf(" ON ")).Contains("UPDATE"))
                    option = TriggerOptions.UPDATE;
                else
                    option = TriggerOptions.DELETE;

                int nextTrigger = (int)tableAdapter.GetNextTriggerID();
                string internalTriggerName = option.ToString() + "TRIGGER_" + DBInstance.ToString() + "_" + nextTrigger.ToString();
                string InternalDBName = tableAdapter.GetInternalDBName(DBInstance).ToString();

                tableAdapter.InsertNewTrigger(option.ToString(), internalTriggerName, Triggername, DBInstance, InternalDBName, Tablename, syntax);


                return "true";
            }
            else
                return "false";
        }

        public string[] GetSchemaTables(string DBSchema, string procedureEndpoint = "http://localhost:8890/EventFrameworkProcedures")
        {
            BasicHttpBinding bind = new BasicHttpBinding();
            bind.MaxBufferPoolSize = 2147483647;
            bind.MaxBufferSize = 2147483647;
            bind.MaxReceivedMessageSize = 2147483647;

            EndpointAddress addr = new EndpointAddress(procedureEndpoint);

            EventFrameworkProceduresDocLiteralPortTypeClient virtuosoSoapClient = new EventFrameworkProceduresDocLiteralPortTypeClient(bind, addr);
            string[] zw = null;
            zw = virtuosoSoapClient.RDF_EVENT_FRAMEWORK_GET_SCHEMA_TABLES(DBSchema);
            virtuosoSoapClient.Close();
            virtuosoSoapClient = null;
            return zw;
        }


        public VirtuosoDataSet.VirtuosoDataTableDataTable GetDatabases()
        {
            return tableAdapter.GetDatabases();
        }

        public string[] GetTriggersOfTable(string tableName, string procedureEndpoint = "http://localhost:8890/EventFrameworkProcedures")
        {
            BasicHttpBinding bind = new BasicHttpBinding();
            bind.MaxBufferPoolSize = 2147483647;
            bind.MaxBufferSize = 2147483647;
            bind.MaxReceivedMessageSize = 2147483647;

            EndpointAddress addr = new EndpointAddress(procedureEndpoint);

            EventFrameworkProceduresDocLiteralPortTypeClient virtuosoSoapClient = new EventFrameworkProceduresDocLiteralPortTypeClient(bind, addr);
            string[] zw = null;
            zw = virtuosoSoapClient.RDF_EVENT_FRAMEWORK_GET_TRIGGERS_OF_TABLE(tableName);
            virtuosoSoapClient.Close();
            virtuosoSoapClient = null;
            return zw;
        }

        public void ReceiveNewEvent(int EventID, int TriggerID)
        {
            //TODO atomic event handeling
            int gg = EventID;
            int zz = TriggerID;
        }

        public string GetSupportedDBs()
        {
            return tableAdapter.GetConstSupportedDbs().ToString();
        }

        public string GetRemoteProcedureEndpoint(int dbInstance)
        {
            return tableAdapter.GetRemoteProcedureEndpoint(dbInstance).ToString();
        }


        public string RegisterNewRemoteDB(string dbType, string description, string remoteEndpoint = "http://localhost:8890/EventFrameworkProcedures", string sparqlEndpoint = "", string graphUris = "", string catalogSchema = "DB.DBA")
        {
            BasicHttpBinding bind = new BasicHttpBinding();
            bind.MaxBufferPoolSize = 2147483647;
            bind.MaxBufferSize = 2147483647;
            bind.MaxReceivedMessageSize = 2147483647;

            EndpointAddress addr = new EndpointAddress(remoteEndpoint);

            EventFrameworkProceduresDocLiteralPortTypeClient virtuosoSoapClient = new EventFrameworkProceduresDocLiteralPortTypeClient(bind, addr);
            string zw = virtuosoSoapClient.RDF_EVENT_FRAMEWORK_REGISTER_REMOTE_DB(catalogSchema, dbType, description, remoteEndpoint, sparqlEndpoint, graphUris);
            virtuosoSoapClient.Close();
            virtuosoSoapClient = null;
            return zw;
        }


        public string[][] ExecuteTestSqlQuery(string querryString, string procedureEndpoint = "http://localhost:8890/EventFrameworkProcedures")
        {
            BasicHttpBinding bind = new BasicHttpBinding();
            bind.MaxBufferPoolSize = 2147483647;
            bind.MaxBufferSize = 2147483647;
            bind.MaxReceivedMessageSize = 2147483647;

            EndpointAddress addr = new EndpointAddress(procedureEndpoint);

            EventFrameworkProceduresDocLiteralPortTypeClient virtuosoSoapClient = new EventFrameworkProceduresDocLiteralPortTypeClient(bind, addr);
            string[][] zw = null;
            zw = virtuosoSoapClient.EVENT_FRAMEWORK_TEST_SQL_CONDITION(querryString);
            virtuosoSoapClient.Close();
            virtuosoSoapClient = null;
            return zw;
        }


        public string InsertTrigger(int DBInstance, string Tablename, string Triggername, string triggerSyntax, string procedureEndpoint = "http://localhost:8890/EventFrameworkProcedures")
        {
            BasicHttpBinding bind = new BasicHttpBinding();
            bind.MaxBufferPoolSize = 2147483647;
            bind.MaxBufferSize = 2147483647;
            bind.MaxReceivedMessageSize = 2147483647;

            EndpointAddress addr = new EndpointAddress(procedureEndpoint);

            EventFrameworkProceduresDocLiteralPortTypeClient virtuosoSoapClient = new EventFrameworkProceduresDocLiteralPortTypeClient(bind, addr);
            return "";
        }
    }
}
