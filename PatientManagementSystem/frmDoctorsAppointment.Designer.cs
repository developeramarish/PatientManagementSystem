namespace PatientManagementSystem
{
    partial class frmDoctorsAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoctorsAppointment));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mskTimeOut = new System.Windows.Forms.DateTimePicker();
            this.mskTimeIn = new System.Windows.Forms.DateTimePicker();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.cmbPatientID = new System.Windows.Forms.ComboBox();
            this.cmbDoctorID = new System.Windows.Forms.ComboBox();
            this.mthAppointmentDate = new System.Windows.Forms.MonthCalendar();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstAppointment = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mskTimeOut);
            this.groupBox1.Controls.Add(this.mskTimeIn);
            this.groupBox1.Controls.Add(this.picImage);
            this.groupBox1.Controls.Add(this.cmbPatientID);
            this.groupBox1.Controls.Add(this.cmbDoctorID);
            this.groupBox1.Controls.Add(this.mthAppointmentDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 319);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doctor\'s Appointment";
            // 
            // mskTimeOut
            // 
            this.mskTimeOut.CustomFormat = "";
            this.mskTimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.mskTimeOut.Location = new System.Drawing.Point(268, 266);
            this.mskTimeOut.Name = "mskTimeOut";
            this.mskTimeOut.ShowUpDown = true;
            this.mskTimeOut.Size = new System.Drawing.Size(88, 20);
            this.mskTimeOut.TabIndex = 16;
            this.mskTimeOut.Value = new System.DateTime(2014, 7, 6, 0, 9, 0, 0);
            // 
            // mskTimeIn
            // 
            this.mskTimeIn.CustomFormat = "";
            this.mskTimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.mskTimeIn.Location = new System.Drawing.Point(129, 266);
            this.mskTimeIn.Name = "mskTimeIn";
            this.mskTimeIn.ShowUpDown = true;
            this.mskTimeIn.Size = new System.Drawing.Size(88, 20);
            this.mskTimeIn.TabIndex = 15;
            this.mskTimeIn.Value = new System.DateTime(2014, 7, 6, 0, 9, 0, 0);
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(372, 34);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(89, 100);
            this.picImage.TabIndex = 14;
            this.picImage.TabStop = false;
            // 
            // cmbPatientID
            // 
            this.cmbPatientID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatientID.FormattingEnabled = true;
            this.cmbPatientID.Location = new System.Drawing.Point(129, 66);
            this.cmbPatientID.Name = "cmbPatientID";
            this.cmbPatientID.Size = new System.Drawing.Size(227, 21);
            this.cmbPatientID.TabIndex = 11;
            // 
            // cmbDoctorID
            // 
            this.cmbDoctorID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctorID.FormattingEnabled = true;
            this.cmbDoctorID.Location = new System.Drawing.Point(129, 33);
            this.cmbDoctorID.Name = "cmbDoctorID";
            this.cmbDoctorID.Size = new System.Drawing.Size(227, 21);
            this.cmbDoctorID.TabIndex = 10;
            this.cmbDoctorID.SelectedIndexChanged += new System.EventHandler(this.cmbDoctorID_SelectedIndexChanged);
            // 
            // mthAppointmentDate
            // 
            this.mthAppointmentDate.Location = new System.Drawing.Point(129, 99);
            this.mthAppointmentDate.MaxDate = new System.DateTime(2016, 12, 31, 0, 0, 0, 0);
            this.mthAppointmentDate.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.mthAppointmentDate.Name = "mthAppointmentDate";
            this.mthAppointmentDate.TabIndex = 9;
            this.mthAppointmentDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mthAppointmentDate_DateChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(215, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Time Out:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Appointment Time In:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Appointment Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Patient ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doctor ID:";
            // 
            // lstAppointment
            // 
            this.lstAppointment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstAppointment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstAppointment.Location = new System.Drawing.Point(496, 97);
            this.lstAppointment.Name = "lstAppointment";
            this.lstAppointment.Size = new System.Drawing.Size(280, 319);
            this.lstAppointment.TabIndex = 2;
            this.lstAppointment.UseCompatibleStateImageBehavior = false;
            this.lstAppointment.View = System.Windows.Forms.View.Details;
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
            this.columnHeader3.Text = "Date";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Time In";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Time Out";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(384, 422);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(106, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.OliveDrab;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::PatientManagementSystem.Properties.Resources.Untitled_25;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(788, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmDoctorsAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(788, 455);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lstAppointment);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDoctorsAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doctors Appointment";
            this.Load += new System.EventHandler(this.frmDoctorsAppointment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbPatientID;
        private System.Windows.Forms.ComboBox cmbDoctorID;
        private System.Windows.Forms.MonthCalendar mthAppointmentDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.ListView lstAppointment;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.DateTimePicker mskTimeIn;
        private System.Windows.Forms.DateTimePicker mskTimeOut;
        private System.Windows.Forms.Button btnSubmit;
    }
}