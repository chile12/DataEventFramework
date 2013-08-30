--all tables & procedures needed for the central DB

--tables
create table EventFrameworkDatabases
(
  "DBInstance" INTEGER IDENTITY,
  "SchemaName" VARCHAR NOT NULL,
  "SQLDialect" VARCHAR(10) NOT NULL,
  "ControlID" INTEGER NOT NULL,
  "Description" VARCHAR,
  "ProcedureEndpoint" VARCHAR NOT NULL,
  "SparqlEndpointAddress" VARCHAR,
  "RdfGraphs" ANY,
  PRIMARY KEY ("DBInstance")
);

create table EventFrameworkEvents
(
  "EventID" INTEGER IDENTITY,
  "DBInstance" INTEGER NOT NULL,
  "TableName" VARCHAR NOT NULL,
  "TriggerID" INTEGER NOT NULL,
  "Occurence" DATETIME NOT NULL,
  "Row" ANY,
  PRIMARY KEY ("EventID"),
  FOREIGN KEY ("DBInstance") REFERENCES EventFrameworkDatabases,
  FOREIGN KEY ("TriggerID") REFERENCES EventFrameworkTriggers
);

create table EventFrameworkTriggers
(
  "TriggerID" INTEGER IDENTITY,
  "TriggerType" VARCHAR(6) NOT NULL,
  "TriggerName" VARCHAR NOT NULL,
  "AlternativeName" VARCHAR,
  "DBInstance" INTEGER NOT NULL,
  "DatabaseSchema" VARCHAR NOT NULL,
  "OnTable" VARCHAR NOT NULL,
  "Created" DATETIME NOT NULL,
  "Statement" LONG VARCHAR NOT NULL,
  PRIMARY KEY ("TriggerID"),
  FOREIGN KEY ("DBInstance") REFERENCES EventFrameworkDatabases
);

create table EventFrameworkUsers
(
  "UserID" INTEGER IDENTITY,
  "Name" VARCHAR NOT NULL,
  "Pass" VARCHAR NOT NULL,
  "Created" DATETIME NOT NULL,
  "LastLogIn" DATETIME,
  "SessionNr" INTEGER,
  "UserAccRight" SMALLINT NOT NULL DEFAULT 0,
  "EventDefRight" SMALLINT NOT NULL DEFAULT 0,
  PRIMARY KEY ("UserID")
);

create table EventFrameworkConstants
(
  "Key" VARCHAR,
  "Value" ANY NOT NULL,
  PRIMARY KEY ("Key")
);

delay(2000);

create procedure WSRM_CLIENT_POLICY (inout state wsrm_cli)
{
   declare policy, ind, ver, spec_v, del_ass, i_timeout, r_int, a_int, appTo soap_parameter;

   if (not state.dirty)
     return null;

   policy := new soap_parameter ();
   ind := new soap_parameter ();
   ver := new soap_parameter ();
   spec_v := new soap_parameter ();
   r_int := new soap_parameter ();
   a_int := new soap_parameter ();
   del_ass := new soap_parameter ();
   i_timeout := new soap_parameter ();
   appTo := new soap_parameter ();

  policy.set_xsd ('http://schemas.xmlsoap.org/ws/2002/12/policy:PolicyAttachment');

  ind.set_attribute ('Identifier', state.seq);
  appTo.add_member ('SequenceRef', ind);
  policy.add_member ('AppliesTo', appTo);

  ver.set_attribute ('URI', 'http://schemas.xmlsoap.org/ws/2004/03/rm');
  ver.set_attribute ('Usage', 'wsp:Required');

  i_timeout.set_attribute ('Milliseconds', state.i_timeout);

  r_int.set_attribute ('Milliseconds', state.resend_intl);

  a_int.set_attribute ('Milliseconds', state.resend_intl);

  del_ass.set_attribute ('Value','wsrm:' || state.assurance);
  del_ass.set_attribute ('Usage','wsp:Required');

  spec_v.add_member ('SpecVersion', ver);
  spec_v.add_member ('DeliveryAssurance', del_ass);
  spec_v.add_member ('InactivityTimeout', i_timeout);
  spec_v.add_member ('BaseRetransmissionInterval', r_int);
  spec_v.add_member ('AcknowledgementInterval', a_int);
  spec_v.add_member ('Expires', state.expiry);

  policy.add_member ('Policy', spec_v);

  spec_v := new soap_parameter ();
  spec_v.set_attribute ('Ref', 'http://schemas.xmlsoap.org/ws/2004/03/rm/baseTimingProfile.xml');

  policy.add_member ('PolicyReference', spec_v);

  return policy;
}
;

