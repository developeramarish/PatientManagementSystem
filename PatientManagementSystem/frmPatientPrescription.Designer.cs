namespace PatientManagementSystem
{
    partial class frmPatientPrescription
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbPatientID = new System.Windows.Forms.ComboBox();
            this.cmbDoctorID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDrugs = new System.Windows.Forms.TextBox();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.txtReferral = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lstPatientPrescription = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnView = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dtPrescribedDate = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.OliveDrab;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::PatientManagementSystem.Properties.Resources.Untitled_210;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(734, 60);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cmbPatientID
            // 
            this.cmbPatientID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatientID.FormattingEnabled = true;
            this.cmbPatientID.Location = new System.Drawing.Point(99, 111);
            this.cmbPatientID.Name = "cmbPatientID";
            this.cmbPatientID.Size = new System.Drawing.Size(217, 21);
            this.cmbPatientID.TabIndex = 15;
            this.cmbPatientID.Tag = "Patient ID";
            // 
            // cmbDoctorID
            // 
            this.cmbDoctorID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctorID.FormattingEnabled = true;
            this.cmbDoctorID.Location = new System.Drawing.Point(99, 78);
            this.cmbDoctorID.Name = "cmbDoctorID";
            this.cmbDoctorID.Size = new System.Drawing.Size(216, 21);
            this.cmbDoctorID.TabIndex = 14;
            this.cmbDoctorID.Tag = "Doctor ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Patient ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Doctor ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Drugs:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Prescribed Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 319);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Referral:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Diagnosis:";
            // 
            // txtDrugs
            // 
            this.txtDrugs.Location = new System.Drawing.Point(99, 143);
            this.txtDrugs.Multiline = true;
            this.txtDrugs.Name = "txtDrugs";
            this.txtDrugs.Size = new System.Drawing.Size(217, 64);
            this.txtDrugs.TabIndex = 21;
            this.txtDrugs.Tag = "Drugs";
            this.txtDrugs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDrugs_KeyPress);
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Location = new System.Drawing.Point(99, 212);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(217, 64);
            this.txtDiagnosis.TabIndex = 22;
            this.txtDiagnosis.Tag = "Diagnosis";
            this.txtDiagnosis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDrugs_KeyPress);
            // 
            // txtReferral
            // 
            this.txtReferral.Location = new System.Drawing.Point(99, 308);
            this.txtReferral.Multiline = true;
            this.txtReferral.Name = "txtReferral";
            this.txtReferral.Size = new System.Drawing.Size(216, 64);
            this.txtReferral.TabIndex = 24;
            this.txtReferral.Tag = "Referral";
            this.txtReferral.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDrugs_KeyPress);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(100, 378);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 26);
            this.btnSubmit.TabIndex = 25;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lstPatientPrescription
            // 
            this.lstPatientPrescription.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lstPatientPrescription.FullRowSelect = true;
            this.lstPatientPrescription.GridLines = true;
            this.lstPatientPrescription.Location = new System.Drawing.Point(341, 78);
            this.lstPatientPrescription.Name = "lstPatientPrescription";
            this.lstPatientPrescription.Size = new System.Drawing.Size(381, 294);
            this.lstPatientPrescription.TabIndex = 26;
            this.lstPatientPrescription.UseCompatibleStateImageBehavior = false;
            this.lstPatientPrescription.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Doctor ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Patient ID";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Drugs";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Diagnosis";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Prescribed Date";
            this.columnHeader5.Width = 66;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Referral";
            this.columnHeader6.Width = 74;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(341, 378);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 26);
            this.btnView.TabIndex = 27;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(422, 379);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 25);
            this.btnUpdate.TabIndex = 29;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dtPrescribedDate
            // 
            this.dtPrescribedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPrescribedDate.Location = new System.Drawing.Point(99, 283);
            this.dtPrescribedDate.Name = "dtPrescribedDate";
            this.dtPrescribedDate.Size = new System.Drawing.Size(216, 20);
            this.dtPrescribedDate.TabIndex = 31;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(503, 378);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmPatientPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(734, 451);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dtPrescribedDate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lstPatientPrescription);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtReferral);
            this.Controls.Add(this.txtDiagnosis);
            this.Controls.Add(this.txtDrugs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPatientID);
            this.Controls.Add(this.cmbDoctorID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmPatientPrescription";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient Prescription";
            this.Load += new System.EventHandler(this.frmPatientPrescription_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbPatientID;
        private System.Windows.Forms.ComboBox cmbDoctorID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDrugs;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.TextBox txtReferral;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ListView lstPatientPrescription;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DateTimePicker dtPrescribedDate;
        private System.Windows.Forms.Button btnDelete;
    }
}