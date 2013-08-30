namespace RdfEventClients_AdminTool
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.LogInTab = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.tripleDGV = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.loginBT = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordTB = new System.Windows.Forms.TextBox();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.accountTab = new System.Windows.Forms.TabPage();
            this.UserAccTab = new System.Windows.Forms.TabPage();
            this.deleteAccBT = new System.Windows.Forms.Button();
            this.switchEventRightsBT = new System.Windows.Forms.Button();
            this.switchAccRightBT = new System.Windows.Forms.Button();
            this.resetPassBT = new System.Windows.Forms.Button();
            this.accountLA = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.newAccBT = new System.Windows.Forms.Button();
            this.refreshBT = new System.Windows.Forms.Button();
            this.usersDGV = new System.Windows.Forms.DataGridView();
            this.EcaDefTab = new System.Windows.Forms.TabPage();
            this.ecaDefPanel = new System.Windows.Forms.Panel();
            this.databaseTab = new System.Windows.Forms.TabPage();
            this.registerAnswerRTB = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.dbDescribtionRTB = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.graphUrisRTB = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.sparqlENdpointTB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.remoteEndpointTB = new System.Windows.Forms.TextBox();
            this.dbTypeCB = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.databaseRefreshBT = new System.Windows.Forms.Button();
            this.submitDbBT = new System.Windows.Forms.DataGridView();
            this.EcaTabControl = new System.Windows.Forms.TabControl();
            this.atomicEventsTab = new System.Windows.Forms.TabPage();
            this.ecaRulesTab = new System.Windows.Forms.TabPage();
            this.eventDefControl1 = new RdfEventClients_AdminTool.atomicEventControl();
            this.mainTabControl.SuspendLayout();
            this.LogInTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tripleDGV)).BeginInit();
            this.UserAccTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDGV)).BeginInit();
            this.EcaDefTab.SuspendLayout();
            this.databaseTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.submitDbBT)).BeginInit();
            this.EcaTabControl.SuspendLayout();
            this.atomicEventsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.LogInTab);
            this.mainTabControl.Controls.Add(this.accountTab);
            this.mainTabControl.Controls.Add(this.UserAccTab);
            this.mainTabControl.Controls.Add(this.EcaDefTab);
            this.mainTabControl.Controls.Add(this.databaseTab);
            this.mainTabControl.Location = new System.Drawing.Point(0, 26);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1019, 569);
            this.mainTabControl.TabIndex = 1;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // LogInTab
            // 
            this.LogInTab.Controls.Add(this.button2);
            this.LogInTab.Controls.Add(this.tripleDGV);
            this.LogInTab.Controls.Add(this.label6);
            this.LogInTab.Controls.Add(this.label5);
            this.LogInTab.Controls.Add(this.button1);
            this.LogInTab.Controls.Add(this.loginBT);
            this.LogInTab.Controls.Add(this.label3);
            this.LogInTab.Controls.Add(this.label2);
            this.LogInTab.Controls.Add(this.passwordTB);
            this.LogInTab.Controls.Add(this.usernameTB);
            this.LogInTab.Controls.Add(this.label1);
            this.LogInTab.Location = new System.Drawing.Point(4, 22);
            this.LogInTab.Name = "LogInTab";
            this.LogInTab.Padding = new System.Windows.Forms.Padding(3);
            this.LogInTab.Size = new System.Drawing.Size(1011, 543);
            this.LogInTab.TabIndex = 0;
            this.LogInTab.Text = "LogIn";
            this.LogInTab.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(155, 336);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // tripleDGV
            // 
            this.tripleDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tripleDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tripleDGV.Location = new System.Drawing.Point(236, 3);
            this.tripleDGV.Name = "tripleDGV";
            this.tripleDGV.Size = new System.Drawing.Size(775, 540);
            this.tripleDGV.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "pending";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "create new trigger";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "trigger";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // loginBT
            // 
            this.loginBT.Location = new System.Drawing.Point(155, 101);
            this.loginBT.Name = "loginBT";
            this.loginBT.Size = new System.Drawing.Size(75, 23);
            this.loginBT.TabIndex = 5;
            this.loginBT.Text = "Log In";
            this.loginBT.UseVisualStyleBackColor = true;
            this.loginBT.Click += new System.EventHandler(this.loginBT_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username:";
            // 
            // passwordTB
            // 
            this.passwordTB.Location = new System.Drawing.Point(92, 75);
            this.passwordTB.Name = "passwordTB";
            this.passwordTB.Size = new System.Drawing.Size(138, 20);
            this.passwordTB.TabIndex = 2;
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(92, 48);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(138, 20);
            this.usernameTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log In:";
            // 
            // accountTab
            // 
            this.accountTab.Location = new System.Drawing.Point(4, 22);
            this.accountTab.Name = "accountTab";
            this.accountTab.Padding = new System.Windows.Forms.Padding(3);
            this.accountTab.Size = new System.Drawing.Size(1011, 543);
            this.accountTab.TabIndex = 3;
            this.accountTab.Text = "Account";
            this.accountTab.UseVisualStyleBackColor = true;
            // 
            // UserAccTab
            // 
            this.UserAccTab.Controls.Add(this.deleteAccBT);
            this.UserAccTab.Controls.Add(this.switchEventRightsBT);
            this.UserAccTab.Controls.Add(this.switchAccRightBT);
            this.UserAccTab.Controls.Add(this.resetPassBT);
            this.UserAccTab.Controls.Add(this.accountLA);
            this.UserAccTab.Controls.Add(this.label4);
            this.UserAccTab.Controls.Add(this.newAccBT);
            this.UserAccTab.Controls.Add(this.refreshBT);
            this.UserAccTab.Controls.Add(this.usersDGV);
            this.UserAccTab.Location = new System.Drawing.Point(4, 22);
            this.UserAccTab.Name = "UserAccTab";
            this.UserAccTab.Padding = new System.Windows.Forms.Padding(3);
            this.UserAccTab.Size = new System.Drawing.Size(1011, 543);
            this.UserAccTab.TabIndex = 1;
            this.UserAccTab.Text = "User Accounts";
            this.UserAccTab.UseVisualStyleBackColor = true;
            // 
            // deleteAccBT
            // 
            this.deleteAccBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteAccBT.Location = new System.Drawing.Point(737, 514);
            this.deleteAccBT.Name = "deleteAccBT";
            this.deleteAccBT.Size = new System.Drawing.Size(137, 23);
            this.deleteAccBT.TabIndex = 8;
            this.deleteAccBT.Text = "delete selected account";
            this.deleteAccBT.UseVisualStyleBackColor = true;
            this.deleteAccBT.Click += new System.EventHandler(this.deleteAccBT_Click);
            // 
            // switchEventRightsBT
            // 
            this.switchEventRightsBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.switchEventRightsBT.Location = new System.Drawing.Point(634, 514);
            this.switchEventRightsBT.Name = "switchEventRightsBT";
            this.switchEventRightsBT.Size = new System.Drawing.Size(97, 23);
            this.switchEventRightsBT.TabIndex = 7;
            this.switchEventRightsBT.Text = "event rights";
            this.switchEventRightsBT.UseVisualStyleBackColor = true;
            this.switchEventRightsBT.Click += new System.EventHandler(this.switchEventRightsBT_Click);
            // 
            // switchAccRightBT
            // 
            this.switchAccRightBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.switchAccRightBT.Location = new System.Drawing.Point(531, 514);
            this.switchAccRightBT.Name = "switchAccRightBT";
            this.switchAccRightBT.Size = new System.Drawing.Size(97, 23);
            this.switchAccRightBT.TabIndex = 6;
            this.switchAccRightBT.Text = "account rights";
            this.switchAccRightBT.UseVisualStyleBackColor = true;
            this.switchAccRightBT.Click += new System.EventHandler(this.switchAccRightBT_Click);
            // 
            // resetPassBT
            // 
            this.resetPassBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resetPassBT.Location = new System.Drawing.Point(430, 514);
            this.resetPassBT.Name = "resetPassBT";
            this.resetPassBT.Size = new System.Drawing.Size(95, 23);
            this.resetPassBT.TabIndex = 5;
            this.resetPassBT.Text = "reset password";
            this.resetPassBT.UseVisualStyleBackColor = true;
            this.resetPassBT.Click += new System.EventHandler(this.resetPassBT_Click);
            // 
            // accountLA
            // 
            this.accountLA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.accountLA.AutoSize = true;
            this.accountLA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountLA.Location = new System.Drawing.Point(357, 517);
            this.accountLA.Name = "accountLA";
            this.accountLA.Size = new System.Drawing.Size(26, 15);
            this.accountLA.TabIndex = 4;
            this.accountLA.Text = "acc";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(135, 517);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "you have selected the following account:";
            // 
            // newAccBT
            // 
            this.newAccBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newAccBT.Location = new System.Drawing.Point(27, 514);
            this.newAccBT.Name = "newAccBT";
            this.newAccBT.Size = new System.Drawing.Size(106, 23);
            this.newAccBT.TabIndex = 2;
            this.newAccBT.Text = "add new account";
            this.newAccBT.UseVisualStyleBackColor = true;
            this.newAccBT.Click += new System.EventHandler(this.newAccBT_Click);
            // 
            // refreshBT
            // 
            this.refreshBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBT.Location = new System.Drawing.Point(905, 514);
            this.refreshBT.Name = "refreshBT";
            this.refreshBT.Size = new System.Drawing.Size(56, 23);
            this.refreshBT.TabIndex = 1;
            this.refreshBT.Text = "refresh";
            this.refreshBT.UseVisualStyleBackColor = true;
            this.refreshBT.Click += new System.EventHandler(this.refreshBT_Click);
            // 
            // usersDGV
            // 
            this.usersDGV.AllowUserToAddRows = false;
            this.usersDGV.AllowUserToDeleteRows = false;
            this.usersDGV.AllowUserToResizeColumns = false;
            this.usersDGV.AllowUserToResizeRows = false;
            this.usersDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.usersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDGV.Location = new System.Drawing.Point(2, 2);
            this.usersDGV.Name = "usersDGV";
            this.usersDGV.ReadOnly = true;
            this.usersDGV.RowHeadersWidth = 10;
            this.usersDGV.Size = new System.Drawing.Size(1007, 506);
            this.usersDGV.TabIndex = 0;
            this.usersDGV.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.usersDGV_CellMouseDown);
            // 
            // EcaDefTab
            // 
            this.EcaDefTab.Controls.Add(this.EcaTabControl);
            this.EcaDefTab.Controls.Add(this.ecaDefPanel);
            this.EcaDefTab.Location = new System.Drawing.Point(4, 22);
            this.EcaDefTab.Name = "EcaDefTab";
            this.EcaDefTab.Padding = new System.Windows.Forms.Padding(3);
            this.EcaDefTab.Size = new System.Drawing.Size(1011, 543);
            this.EcaDefTab.TabIndex = 2;
            this.EcaDefTab.Text = "ECA-Rules";
            this.EcaDefTab.UseVisualStyleBackColor = true;
            // 
            // ecaDefPanel
            // 
            this.ecaDefPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ecaDefPanel.Location = new System.Drawing.Point(3, 3);
            this.ecaDefPanel.Name = "ecaDefPanel";
            this.ecaDefPanel.Size = new System.Drawing.Size(1005, 537);
            this.ecaDefPanel.TabIndex = 0;
            // 
            // databaseTab
            // 
            this.databaseTab.Controls.Add(this.registerAnswerRTB);
            this.databaseTab.Controls.Add(this.label14);
            this.databaseTab.Controls.Add(this.label13);
            this.databaseTab.Controls.Add(this.button3);
            this.databaseTab.Controls.Add(this.dbDescribtionRTB);
            this.databaseTab.Controls.Add(this.label12);
            this.databaseTab.Controls.Add(this.label11);
            this.databaseTab.Controls.Add(this.graphUrisRTB);
            this.databaseTab.Controls.Add(this.label10);
            this.databaseTab.Controls.Add(this.label9);
            this.databaseTab.Controls.Add(this.sparqlENdpointTB);
            this.databaseTab.Controls.Add(this.label8);
            this.databaseTab.Controls.Add(this.remoteEndpointTB);
            this.databaseTab.Controls.Add(this.dbTypeCB);
            this.databaseTab.Controls.Add(this.label7);
            this.databaseTab.Controls.Add(this.databaseRefreshBT);
            this.databaseTab.Controls.Add(this.submitDbBT);
            this.databaseTab.Location = new System.Drawing.Point(4, 22);
            this.databaseTab.Name = "databaseTab";
            this.databaseTab.Padding = new System.Windows.Forms.Padding(3);
            this.databaseTab.Size = new System.Drawing.Size(1011, 543);
            this.databaseTab.TabIndex = 4;
            this.databaseTab.Text = "Databases";
            this.databaseTab.UseVisualStyleBackColor = true;
            // 
            // registerAnswerRTB
            // 
            this.registerAnswerRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registerAnswerRTB.Location = new System.Drawing.Point(656, 497);
            this.registerAnswerRTB.Name = "registerAnswerRTB";
            this.registerAnswerRTB.Size = new System.Drawing.Size(173, 43);
            this.registerAnswerRTB.TabIndex = 21;
            this.registerAnswerRTB.Text = "";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(653, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(214, 16);
            this.label14.TabIndex = 20;
            this.label14.Text = "register a new database here:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(163, 16);
            this.label13.TabIndex = 19;
            this.label13.Text = "all knowen databases:";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(835, 512);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 28);
            this.button3.TabIndex = 18;
            this.button3.Text = "submit new database";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dbDescribtionRTB
            // 
            this.dbDescribtionRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dbDescribtionRTB.Location = new System.Drawing.Point(654, 172);
            this.dbDescribtionRTB.Name = "dbDescribtionRTB";
            this.dbDescribtionRTB.Size = new System.Drawing.Size(350, 71);
            this.dbDescribtionRTB.TabIndex = 17;
            this.dbDescribtionRTB.Text = "";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(650, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(329, 16);
            this.label12.TabIndex = 16;
            this.label12.Text = "enter a short description of this database here:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(653, 473);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(304, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "only graphs relevant for events are needed, can be added later";
            // 
            // graphUrisRTB
            // 
            this.graphUrisRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.graphUrisRTB.Location = new System.Drawing.Point(654, 342);
            this.graphUrisRTB.Name = "graphUrisRTB";
            this.graphUrisRTB.Size = new System.Drawing.Size(350, 124);
            this.graphUrisRTB.TabIndex = 14;
            this.graphUrisRTB.Text = "";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(650, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(327, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "enter RDF-graph-uris as comma-list: (optional)";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(650, 257);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(363, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "enter the SPARQL-entpoint-address here: (optional)";
            // 
            // sparqlENdpointTB
            // 
            this.sparqlENdpointTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sparqlENdpointTB.Location = new System.Drawing.Point(653, 276);
            this.sparqlENdpointTB.Name = "sparqlENdpointTB";
            this.sparqlENdpointTB.Size = new System.Drawing.Size(351, 20);
            this.sparqlENdpointTB.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(651, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(343, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "insert the endpoint address of the new database:";
            // 
            // remoteEndpointTB
            // 
            this.remoteEndpointTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remoteEndpointTB.Location = new System.Drawing.Point(654, 115);
            this.remoteEndpointTB.Name = "remoteEndpointTB";
            this.remoteEndpointTB.Size = new System.Drawing.Size(351, 20);
            this.remoteEndpointTB.TabIndex = 9;
            // 
            // dbTypeCB
            // 
            this.dbTypeCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dbTypeCB.FormattingEnabled = true;
            this.dbTypeCB.Location = new System.Drawing.Point(654, 54);
            this.dbTypeCB.Name = "dbTypeCB";
            this.dbTypeCB.Size = new System.Drawing.Size(351, 21);
            this.dbTypeCB.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(651, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "choose the type of database:";
            // 
            // databaseRefreshBT
            // 
            this.databaseRefreshBT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.databaseRefreshBT.Location = new System.Drawing.Point(571, 6);
            this.databaseRefreshBT.Name = "databaseRefreshBT";
            this.databaseRefreshBT.Size = new System.Drawing.Size(77, 23);
            this.databaseRefreshBT.TabIndex = 1;
            this.databaseRefreshBT.Text = "refresh";
            this.databaseRefreshBT.UseVisualStyleBackColor = true;
            this.databaseRefreshBT.Click += new System.EventHandler(this.databaseRefreshBT_Click);
            // 
            // submitDbBT
            // 
            this.submitDbBT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.submitDbBT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.submitDbBT.Location = new System.Drawing.Point(0, 34);
            this.submitDbBT.Name = "submitDbBT";
            this.submitDbBT.Size = new System.Drawing.Size(648, 509);
            this.submitDbBT.TabIndex = 0;
            // 
            // EcaTabControl
            // 
            this.EcaTabControl.Controls.Add(this.atomicEventsTab);
            this.EcaTabControl.Controls.Add(this.ecaRulesTab);
            this.EcaTabControl.Location = new System.Drawing.Point(3, 3);
            this.EcaTabControl.Name = "EcaTabControl";
            this.EcaTabControl.SelectedIndex = 0;
            this.EcaTabControl.Size = new System.Drawing.Size(1008, 540);
            this.EcaTabControl.TabIndex = 1;
            // 
            // atomicEventsTab
            // 
            this.atomicEventsTab.Controls.Add(this.eventDefControl1);
            this.atomicEventsTab.Location = new System.Drawing.Point(4, 22);
            this.atomicEventsTab.Name = "atomicEventsTab";
            this.atomicEventsTab.Padding = new System.Windows.Forms.Padding(3);
            this.atomicEventsTab.Size = new System.Drawing.Size(1000, 514);
            this.atomicEventsTab.TabIndex = 0;
            this.atomicEventsTab.Text = "atomic events";
            this.atomicEventsTab.UseVisualStyleBackColor = true;
            // 
            // ecaRulesTab
            // 
            this.ecaRulesTab.Location = new System.Drawing.Point(4, 22);
            this.ecaRulesTab.Name = "ecaRulesTab";
            this.ecaRulesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ecaRulesTab.Size = new System.Drawing.Size(1000, 514);
            this.ecaRulesTab.TabIndex = 1;
            this.ecaRulesTab.Text = "ECA-Rules";
            this.ecaRulesTab.UseVisualStyleBackColor = true;
            // 
            // eventDefControl1
            // 
            this.eventDefControl1.Location = new System.Drawing.Point(1, 0);
            this.eventDefControl1.Name = "eventDefControl1";
            this.eventDefControl1.Size = new System.Drawing.Size(999, 514);
            this.eventDefControl1.TabIndex = 0;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 592);
            this.Controls.Add(this.mainTabControl);
            this.Name = "AdminForm";
            this.Text = "Form1";
            this.mainTabControl.ResumeLayout(false);
            this.LogInTab.ResumeLayout(false);
            this.LogInTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tripleDGV)).EndInit();
            this.UserAccTab.ResumeLayout(false);
            this.UserAccTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDGV)).EndInit();
            this.EcaDefTab.ResumeLayout(false);
            this.databaseTab.ResumeLayout(false);
            this.databaseTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.submitDbBT)).EndInit();
            this.EcaTabControl.ResumeLayout(false);
            this.atomicEventsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage LogInTab;
        private System.Windows.Forms.TabPage UserAccTab;
        private System.Windows.Forms.TabPage EcaDefTab;
        private System.Windows.Forms.Button loginBT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordTB;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage accountTab;
        private System.Windows.Forms.Button refreshBT;
        private System.Windows.Forms.DataGridView usersDGV;
        private System.Windows.Forms.Button deleteAccBT;
        private System.Windows.Forms.Button switchEventRightsBT;
        private System.Windows.Forms.Button switchAccRightBT;
        private System.Windows.Forms.Button resetPassBT;
        private System.Windows.Forms.Label accountLA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button newAccBT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView tripleDGV;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage databaseTab;
        private System.Windows.Forms.Button databaseRefreshBT;
        private System.Windows.Forms.DataGridView submitDbBT;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox dbDescribtionRTB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox graphUrisRTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox sparqlENdpointTB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox remoteEndpointTB;
        private System.Windows.Forms.ComboBox dbTypeCB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox registerAnswerRTB;
        private System.Windows.Forms.Panel ecaDefPanel;
        private System.Windows.Forms.TabControl EcaTabControl;
        private System.Windows.Forms.TabPage atomicEventsTab;
        private System.Windows.Forms.TabPage ecaRulesTab;
        private RdfEventClients_AdminTool.atomicEventControl eventDefControl1;
    }
}