create procedure DUMP_VEC_IMPL (inout _vec any, inout _ses any)
{
  declare _len, _ctr integer;
  if (193 <> __tag (_vec))
    {
      if (isstring (_vec))
        http (WS.WS.STR_SQL_APOS (_vec), _ses);
      else
        http (cast (_vec as varchar), _ses);
      return;
    }
  _len := length (_vec);
  _ctr := 0;
  http ('\nvector (', _ses);
  while (_ctr < _len)
    {
      if (_ctr > 0)
        http (', ', _ses);
      DUMP_VEC_IMPL (_vec[_ctr], _ses);
      _ctr := _ctr+1;
    }
  http (')', _ses);
};
--return string-copy of vector
create function DUMP_VEC (in _vec any)
{
  declare _ses any;
  _ses := string_output();
  DUMP_VEC_IMPL (_vec, _ses);
  return string_output_string (_ses);
};

--soap procedures
create procedure
SOAP_CLIENT (
    in url varchar,
    in operation varchar,
    in target_namespace varchar := null,
    in parameters any := null,
    in headers any := null,
    in soap_action varchar := '',
    in attachments any := null,
    in ticket any := null,
    in passwd varchar := null,
    in user_name varchar := null,
    in user_password varchar := null,
    in auth_type varchar := 'none',
    in security_type varchar := 'sign',
    in debug integer := 0,
    in template varchar := null,
    in style integer := 0,
    in version integer := 11,
    in direction integer := 0,
    in http_header any := null,
    in security_schema any := null,
    in time_out int := 100)
{
  declare conn, ret any;
  conn := null;
  ret := SOAP_ASYNC_CLIENT (
		url,
		operation,
		target_namespace,
		parameters,
		headers,
		soap_action,
		attachments,
		ticket,
		passwd,
		user_name,
		user_password,
		auth_type,
		security_type,
		debug,
		template,
		style,
		version,
		direction,
		http_header,
		security_schema,
		time_out,
		conn
		);
   return ret;
}
;

create procedure
SOAP_ASYNC_CLIENT
    (
    in url varchar,
    in operation varchar,
    in target_namespace varchar := null,
    in parameters any := null,
    in headers any := null,
    in soap_action varchar := '',
    in attachments any := null,
    in ticket any := null,
    in passwd varchar := null,
    in user_name varchar := null,
    in user_password varchar := null,
    in auth_type varchar := 'none',
    in security_type varchar := 'sign',
    in debug integer := 0,
    in template varchar := null,
    in style integer := 0,
    in version integer := 11,
    in direction integer := 0,
    in http_header any := null,
    in security_schema any := null,
    in time_out int := 100,
    inout conn any
    )
{
  declare host, path varchar;
  declare hinfo, resp, ver, skeys any;
  declare security_tp int;

  hinfo := rfc1808_parse_uri (url);
  host := hinfo [1];
  if (lower (hinfo[0]) = 'https' and ticket is null)
    ticket := '1';
  path := vspx_uri_compose (vector ('','', hinfo [2], hinfo[3], hinfo[4], hinfo[5]));
  if (parameters is null)
    parameters := vector ();

  if (auth_type = 'x509' or auth_type = 'kerberos' or auth_type = 'key')
    security_tp := case security_type when 'sign' then 1 else 2 end;
  else
    {
      security_tp := 0;
      if (lower (hinfo[0]) <> 'https')
        ticket := null;
    }

  if (debug)
    ver := -1 * version;
  else
    ver := version;

  soap_action := '"' || trim (soap_action, '"') || '"';

  if (lower (hinfo[0]) = 'https' and strchr (host, ':') is null)
    host := host || ':443';

  skeys := null;

  if (connection_get ('wssc-keys') is not null)
    connection_set ('wssc-keys', null);

  resp := soap_call_new (host, path, target_namespace, operation, parameters,
      ver, ticket, passwd, soap_action, style, -- rpc/doclit
      user_name, user_password, security_tp, ticket, template, headers, http_header,
      direction, security_schema, conn, time_out, skeys);

  if (skeys is not null)
    connection_set ('wssc-keys', skeys);

  return resp;
}
;


