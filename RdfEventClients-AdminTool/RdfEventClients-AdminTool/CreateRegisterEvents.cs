using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RdfEventClients_AdminTool.EventClientProxyRef;

namespace RdfEventClients_AdminTool
{
    public partial class CreateRegisterEvents : Form
    {
        private EventClientNetTcpClient clientProxy;
        int database = 0;
        string endpointAddress = "";

        public CreateRegisterEvents(DataRow dbRow)
        {
            InitializeComponent();
            this.database = (int)dbRow.ItemArray[0];
            this.endpointAddress = dbRow.ItemArray[3].ToString();
            clientProxy = new EventClientNetTcpClient();

            this.chooseTableCB.Items.Clear();
            chooseTableCB.Items.AddRange(clientProxy.GetSchemaTables(dbRow.ItemArray[1].ToString(), endpointAddress));
        }

        private void executeQuerryBT_Click(object sender, EventArgs e)
        {
            string condition = conditionRTB.Text.Trim();
            if (condition.Length >8 && condition.Substring(0, 6).ToLower() != "where ")
                condition = "WHERE " + condition;

            condition = condition.Replace("'", "\'");

            object zw = null;
            if (chooseTableCB.SelectedItem != null)
            {
                if (condition.Length == 0 || condition.Length > 8)
                    zw = clientProxy.ExecuteTestSqlQuery("SELECT TOP 100 * FROM \"" + chooseTableCB.SelectedItem.ToString() + "\" " + condition, endpointAddress);
            }
            else
                MessageBox.Show("please select a table");

            List<List<string>> lala = new List<List<string>>();
            DataTable sourceDT = new DataTable();

            if (zw != null && zw != DBNull.Value)
            {
                for (int j = 0; j < ((zw as object[][])[0] as string[]).Count(); j++)
                    sourceDT.Columns.Add(((zw as object[][])[0] as string[])[j]);

                for (int i = 1; i < (zw as object[][]).Count(); i++)
                {
                    sourceDT.Rows.Add(((zw as object[][])[i] as string[]));
                }
                resultDGV.DataSource = sourceDT;
            }
        }

        private void confirmTriggerBT_Click(object sender, EventArgs e)
        {
            if (this.triggerTypeCB.SelectedItem == null)
            {
                MessageBox.Show("please select the trigger-type");
                return;
            }
            if (this.chooseTableCB.SelectedItem == null)
            {
                MessageBox.Show("please select a data-table");
                return;
            }
            if (conditionRTB.Text.Trim().Length < 9)
            {
                MessageBox.Show("please enter a condition");
                return;
            }

        }
    }
}
