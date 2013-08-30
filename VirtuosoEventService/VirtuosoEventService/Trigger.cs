using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtuosoEventService.VirtuosoCentral;
using VirtuosoEventService.VirtuosoDataSetTableAdapters;
using System.ServiceModel;

namespace VirtuosoEventService
{
    public enum TriggerState
    {
        Created,
        Pending,
        Failed
    }
    public enum TriggerOptions
    {
        INSERT,
        UPDATE,
        DELETE
    }
    public enum ConditionOperators
    {
        EQ, 	//gleich
        NE 	    //ungleich
        ,LT 	//kleiner
        ,LE 	//kleiner oder gleich
        , GT 	//größer
        , GE 	//größer oder gleich 
        , IN
        , NOTIN
        , CONTA
    }
    public enum QuadComponents
    {
        G,   //graph
        S,   //subject
        P,   //predicate
        O    //object
    }
    public class TriggerCondition
    {
        public string ConditionString { get; set; }
        public QuadComponents QuadComponent { get; set; }
        public ConditionOperators Operator { get; set; }
        public object CompareValue { get; set; }
        public TriggerOptions Option { get; set; }

        public TriggerCondition(QuadComponents QuadComponent, ConditionOperators Operator, object CompareValue, TriggerOptions Option)
        {
            this.QuadComponent = QuadComponent;
            this.Operator = Operator;
            this.Option = Option;
            this.CompareValue = CompareValue;

            string operat = "";
            switch (Operator)
            {
                case ConditionOperators.EQ:
                    operat = " = ";
                    break;
                case ConditionOperators.NE:
                    operat = " <> ";
                    break;
                case ConditionOperators.GE:
                    operat = " >= ";
                    break;
                case ConditionOperators.GT:
                    operat = " > ";
                    break;
                case ConditionOperators.LE:
                    operat = " <= ";
                    break;
                case ConditionOperators.LT:
                    operat = " < ";
                    break;
                case ConditionOperators.IN:
                    operat = " IN ";
                    break;
                case ConditionOperators.NOTIN:
                    operat = " NOT IN ";
                    break;
            }

            string value = "";
            string isString = "";


            if (CompareValue != null)
            {
                if (CompareValue.ToString().Count() > 10 && CompareValue.ToString().Substring(0, 6).ToUpper() == "SELECT")
                    value = "(" + CompareValue.ToString() + ")";
                else
                    value = CompareValue.ToString();

                if (CompareValue is string)
                    isString = "'";
            }
            else
                return;
            if (operat != "")
            {
                if(QuadComponent == QuadComponents.O)
                    ConditionString = "object" + operat + isString + value + isString + " ";
                else if (QuadComponent == QuadComponents.G)
                    ConditionString = "graph" + operat + isString + value + isString + " ";
                else if (QuadComponent == QuadComponents.S)
                    ConditionString = "subject" + operat + isString + value + isString + " ";
                else if (QuadComponent == QuadComponents.P)
                    ConditionString = "predicate" + operat + isString + value + isString + " ";
            }
            else if (Operator == ConditionOperators.CONTA)
            {
                if (QuadComponent == QuadComponents.O)
                    ConditionString = "strcontains(object, '" + value + "') ";
                else if(QuadComponent == QuadComponents.G)
                    ConditionString = "strcontains(graph, '" + value + "') ";
                else if (QuadComponent == QuadComponents.S)
                    ConditionString = "strcontains(subject, '" + value + "') ";
                else if (QuadComponent == QuadComponents.P)
                    ConditionString = "strcontains(predicate, '" + value + "') ";
            }
        }
    }

    public class RdfTrigger
    {
        public string TriggerSyntax { get; private set; }
        public string Name { get; private set; }
        public int DBInstance { get; private set; }
        public string InternalDBName { get; private set; }
        public string Table { get; private set; }
        public TriggerOptions Option { get; private set; }
        public List<TriggerCondition> Conditions { get; private set; }
        public string ConditionPattern { get; private set; }          //example: AND(C0,C2,OR(C3,!C4)) = (Conditions[0] AND Conditions[2] AND (Conditions[3] OR NOT(Conditions[4])))
        public TriggerState State { get; set; }
        private string endpointAddress = null;

        public RdfTrigger(int DBInstance, TriggerOptions Option, string ConditionPattern, List<TriggerCondition> Conditions, string Table = "RDF_QUAD")
        {
            this.Option = Option;
            this.DBInstance = DBInstance;
            this.Table = Table;
            this.ConditionPattern = ConditionPattern;
            this.Conditions = Conditions;
            this.State = TriggerState.Pending;

            VirtuosoTableAdapter tableAdapter = new VirtuosoTableAdapter();
            this.endpointAddress = tableAdapter.GetWdslAddress(DBInstance).ToString();
            this.InternalDBName = tableAdapter.GetInternalDBName(DBInstance).ToString();
            tableAdapter.Dispose();
            tableAdapter = null;
        }

