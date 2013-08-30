using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using RdfEventClients_AdminTool.EventClientProxyRef;

namespace RdfEventClients_AdminTool
{
    public partial class AtomicEvents : Form
    {
        private EventClientNetTcpClient clientProxy;
        private VirtuosoDataSet.VirtuosoDataTableDataTable databases;

        public AtomicEvents()
        {
            InitializeComponent();

            clientProxy = new EventClientNetTcpClient();
            databases = clientProxy.GetDatabases();
            string[] databasearray = new string[databases.Rows.Count];
            for(int i =0; i < databases.Rows.Count; i++)
                foreach(object item in databases[i].ItemArray)
                    databasearray[i] += item.ToString() + ", ";
            dbSelectCB.Items.AddRange(databasearray);
        }

        private void registerTriggerBT_Click(object sender, EventArgs e)
        {
          
        }

        private void dbSelectCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlRdfSelectCB.Items.Clear();
            sqlRdfSelectCB.Items.Add("SQL-table");
            if (string.IsNullOrEmpty(databases[dbSelectCB.SelectedIndex].ItemArray[databases[dbSelectCB.SelectedIndex].ItemArray.Count() - 2].ToString()))
            {
                sqlRdfSelectCB.Items.Add("RDF-graph");
            }
        }

        private void sqlRdfSelectCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sqlRdfSelectCB.SelectedItem.ToString() == "SQL-table"){
                tableSelectLA.Visible = true;
                tableSelectCB.Visible = true;
                manualTriggerDisclaimerLA.Visible = true;
                triggerSelectCB.Visible = true;
                registerTriggerBT.Visible = true;

                tableSelectCB.Items.Clear();
                tableSelectCB.Items.AddRange(clientProxy.GetSchemaTables(databases[dbSelectCB.SelectedIndex].ItemArray[1].ToString(), databases[dbSelectCB.SelectedIndex].ItemArray[5].ToString()));
            }
        }

        private void tableSelectCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            triggerSelectCB.Items.Clear();
            triggerSelectCB.Items.AddRange(clientProxy.GetTriggersOfTable(tableSelectCB.SelectedItem.ToString(), databases[dbSelectCB.SelectedIndex].ItemArray[5].ToString()));
        }
    }
}
