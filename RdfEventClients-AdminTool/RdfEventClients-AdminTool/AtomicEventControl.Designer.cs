namespace RdfEventClients_AdminTool
{
    partial class atomicEventControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.atomicEventsDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.createEventBT = new System.Windows.Forms.Button();
            this.chooseDbCB = new System.Windows.Forms.ComboBox();
            this.chooseEventCatCB = new System.Windows.Forms.ComboBox();
            this.registerEventBT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.atomicEventsDGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // atomicEventsDGV
            // 
            this.atomicEventsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.atomicEventsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.atomicEventsDGV.Location = new System.Drawing.Point(0, 24);
            this.atomicEventsDGV.Name = "atomicEventsDGV";
            this.atomicEventsDGV.Size = new System.Drawing.Size(772, 260);
            this.atomicEventsDGV.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "registered atomic events";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "atomic event details";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 287);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 180);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.registerEventBT);
            this.panel2.Controls.Add(this.chooseEventCatCB);
            this.panel2.Controls.Add(this.chooseDbCB);
            this.panel2.Controls.Add(this.createEventBT);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(489, 287);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 180);
            this.panel2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "create or register new atomic events";
            // 
            // createEventBT
            // 
            this.createEventBT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createEventBT.BackColor = System.Drawing.SystemColors.Control;
            this.createEventBT.Location = new System.Drawing.Point(3, 108);
            this.createEventBT.Name = "createEventBT";
            this.createEventBT.Size = new System.Drawing.Size(277, 23);
            this.createEventBT.TabIndex = 5;
            this.createEventBT.Text = "create new event";
            this.createEventBT.UseVisualStyleBackColor = false;
            this.createEventBT.Click += new System.EventHandler(this.createEventBT_Click);
            // 
            // chooseDbCB
            // 
            this.chooseDbCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseDbCB.FormattingEnabled = true;
            this.chooseDbCB.Location = new System.Drawing.Point(6, 63);
            this.chooseDbCB.Name = "chooseDbCB";
            this.chooseDbCB.Size = new System.Drawing.Size(274, 21);
            this.chooseDbCB.TabIndex = 7;
            this.chooseDbCB.Text = "choose the database where this event occures";
            // 
            // chooseEventCatCB
            // 
            this.chooseEventCatCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseEventCatCB.FormattingEnabled = true;
            this.chooseEventCatCB.Items.AddRange(new object[] {
            "new trigger on a database-table",
            "new trigger for RDF-triples",
            "an external event (any other event)"});
            this.chooseEventCatCB.Location = new System.Drawing.Point(6, 36);
            this.chooseEventCatCB.Name = "chooseEventCatCB";
            this.chooseEventCatCB.Size = new System.Drawing.Size(274, 21);
            this.chooseEventCatCB.TabIndex = 8;
            this.chooseEventCatCB.Text = "choose the type of atomic event you want to add";
            // 
            // registerEventBT
            // 
            this.registerEventBT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.registerEventBT.BackColor = System.Drawing.SystemColors.Control;
            this.registerEventBT.Location = new System.Drawing.Point(3, 137);
            this.registerEventBT.Name = "registerEventBT";
            this.registerEventBT.Size = new System.Drawing.Size(277, 23);
            this.registerEventBT.TabIndex = 9;
            this.registerEventBT.Text = "register new event";
            this.registerEventBT.UseVisualStyleBackColor = false;
            // 
            // atomicEventControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.atomicEventsDGV);
            this.Name = "atomicEventControl";
            this.Size = new System.Drawing.Size(772, 470);
            ((System.ComponentModel.ISupportInitialize)(this.atomicEventsDGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView atomicEventsDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button registerEventBT;
        private System.Windows.Forms.ComboBox chooseEventCatCB;
        private System.Windows.Forms.ComboBox chooseDbCB;
        private System.Windows.Forms.Button createEventBT;
        private System.Windows.Forms.Label label3;


    }
}
