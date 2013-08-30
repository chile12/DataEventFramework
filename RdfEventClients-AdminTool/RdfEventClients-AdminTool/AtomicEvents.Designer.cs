namespace RdfEventClients_AdminTool
{
    partial class AtomicEvents
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
            this.dbSelectCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sqlRdfSelectCB = new System.Windows.Forms.ComboBox();
            this.tableSelectCB = new System.Windows.Forms.ComboBox();
            this.tableSelectLA = new System.Windows.Forms.Label();
            this.manualTriggerDisclaimerLA = new System.Windows.Forms.Label();
            this.registerTriggerBT = new System.Windows.Forms.Button();
            this.triggerSelectCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dbSelectCB
            // 
            this.dbSelectCB.FormattingEnabled = true;
            this.dbSelectCB.Location = new System.Drawing.Point(12, 30);
            this.dbSelectCB.Name = "dbSelectCB";
            this.dbSelectCB.Size = new System.Drawing.Size(692, 21);
            this.dbSelectCB.TabIndex = 0;
            this.dbSelectCB.SelectedIndexChanged += new System.EventHandler(this.dbSelectCB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose the database you wish to creat an atomic event (trigger) for:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select the type of datasource:";
            // 
            // sqlRdfSelectCB
            // 
            this.sqlRdfSelectCB.FormattingEnabled = true;
            this.sqlRdfSelectCB.Items.AddRange(new object[] {
            "Virtuoso Triple-Store",
            "Virtuoso Database"});
            this.sqlRdfSelectCB.Location = new System.Drawing.Point(12, 82);
            this.sqlRdfSelectCB.Name = "sqlRdfSelectCB";
            this.sqlRdfSelectCB.Size = new System.Drawing.Size(184, 21);
            this.sqlRdfSelectCB.TabIndex = 3;
            this.sqlRdfSelectCB.SelectedIndexChanged += new System.EventHandler(this.sqlRdfSelectCB_SelectedIndexChanged);
            // 
            // tableSelectCB
            // 
            this.tableSelectCB.FormattingEnabled = true;
            this.tableSelectCB.Location = new System.Drawing.Point(268, 82);
            this.tableSelectCB.Name = "tableSelectCB";
            this.tableSelectCB.Size = new System.Drawing.Size(436, 21);
            this.tableSelectCB.TabIndex = 4;
            this.tableSelectCB.SelectedIndexChanged += new System.EventHandler(this.tableSelectCB_SelectedIndexChanged);
            // 
            // tableSelectLA
            // 
            this.tableSelectLA.AutoSize = true;
            this.tableSelectLA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableSelectLA.Location = new System.Drawing.Point(265, 63);
            this.tableSelectLA.Name = "tableSelectLA";
            this.tableSelectLA.Size = new System.Drawing.Size(335, 16);
            this.tableSelectLA.TabIndex = 5;
            this.tableSelectLA.Text = "Select the database-table to create an atomic event for:";
            // 
            // manualTriggerDisclaimerLA
            // 
            this.manualTriggerDisclaimerLA.AutoSize = true;
            this.manualTriggerDisclaimerLA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualTriggerDisclaimerLA.Location = new System.Drawing.Point(12, 145);
            this.manualTriggerDisclaimerLA.Name = "manualTriggerDisclaimerLA";
            this.manualTriggerDisclaimerLA.Size = new System.Drawing.Size(663, 16);
            this.manualTriggerDisclaimerLA.TabIndex = 6;
            this.manualTriggerDisclaimerLA.Text = "To create atomic events on normal tables please manually create trigger for those" +
    " tables an register them here:";
            // 
            // registerTriggerBT
            // 
            this.registerTriggerBT.Location = new System.Drawing.Point(431, 173);
            this.registerTriggerBT.Name = "registerTriggerBT";
            this.registerTriggerBT.Size = new System.Drawing.Size(169, 20);
            this.registerTriggerBT.TabIndex = 8;
            this.registerTriggerBT.Text = "register new trigger";
            this.registerTriggerBT.UseVisualStyleBackColor = true;
            this.registerTriggerBT.Click += new System.EventHandler(this.registerTriggerBT_Click);
            // 
            // triggerSelectCB
            // 
            this.triggerSelectCB.FormattingEnabled = true;
            this.triggerSelectCB.Items.AddRange(new object[] {
            "Virtuoso Triple-Store",
            "Virtuoso Database"});
            this.triggerSelectCB.Location = new System.Drawing.Point(12, 174);
            this.triggerSelectCB.Name = "triggerSelectCB";
            this.triggerSelectCB.Size = new System.Drawing.Size(344, 21);
            this.triggerSelectCB.TabIndex = 9;
            // 
            // AtomicEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 589);
            this.Controls.Add(this.triggerSelectCB);
            this.Controls.Add(this.registerTriggerBT);
            this.Controls.Add(this.manualTriggerDisclaimerLA);
            this.Controls.Add(this.tableSelectLA);
            this.Controls.Add(this.tableSelectCB);
            this.Controls.Add(this.sqlRdfSelectCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dbSelectCB);
            this.Name = "AtomicEvents";
            this.Text = "AtomicEvents";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox dbSelectCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sqlRdfSelectCB;
        private System.Windows.Forms.ComboBox tableSelectCB;
        private System.Windows.Forms.Label tableSelectLA;
        private System.Windows.Forms.Label manualTriggerDisclaimerLA;
        private System.Windows.Forms.Button registerTriggerBT;
        private System.Windows.Forms.ComboBox triggerSelectCB;
    }
}