        public bool CreateTrigger()
        {
            EventFrameworkProceduresDocLiteralPortTypeClient virtuosoSoapClient = new EventFrameworkProceduresDocLiteralPortTypeClient();
            VirtuosoTableAdapter tableAdapter = new VirtuosoTableAdapter();
            int nextTrigger = (int)tableAdapter.GetNextTriggerID();
            Name = Option.ToString() + "TRIGGER_" + DBInstance.ToString() + "_" + nextTrigger.ToString();

            if(Option == TriggerOptions.INSERT)
                TriggerSyntax = "create trigger " + Name + " AFTER " + Option + " on \n" + InternalDBName + "." + Table +
                    " REFERENCING new as N {declare graph,subject,predicate,object varchar; \ngraph:=CAST(ID_TO_IRI(N.G) AS VARCHAR);" +
                    "\nsubject:=CAST(ID_TO_IRI(N.S) AS VARCHAR); \npredicate:=CAST(ID_TO_IRI(N.P) AS VARCHAR);" +
                    "\n--check if object typeof(VARCHAR THEN nothing \n--or IRI_ID THEN resolve IRI_ID) else CAST AS VARCHAR" +
                    "\nif((internal_type_name(internal_type(N.O)) NOT IN('VARCHAR', 'IRI_ID'))){" +
                    "\nobject := CAST(N.O as VARCHAR);} \nELSE{if(CAST(IRI_TO_ID(N.O) AS VARCHAR) <> CAST(N.O AS VARCHAR))" +
                    "\n{ object := CAST(N.O AS VARCHAR); } \nelse { object := CAST(ID_TO_IRI(N.O) AS VARCHAR);};};" +
                    "\n--conditions \nif(" + calculatePattern(ConditionPattern) + ") \n{--save in event-table" +
                    "\nINSERT INTO " + InternalDBName + ".EventFrameworkEvents(\"Occurence\", \"Table\" ,\"Trigger\", \"Row\")" +
                    "\nVALUES(now(), '" + InternalDBName + "." + Table + "', '" + Name + "', vector(graph,subject,predicate,object));}}'";
            else if(Option == TriggerOptions.DELETE)
                TriggerSyntax = "create trigger " + Name + " AFTER " + Option + " on \n" + InternalDBName + "." + Table +
                    " REFERENCING old as O {declare graph,subject,predicate,object varchar; \ngraph:=CAST(ID_TO_IRI(O.G) AS VARCHAR);" +
                    "\nsubject:=CAST(ID_TO_IRI(O.S) AS VARCHAR); \npredicate:=CAST(ID_TO_IRI(O.P) AS VARCHAR);" +
                    "\n--check if object typeof(VARCHAR THEN nothing \n--or IRI_ID THEN resolve IRI_ID) else CAST AS VARCHAR" +
                    "\nif((internal_type_name(internal_type(O.O)) NOT IN('VARCHAR', 'IRI_ID'))){" +
                    "\nobject := CAST(O.O as VARCHAR);} \nELSE{if(CAST(IRI_TO_ID(O.O) AS VARCHAR) <> CAST(O.O AS VARCHAR))" +
                    "\n{ object := CAST(O.O AS VARCHAR); } \nelse { object := CAST(ID_TO_IRI(O.O) AS VARCHAR);};};" +
                    "\n--conditions \nif(" + calculatePattern(ConditionPattern) + ") \n{--save in event-table" +
                    "\nINSERT INTO " + InternalDBName + ".EventFrameworkEvents(\"Occurence\", \"Table\" ,\"Trigger\", \"Row\")" +
                    "\nVALUES(now(), '" + InternalDBName + "." + Table + "', '" + Name + "', vector(graph,subject,predicate,object));}}'";
            else if (Option == TriggerOptions.UPDATE)
                TriggerSyntax = "create trigger " + Name + " AFTER " + Option + " on \n" + InternalDBName + "." + Table +
                    " REFERENCING old as O, new as N {declare graph,subject,predicate,object varchar; \ngraph:=CAST(ID_TO_IRI(O.G) AS VARCHAR);" +
                    "\nsubject:=CAST(ID_TO_IRI(O.S) AS VARCHAR); \npredicate:=CAST(ID_TO_IRI(O.P) AS VARCHAR);" +
                    "\n--check if object typeof(VARCHAR THEN nothing \n--or IRI_ID THEN resolve IRI_ID) else CAST AS VARCHAR" +
                    "\nif((internal_type_name(internal_type(O.O)) NOT IN('VARCHAR', 'IRI_ID'))){" +
                    "\nobject := CAST(O.O as VARCHAR);} \nELSE{if(CAST(IRI_TO_ID(O.O) AS VARCHAR) <> CAST(O.O AS VARCHAR))" +
                    "\n{ object := CAST(O.O AS VARCHAR); } \nelse { object := CAST(ID_TO_IRI(O.O) AS VARCHAR);};};" +
                    "\n--conditions \nif(" + calculatePattern(ConditionPattern) + ") \n{--save in event-table" +
                    "\nINSERT INTO " + InternalDBName + ".EventFrameworkEvents(\"Occurence\", \"Table\" ,\"Trigger\", \"Row\")" +
                    "\nVALUES(now(), '" + InternalDBName + "." + Table + "', '" + Name + "', vector(graph,subject,predicate,object));}}'";

            bool zw =false;
            try
            {
                //virtuosoSoapClient.Endpoint.Address = new EndpointAddress(endpointAddress);
                zw = bool.Parse(virtuosoSoapClient.RDF_EVENT_FRAMEWORK_SET_NEW_TRIGGER(TriggerSyntax, Table, InternalDBName, Name));
            }
            catch (EndpointNotFoundException)
            {
                State = TriggerState.Failed;
                return false;
            }

            if (zw)
            {
                tableAdapter.InsertNewTrigger(Option.ToString(), Name, "", DBInstance, InternalDBName, Table, TriggerSyntax);
                State = TriggerState.Created;
            }
            else
                State = TriggerState.Failed;

            tableAdapter.Dispose();
            tableAdapter = null;
            virtuosoSoapClient.Close();
            virtuosoSoapClient = null;

            return zw;
        }

