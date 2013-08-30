using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RdfEventClients_AdminTool.EventClientProxyRef;

namespace RdfEventClients_AdminTool
{
    public partial class atomicEventControl : UserControl
    {
        private EventClientNetTcpClient clientProxy;
        private VirtuosoDataSet.VirtuosoDataTableDataTable databases;

        public atomicEventControl()
        {
            InitializeComponent();

            clientProxy = new EventClientNetTcpClient();
            databases = clientProxy.GetDatabases();
            string[] databasearray = new string[databases.Rows.Count];
            for (int i = 0; i < databases.Rows.Count; i++)
                foreach (object item in databases[i].ItemArray)
                    databasearray[i] += item.ToString() + ", ";
            this.chooseDbCB.Items.AddRange(databasearray);
        }

        private void createEventBT_Click(object sender, EventArgs e)
        {
            if (chooseEventCatCB.SelectedIndex == 0)
            {
                CreateRegisterEvents createRegister = new CreateRegisterEvents(databases.Rows[chooseDbCB.SelectedIndex]);
                createRegister.ShowDialog();
            };
        }
    }
}
