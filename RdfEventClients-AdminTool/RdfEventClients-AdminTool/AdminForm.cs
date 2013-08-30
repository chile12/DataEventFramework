using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;
using RdfEventClients_AdminTool.EventClientProxyRef;

namespace RdfEventClients_AdminTool
{
    public partial class AdminForm : Form
    {
        private static bool loggedIn = false;
        private static bool userAccountRights = false;
        private static bool eventDefinitionRights = false;

        private EventClientNetTcpClient clientProxy;

        private string selectedAcc = null;

        //DEBUG stuff
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public AdminForm()
        {
            InitializeComponent();
            clientProxy = new EventClientNetTcpClient();
            usersDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            //DEBUG stuff
            timer.Interval = 5000;
            timer.Tick += new EventHandler(timer_Tick);
            timer_Tick(new object(), new EventArgs());
            timer.Start();
        }
        /// <summary>
        /// DEBUG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
        {
            tripleDGV.DataSource = clientProxy.GetEvents(1000);
            foreach (DataGridViewColumn col in tripleDGV.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            timer.Start();
        }

        private void loginBT_Click(object sender, EventArgs e)
        {
            string returnStr ="";
            returnStr = clientProxy.LogIn(usernameTB.Text, passwordTB.Text);
            if (returnStr.Substring(0, 1) == "1")
                userAccountRights = true;                           //x = UserAccountRights (as 0,1) 
            if (returnStr.Substring(1, 1) == "1")
                eventDefinitionRights = true;                       //y = EventDefinitionRights
            loggedIn = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedTab != LogInTab && !loggedIn)   //not!
            {
                MessageBox.Show("Please Log In first.");
                mainTabControl.SelectedTab = LogInTab;
            }
            else
            {
                if (mainTabControl.SelectedTab == this.accountTab) 
                {
                    if (!userAccountRights)//not!
                    {
                        MessageBox.Show("You have no right to view this conetent.");
                        mainTabControl.SelectedTab = LogInTab;
                    }
                    else
                        refreshBT_Click(new object(), new EventArgs());
                }
                if (mainTabControl.SelectedTab == this.EcaDefTab && !eventDefinitionRights) //not!
                {
                    MessageBox.Show("You have no right to view this conetent.");
                    mainTabControl.SelectedTab = LogInTab;
                }
                if (mainTabControl.SelectedTab == databaseTab)
                {
                    string[] bases = clientProxy.GetSupportedDBs().Split(',');
                    dbTypeCB.Items.AddRange(bases);
                }
            }
        }

        private void refreshBT_Click(object sender, EventArgs e)
        {
            usersDGV.DataSource = clientProxy.GetUsers("");
        }

        private void usersDGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedAcc = usersDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                accountLA.Text = selectedAcc;
            }
            else
            {
                selectedAcc = null;
                accountLA.Text = "";
            }
        }

        private void newAccBT_Click(object sender, EventArgs e)
        {
            NewAccount acc = new NewAccount();
            acc.ShowDialog();
            if (clientProxy.CreateNewAccount(acc.username, acc.password))
                refreshBT_Click(new object(), new EventArgs());
            else
                MessageBox.Show("An unknown error has occured.");
            acc.Dispose();
        }

        private void switchAccRightBT_Click(object sender, EventArgs e)
        {
            if (selectedAcc != null && selectedAcc != "Admin")
            {
                bool right = false;
                int rightNow = int.Parse(usersDGV.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[1].Value.ToString() == selectedAcc).First().Cells["UserAccRight"].Value.ToString());
                if (rightNow == 0)
                    right = true;

                ConfirmPassword passWind = new ConfirmPassword(false);
                passWind.ShowDialog();

                if (clientProxy.SetUserAccountRights(right, selectedAcc, passWind.adminPassword))
                    refreshBT_Click(new object(), new EventArgs());
                else
                    MessageBox.Show("It seems you entered a wrong password.");

                passWind.Dispose();
            }
            else
                MessageBox.Show("Please select an account (not 'Admin'!) to do this.");
        }

        private void switchEventRightsBT_Click(object sender, EventArgs e)
        {
            if (selectedAcc != null && selectedAcc != "Admin")
            {
                bool right = false;
                int rightNow = int.Parse(usersDGV.Rows.Cast<DataGridViewRow>().Where(x => x.Cells[1].Value.ToString() == selectedAcc).First().Cells["EventDefRight"].Value.ToString());
                if (rightNow == 0)
                    right = true;

                ConfirmPassword passWind = new ConfirmPassword(false);
                passWind.ShowDialog();

                if (clientProxy.SetEventDefinitionRights(right, selectedAcc, passWind.adminPassword))
                    refreshBT_Click(new object(), new EventArgs());
                else
                    MessageBox.Show("It seems you entered a wrong password.");

                passWind.Dispose();
            }
            else
                MessageBox.Show("Please select an account (not 'Admin'!) to do this.");
        }

        private void resetPassBT_Click(object sender, EventArgs e)
        {
            if (selectedAcc != null)
            {
                ConfirmPassword passWind = new ConfirmPassword(true);
                passWind.ShowDialog();

                if (clientProxy.ResetPassword(selectedAcc, passWind.newPassword, passWind.adminPassword))
                    refreshBT_Click(new object(), new EventArgs());
                else
                    MessageBox.Show("It seems you entered a wrong password.");

                passWind.Dispose();
            }
            else
                MessageBox.Show("Please select an account to do this.");
        }

        private void deleteAccBT_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AtomicEvents atom = new AtomicEvents();
            atom.ShowDialog();
        }

        private void databaseRefreshBT_Click(object sender, EventArgs e)
        {
            submitDbBT.DataSource = clientProxy.GetDatabases();
            foreach (DataGridViewColumn col in submitDbBT.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string zw ="";
            try
            {
                string remote = remoteEndpointTB.Text.Trim();

                zw = clientProxy.RegisterNewRemoteDB(dbTypeCB.SelectedItem.ToString(), remoteEndpointTB.Text, dbDescribtionRTB.Text, sparqlENdpointTB.Text, graphUrisRTB.Text, "DB.DBA");
            
                if (bool.Parse(zw))
                    registerAnswerRTB.Text = "registration succeded";
                refreshBT_Click(new object(), new EventArgs());
                return;
            }
            catch (Exception ex) {
                if (ex.Message.Contains("primary key"))
                    zw = "This DB may have been registered before. Please clear the Table EventFrameworkConstants and try again";
            }

            registerAnswerRTB.Text = zw;
        }
    }
}
