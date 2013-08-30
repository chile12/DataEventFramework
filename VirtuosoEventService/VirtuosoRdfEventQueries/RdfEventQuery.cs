using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VDS.RDF.Query;
using VDS.RDF;
using System.Xml;

namespace VirtuosoRdfEventQueries
{
    class RdfEventQuery
    {
        private Dictionary<string, string> rootDict = new Dictionary<string, string>();

        //TODO ->StaticHelper!!!!!!!!!!!!!!!!!!
        private string groupEv = "<http://rdf.event.framework/group.event.def/>";
        private string dictTag = "<http://rdf.event.framework/directory.tag.def/>";
        private string instances = "http://rdf.event.framework/instances";
        public SparqlRemoteEndpoint endpoint;

        private string languageTag;

        private string queryPrefixa; 
        private string queryPrefixb;
        private string querySelect;
        private string queryFrom;
        private string queryWhere;
        private string queryOrder;
        private string queryInsert;
        private string queryLanguageFilter;

        public RdfEventQuery(SparqlRemoteEndpoint endpoint)
        {
            this.endpoint = endpoint;
            this.languageTag = "en";
            this.rootDict = StaticHelper.GetRootDirectories();

            queryPrefixa = "prefix rdf:    <http://www.w3.org/1999/02/22-rdf-syntax-ns#> " +
                "prefix rdfs:   <http://www.w3.org/2000/01/rdf-schema#> " +
                "prefix xsd:    <http://www.w3.org/2001/XMLSchema#> " +
                "prefix ctag:   <http://commontag.org/ns#>";
            queryPrefixb = "prefix group: = " + groupEv + " prefix direc: " + dictTag + " prefix : <" + instances + "/>";
            
            querySelect = "";
            queryFrom = "FROM <" + instances + "> ";
            queryLanguageFilter = "FILTER langMatches( lang(?name), \"" + languageTag + "\" )";
        }

        public SparqlResultSet NewGroupPerson(GroupPerson ident, string founder, string groupName, int maxMembers = 0, string notes = "", string personID = "")
        {
            queryInsert = "INSERT INTO <" + instances + "> {:" + groupName + " a group:" + ident.ToString() + 
                "; group:.name \"" + groupName + "\"; group:constitutedBy " + founder + "; group:constituted " + 
                XmlConvert.ToString(DateTime.Now, XmlDateTimeSerializationMode.Utc);
            if (!string.IsNullOrEmpty(notes))
                queryInsert += "; group:notes " + notes;
            if (!string.IsNullOrEmpty(personID))
                queryInsert += ";group:maxMembers 1; group:personID " + personID + ".}";
            else
                queryInsert += ";group:maxMembers " + maxMembers + ".}";
            
            SparqlResultSet set = endpoint.QueryWithResultSet(queryPrefixa + queryPrefixb + querySelect + queryFrom + queryWhere + queryOrder);

            return set;
        }

        public SparqlResultSet NewDirectoryFile(DirecFile ident, string creater, string nameOrRelativePath, string rootkey, string inDirectory = ":Root", string comments = "", string version = "0", string prevVersion = "", string extention = "", int size = 0)
        {
            //TODO!
            string newDirecNr = "3467347";
            string root ="";
            rootDict.TryGetValue(rootkey, out root);

            string name;
            if (nameOrRelativePath.Contains("/"))
                name = nameOrRelativePath.Substring(nameOrRelativePath.LastIndexOf("/") + 1);
            else
                name = nameOrRelativePath;
            //
            queryInsert = "INSERT INTO <" + instances + "> {:" + newDirecNr + " a direc:" + ident.ToString() +
                "; direc:root \"" + rootDict + "\"; direc:relativePath \"" + nameOrRelativePath + "\"; direc:createdBy :" + creater +
                "; direc:name \"" + name + "\"; direc:created " + XmlConvert.ToString(DateTime.Now, XmlDateTimeSerializationMode.Utc) + 
                "; direc:comments \"" + comments + "\"; direc:inDirectory :" + inDirectory;

            if (ident == DirecFile.File)
            {
                if (inDirectory == ":Root")
                    return null;

                queryInsert += "; direc:version \"" + version + "\"; direc:prevVersion \"" + prevVersion +
                "\"; direc:extention \"" + extention + "\"; direc:size " + size + ".}";
            }
            else
                queryInsert += ".}";

            SparqlResultSet set = endpoint.QueryWithResultSet(queryPrefixa + queryPrefixb + querySelect + queryFrom + queryWhere + queryOrder);

            return set;
        }
    }
}