        private string calculatePattern(string pattern)
        {
            for (int i = 0; i < pattern.Count(); i++)
            {
                if (pattern[i] == 'C')
                {
                    int cond = int.Parse(pattern[i + 1].ToString());
                    pattern = pattern.Remove(i, 2);
                    pattern = pattern.Insert(i, Conditions[cond].ConditionString);
                    i = i + Conditions[cond].ConditionString.Count();
                }
            }
            return pattern;
        }

        //private string normalizePattern(string inputPattern)
        //{
        //    string pattern = inputPattern;
        //    pattern = pattern.Replace(" ", "");
        //    pattern = pattern.Replace(";", ",");
        //    pattern = pattern.Replace("NOT", "!");
        //    if (pattern.Count() < 1 || Conditions.Count < 1)
        //        return "true";

        //    string op = " AND ";
        //    if(pattern[0] == 'O')
        //        op = " OR ";

        //    for (int i = 0; i < pattern.Count(); i++)
        //    {
        //        if (pattern[i] == ',' && i < pattern.Count() - 1)
        //        {
        //            pattern = pattern.Remove(i, 1);
        //            pattern = pattern.Insert(i, op);
        //            i = i + op.Count();
        //        }
        //        if (pattern[i] == '!')
        //        {
        //            pattern = pattern.Remove(i, 1);
        //            pattern = pattern.Insert(i, " NOT ");
        //        }
        //        if (pattern[i] == 'A' || pattern[i] == 'O')
        //        {
        //            int parenthesisCount = 0;
        //            int prev = 0;
        //            bool first = true;
        //            int patternBegin = 0;
        //            while (parenthesisCount != 0 || first)
        //            {
        //                if (pattern.Count() - 1 == i && (parenthesisCount > 2 || parenthesisCount == 2 && pattern[i] != ')'))
        //                    return "true";
        //                else
        //                {
        //                    if (pattern[i] == '(')
        //                    {
        //                        prev = parenthesisCount;
        //                        parenthesisCount++;
        //                        if (first)
        //                        {
        //                            patternBegin = i + 1;
        //                            first = false;
        //                        }
        //                    }
        //                    if (pattern[i] == ')')
        //                    {
        //                        prev = parenthesisCount;
        //                        parenthesisCount--;
        //                    }
        //                }
        //                i++;
        //            }
        //            string zw = normalizePattern(pattern.Substring(patternBegin, i - patternBegin -1));
        //            pattern = pattern.Remove(patternBegin, i - patternBegin-1);
        //            pattern = pattern.Insert(patternBegin, zw);
        //        }
        //    }
        //    return pattern;
        //}
        
    }
}