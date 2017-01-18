namespace PatientManagementSystem
{
    partial class frmPriviledges
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
            this.LstUsers = new System.Windows.Forms.ListBox();
            this.btnSetAccess = new System.Windows.Forms.Button();
            this.chkListbox = new System.Windows.Forms.CheckedListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LstUsers
            // 
            this.LstUsers.FormattingEnabled = true;
            this.LstUsers.Location = new System.Drawing.Point(12, 26);
            this.LstUsers.Name = "LstUsers";
            this.LstUsers.Size = new System.Drawing.Size(120, 238);
            this.LstUsers.TabIndex = 0;
            this.LstUsers.SelectedIndexChanged += new System.EventHandler(this.LstUsers_SelectedIndexChanged);
            // 
            // btnSetAccess
            // 
            this.btnSetAccess.BackColor = System.Drawing.Color.Transparent;
            this.btnSetAccess.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSetAccess.Location = new System.Drawing.Point(92, 277);
            this.btnSetAccess.Name = "btnSetAccess";
            this.btnSetAccess.Size = new System.Drawing.Size(75, 27);
            this.btnSetAccess.TabIndex = 1;
            this.btnSetAccess.Text = "SetAccess";
            this.btnSetAccess.UseVisualStyleBackColor = false;
            this.btnSetAccess.Click += new System.EventHandler(this.btnSetAccess_Click);
            // 
            // chkListbox
            // 
            this.chkListbox.FormattingEnabled = true;
            this.chkListbox.Items.AddRange(new object[] {
            "Registration",
            "Administrator",
            "Patients",
            "Bills & Invoices",
            "Appointments",
            "Admissions",
            "Visitors",
            "Reports"});
            this.chkListbox.Location = new System.Drawing.Point(14, 32);
            this.chkListbox.Name = "chkListbox";
            this.chkListbox.Size = new System.Drawing.Size(146, 229);
            this.chkListbox.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.splitContainer1.Panel1.Controls.Add(this.LstUsers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.splitContainer1.Panel2.Controls.Add(this.btnSetAccess);
            this.splitContainer1.Panel2.Controls.Add(this.chkListbox);
            this.splitContainer1.Size = new System.Drawing.Size(334, 316);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.TabIndex = 2;
            // 
            // frmPriviledges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 316);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmPriviledges";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Priviledges";
            this.Load += new System.EventHandler(this.frmPriviledges_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LstUsers;
        private System.Windows.Forms.Button btnSetAccess;
        private System.Windows.Forms.CheckedListBox chkListbox;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}