--check for existing trigger on a table
create procedure
RDF_EVENT_FRAMEWORK_CHECK_TRIGGER_EXISTS
(
in tablename VARCHAR,
in triggername VARCHAR
)
RETURNS VARCHAR
{
DECLARE state, msg, descs, rows any;
exec(sprintf('
SELECT CASE WHEN EXISTS(SELECT * FROM SYS_TRIGGERS WHERE strcontains(T_NAME, \'%s\') AND strcontains(T_TABLE, \'%s\')) THEN \'True\' ELSE \'False\' END', triggername, tablename), state, msg, vector (), 1, descs, rows);

RETURN CAST(rows[0][0] AS VARCHAR);
};

--returns all triggers of a table
create procedure
RDF_EVENT_FRAMEWORK_GET_TRIGGERS_OF_TABLE
(
in tablename VARCHAR
)
RETURNS VARCHAR ARRAY
{
DECLARE state, msg, descs, rows any;
exec(sprintf('
SELECT T_NAME FROM SYS_TRIGGERS WHERE strcontains(T_TABLE, \'%s\')', tablename), state, msg, vector (), 0, descs, rows);

declare exarray VARCHAR ARRAY;
exarray := make_array(LENGTH (rows), 'any' );

declare i INTEGER;
for(i:=0;i<LENGTH(rows);i:=i+1){
exarray[i] := rows[i][0];
}
return exarray;
};

--returns the syntax of a trigger
create procedure
RDF_EVENT_FRAMEWORK_GET_TRIGGER_SYNTAX
(
in tablename VARCHAR,
in triggername VARCHAR
)
RETURNS VARCHAR
{
DECLARE state, msg, descs, rows any;
exec(sprintf('SELECT T_TEXT FROM  SYS_TRIGGERS 
WHERE strcontains(T_TABLE, \'%s\') AND strcontains(T_NAME, \'%s\')', tablename, triggername), state, msg, vector (), 1, descs, rows);

RETURN CAST(rows[0][0] AS VARCHAR);
};

create function RDF_EVENT_FRAMEWORK_GET_SESSION_NR()
{
declare session, rowcount INTEGER;
  session := 0;
  rowcount := 1;
  declare state, msg, descs, rows any;
  declare statement VARCHAR;
  statement := 'SELECT COUNT(*) FROM EventFrameworkUsers WHERE SessionNr = ?';
 
WHILE(session = 0 OR rowcount > 0)
{
session := rnd(1000000000) +1;
EXEC(statement ,state ,msg , vector(session), 1, descs, rows);
rowcount := CAST(rows[0][0] AS INTEGER);
}
return session;
};

--this procedure is called from client-databases to register new events
--change parameters of soap call!
create procedure
RDF_EVENT_FRAMEWORK_INSERT_NEW_EVENT( 
in instance INTEGER,
in tableName VARCHAR,
in triggerName VARCHAR,
in occurence DATETIME,
in rowVector any
)
{
declare newEventID, newTriggerID integer;
newEventID := (SELECT CASE WHEN MAX(EventID) IS NULL THEN 1 ELSE MAX(EventID)+1 END FROM EventFrameworkEvents);

declare triggerID INTEGER;
triggerID := (SELECT TriggerID FROM EventFrameworkTriggers WHERE TriggerName = triggerName OR AlternativeName = triggerName);

if(triggerID IS NOT NULL){
INSERT INTO EventFrameworkEvents("DBInstance", "TableName", "TriggerID", "Occurence", "Row")
VALUES(instance, tableName, triggerName, occurence, DUMP_VEC(rowVector));

RDF_EVENT_FRAMEWORK_SEND_EVENT_AS_SOAP_11(vector('EventID', newEventID ,'TriggerID', triggerID), 'http://' || tcpip_gethostbyaddr(tcpip_gethostbyname('localhost')) || ':8000/VirtuosoEventService/VirtuosoEventEndpoint', 'ReceiveNewEvent', 'http://tempuri.org/', '"http://tempuri.org/IVirtuosoEventService/ReceiveNewEvent"');
}
};

--calls a remote procedure/function of a soap service (uses SOAP 1.0)
create procedure RDF_EVENT_FRAMEWORK_SEND_EVENT_AS_SOAP (
in parametersVector any,
in endpointUrl varchar,
in operationName varchar,
in targetNamespace varchar,
in soapAction varchar
)
{
SOAP_CLIENT(
URL=>endpointUrl,
operation=>operationName,
parameters=>parametersVector,
target_namespace=>targetNamespace,
soap_action=>soapAction,
direction=>1,
version=>01);
};

--calls a remote procedure/function of a soap service (uses SOAP 1.1)
create procedure RDF_EVENT_FRAMEWORK_SEND_EVENT_AS_SOAP_11 (
in parametersVector any,
in endpointUrl varchar,
in operationName varchar,
in targetNamespace varchar,
in soapAction varchar
)
{
declare continue handler for SQLSTATE 'HTCLI' {return;};

SOAP_CLIENT(
URL=>endpointUrl,
operation=>operationName,
parameters=>parametersVector,
target_namespace=>targetNamespace,
soap_action=>soapAction,
direction=>1,
version=>11);
};

 create procedure
RDF_EVENT_FRAMEWORK_SEND_EVENT_AS_WSRM
(
in tablename VARCHAR,
in triggername VARCHAR,
in rowVector ANY,
in remoteEndpoint VARCHAR := null
)
{
if(remoteEndpoint IS NULL){
SIGNAL ('DestinationMissing', 'No destination endpoint was provided.');
return;
}
declare thisEndpoint VARCHAR;
thisEndpoint := 'http://' || tcpip_gethostbyaddr(tcpip_gethostbyname('localhost')) || ':8890/EventFrameworkProcedures';
declare instance INTEGER;
instance := 1;
dbg_obj_print(remoteEndpoint);
    declare addr wsa_cli;
    declare test wsrm_cli;
    declare req soap_client_req;
    declare finish any;
    declare param soap_parameter;

    param := new soap_parameter ();
    param.add_member ('instance', instance);
    param.add_member ('tableName', tablename);
    param.add_member ('triggerName', triggername);
    param.add_member ('occurence', now());
    param.add_member ('rowVector', rowVector);
    param.set_xsd ('services.wsdl:RDF_EVENT_FRAMEWORK_INSERT_NEW_EVENT');

    addr := new wsa_cli ();
    addr."to" := remoteEndpoint;
    addr."from" := thisEndpoint;
    addr.action := '"RDF_EVENT_FRAMEWORK_INSERT_NEW_EVENT"';

    req := new soap_client_req ();
    req.url := remoteEndpoint;
    req.operation := 'RDF_EVENT_FRAMEWORK_INSERT_NEW_EVENT';
    req.parameters := vector_concat(param.get_call_param ('instance'), param.get_call_param ('tableName'), param.get_call_param ('triggerName'),    param.get_call_param ('occurence'), param.get_call_param ('rowVector'));
    
    test := new wsrm_cli (addr, remoteEndpoint);
test.set_parameter ('Assurance', 'ExactlyOnce');
test.set_parameter ('Expiry', CAST(dateadd('day', 7, now()) AS DATETIME));
test.set_parameter ('Timeout', 2000);
test.set_parameter ('RetryInterval', 10000);
test.set_parameter ('AckInterval', 20000);
    test.finish (req);
return req.version;
}

--establishes new trigger an a given table
 create procedure
RDF_EVENT_FRAMEWORK_SET_NEW_TRIGGER(
in statement VARCHAR,
in tablee VARCHAR,
in database VARCHAR,
in triggerName VARCHAR
)
RETURNS VARCHAR
{
--execute new trigger
EXEC(statement);

--check if new trigger was added and return true/false
DECLARE state, msg, descs, rows any;
exec(sprintf('SELECT CASE WHEN EXISTS(SELECT * FROM  SYS_TRIGGERS 
WHERE T_TABLE = \'%s.%s\' AND strcontains(T_NAME, \'%s\')) THEN \'True\' ELSE \'False\' END', database, tablee, triggerName), state, msg, vector (), 1, descs, rows);

RETURN CAST(rows[0][0] AS VARCHAR);
};

--returns all tables of a given DB-schema
create procedure
RDF_EVENT_FRAMEWORK_GET_SCHEMA_TABLES
( in DBschema VARCHAR )
RETURNS VARCHAR ARRAY
{
DECLARE state, msg, descs, rows any;
EXEC(sprintf('SELECT T_NAME FROM %s.XDDL_TABLES WHERE strcontains(T_NAME, \'%s\')',DBschema ,DBschema ), state, msg, vector(), 3000, descs, rows);

declare TABLE_NAMES VARCHAR;
declare exarray VARCHAR ARRAY;
exarray := make_array(LENGTH (rows), 'any' );
result_names(TABLE_NAMES);

declare i INTEGER;
for(i:=0;i<LENGTH(rows);i:=i+1){
result(rows[i][0]);
exarray[i] := rows[i][0];
}

return exarray;
};

create procedure
RDF_EVENT_FRAMEWORK_INSERT_CONSTANT
( 
in keyV VARCHAR,
in valueV ANY
)
{
INSERT INTO EventFrameworkConstants VALUES(keyV, valueV);
};

 create procedure RDF_EVENT_FRAMEWORK_REGISTER_REMOTE_DB
(
in catalogSchema VARCHAR,
in dbType VARCHAR,
in description VARCHAR,
in remoteSoapEndpoint VARCHAR,
in remoteSparqlEndpoint VARCHAR,
in rdfGraphCommaList VARCHAR
)
RETURNS VARCHAR
{
declare exit handler for sqlstate 'HTCLI'{
rollback work;
return 'Remote DB has not been reached.';
};

INSERT INTO EventFrameworkDatabases (SchemaName, SQLDialect, Description, ControlID, ProcedureEndpoint, SparqlEndpointAddress, RdfGraphs) VALUES (catalogSchema, dbType, description, rnd(2000000000), remoteSoapEndpoint, remoteSparqlEndpoint, rdfGraphCommaList);

declare dbInstance, controlID INTEGER;
dbInstance := (SELECT MAX(DBInstance) FROM EventFrameworkDatabases);
controlID := (SELECT ControlID FROM EventFrameworkDatabases WHERE DBInstance = dbInstance);


RDF_EVENT_FRAMEWORK_SEND_EVENT_AS_SOAP(vector('controlID', controlID ,'dbInstance', dbInstance, 'endpointAdd', 'http://' || tcpip_gethostbyaddr(tcpip_gethostbyname('localhost')) || ':8890/EventFrameworkProcedures'), remoteSoapEndpoint, 'RDF_EVENT_FRAMEWORK_REGISTER_DB', 'services.wsdl', '"http://openlinksw.com/virtuoso/soap/schema#RDF_EVENT_FRAMEWORK_REGISTER_DB"');
commit work;

RETURN 'True';
};

create method create_sequence () for wsrm_cli
  {
    if (self.seq is not null)
      signal ('37000', 'Sequence is alredy created, first cancel or finish');

    self.seq := lower ('UUID:'||uuid ());
    self.msgno := 0;
    self.assurance := 'ExactlyOnce';
    self.expiry := dateadd ('week', 1, now ());
    self.i_timeout := 2000;
    self.resend_intl := 10000;
    self.ack_intl := 2000;

    insert into SYS_WSRM_OUT_SEQUENCES (
    	WOS_IDENTIFIER, WOS_VERSION, WOS_DELIVERY_ASSURANCE,
	WOS_SEQUENCE_EXPIRATION, WOS_INACTIVITY_TIMEOUT, WOS_RETRANSMISSION_INTERVAL,
	WOS_ACKNOWLEDGEMENT_INTERVAL)
	values 	(self.seq, self.current_ver (), self.assurance, self.expiry,
		 self.i_timeout, self.resend_intl, self.ack_intl);
    return self.seq;
  }
;

--grant execute rights on all procedures to publish
grant execute on RDF_EVENT_FRAMEWORK_GET_SCHEMA_TABLES to DBA;
grant execute on RDF_EVENT_FRAMEWORK_SET_NEW_TRIGGER to DBA;
grant execute on RDF_EVENT_FRAMEWORK_INSERT_NEW_EVENT to DBA;
grant execute on RDF_EVENT_FRAMEWORK_GET_TRIGGER_SYNTAX to DBA;
grant execute on RDF_EVENT_FRAMEWORK_GET_TRIGGERS_OF_TABLE to DBA;
grant execute on RDF_EVENT_FRAMEWORK_CHECK_TRIGGER_EXISTS to DBA;
grant execute on RDF_EVENT_FRAMEWORK_INSERT_CONSTANT to DBA;
grant execute on RDF_EVENT_FRAMEWORK_REGISTER_REMOTE_DB to DBA;
grant execute on WSRMSequence to DBA;
grant execute on WSRMSequenceTerminate to DBA;
grant execute on WSRMAckRequested to DBA;
grant execute on WSRMCreateSequence to DBA;
grant execute on WSRMTerminateSequence to DBA;
grant execute on WSRMSequenceAcknowledgement to DBA;

--create new SOAP endpoint 'EventFrameworkProcedures'
VHOST_REMOVE (
	 lhost=>'*ini*',
	 vhost=>'*ini*',
	 lpath=>'/EventFrameworkProcedures'
);

VHOST_DEFINE (
	 lhost=>'*ini*',
	 vhost=>'*ini*',
	 lpath=>'/EventFrameworkProcedures',
	 ppath=>'/SOAP/',
	 is_dav=>0,
	 def_page=>'index.html',
	 soap_user=>'dba',
	 ses_vars=>0,
	 soap_opts=>vector ('ServiceName', 'EventFrameworkProcedures', 'MethodInSoapAction', 'yes', 'CR-escape', 'yes', 'elementFormDefault', 'unqualified', 'DIME-ENC', 'no', 'WS-SEC', 'no', 'WSS-Validate-Signature', '0', 'WS-RP', 'no', 'Use', 'literal', 'XML-RPC', 'no'),
	 is_default_host=>0
);

--DB entries
INSERT INTO EventFrameworkDatabases (SchemaName, SQLDialect, Description, ControlID, ProcedureEndpoint, SparqlEndpointAddress, RdfGraphs) VALUES ('DB.DBA', 'Virtuoso', 'central event-database', rnd(2000000000), 'http://' || tcpip_gethostbyaddr(tcpip_gethostbyname('localhost')) || ':8890/EventFrameworkProcedures', 'http://' || tcpip_gethostbyaddr(tcpip_gethostbyname('localhost')) || ':8890/sparql',DUMP_VEC( vector('http://rdf.event.framework/group.event.def', 'http://rdf.event.framework/directory.tag.def', 'http://rdf.event.framework/instances')));

INSERT INTO EventFrameworkUsers(Name,Pass,Created,UserAccRight,EventDefRight) VALUES('Admin', 'admin', now(), 1, 1);

INSERT INTO EventFrameworkConstants VALUES('supportedDBs', 'Virtuoso, MS SQL-Server, Oracle');

UPDATE SYS_SOAP_DATATYPES
SET  SDT_SCH =   '<?xml version="1.0" encoding="UTF-8" ?><xsd:element xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="Expires" type="xsd:dateTime" xmlns:n2="http://schemas.xmlsoap.org/ws/2002/07/utility" targetNamespace="http://schemas.xmlsoap.org/ws/2002/07/utility" />'
WHERE SDT_NAME = 'http://schemas.xmlsoap.org/ws/2002/07/utility:Expires';
