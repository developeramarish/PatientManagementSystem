namespace PatientManagementSystem
{
    partial class frmVisitorsRegistration
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
            this.txtPhoneNo = new System.Windows.Forms.MaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.cmbPatientID = new System.Windows.Forms.ComboBox();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtOccupation = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtGNames = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVisitorsTagID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(112, 223);
            this.txtPhoneNo.Mask = "9999-999-9999";
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(227, 20);
            this.txtPhoneNo.TabIndex = 4;
            this.txtPhoneNo.Tag = "Phone No.";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 363);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 52);
            this.panel1.TabIndex = 39;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(34, 15);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(95, 23);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(358, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Patient\'s Picture";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.OliveDrab;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = global::PatientManagementSystem.Properties.Resources.Untitled_210;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(485, 67);
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(362, 112);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(86, 99);
            this.picImage.TabIndex = 37;
            this.picImage.TabStop = false;
            this.picImage.Tag = "Image";
            // 
            // cmbPatientID
            // 
            this.cmbPatientID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatientID.FormattingEnabled = true;
            this.cmbPatientID.Location = new System.Drawing.Point(112, 127);
            this.cmbPatientID.Name = "cmbPatientID";
            this.cmbPatientID.Size = new System.Drawing.Size(227, 21);
            this.cmbPatientID.TabIndex = 1;
            this.cmbPatientID.Tag = "Patient ID";
            this.cmbPatientID.SelectedIndexChanged += new System.EventHandler(this.cmbPatientID_SelectedIndexChanged);
            // 
            // cmbSex
            // 
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.cmbSex.Location = new System.Drawing.Point(112, 287);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(227, 21);
            this.cmbSex.TabIndex = 6;
            this.cmbSex.Tag = "Tag";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(112, 319);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(227, 20);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.Tag = "Email Address";
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtOccupation
            // 
            this.txtOccupation.Location = new System.Drawing.Point(112, 255);
            this.txtOccupation.Name = "txtOccupation";
            this.txtOccupation.Size = new System.Drawing.Size(227, 20);
            this.txtOccupation.TabIndex = 5;
            this.txtOccupation.Tag = "Occupation";
            this.txtOccupation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGNames_KeyPress);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(112, 191);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(227, 20);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.Tag = "Address";
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGNames_KeyPress);
            // 
            // txtGNames
            // 
            this.txtGNames.Location = new System.Drawing.Point(112, 159);
            this.txtGNames.Name = "txtGNames";
            this.txtGNames.Size = new System.Drawing.Size(227, 20);
            this.txtGNames.TabIndex = 2;
            this.txtGNames.Tag = "Guardian Names";
            this.txtGNames.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGNames_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Email Address:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Sex:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Occupation:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Phone No.:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Guardian Names:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Patient ID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Visitors Tag ID:";
            // 
            // txtVisitorsTagID
            // 
            this.txtVisitorsTagID.Location = new System.Drawing.Point(112, 96);
            this.txtVisitorsTagID.Name = "txtVisitorsTagID";
            this.txtVisitorsTagID.Size = new System.Drawing.Size(227, 20);
            this.txtVisitorsTagID.TabIndex = 0;
            // 
            // frmVisitorsRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(485, 415);
            this.Controls.Add(this.txtVisitorsTagID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPhoneNo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.cmbPatientID);
            this.Controls.Add(this.cmbSex);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtOccupation);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtGNames);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmVisitorsRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visitors Registration";
            this.Load += new System.EventHandler(this.frmVisitorsRegistration_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtPhoneNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.ComboBox cmbPatientID;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtOccupation;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtGNames;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVisitorsTagID;
    }
}