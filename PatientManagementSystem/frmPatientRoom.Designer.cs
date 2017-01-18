namespace PatientManagementSystem
{
    partial class frmPatientRoom
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPatientID = new System.Windows.Forms.ComboBox();
            this.txtPatientNames = new System.Windows.Forms.TextBox();
            this.cmbWardID = new System.Windows.Forms.ComboBox();
            this.cmbWardType = new System.Windows.Forms.ComboBox();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.cmbRoomNo = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.dtDateAdmitted = new System.Windows.Forms.DateTimePicker();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.patientRoomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patientMgtSystemDataSet = new PatientManagementSystem.PatientMgtSystemDataSet();
            this.patientRoomTableAdapter = new PatientManagementSystem.PatientMgtSystemDataSetTableAdapters.PatientRoomTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientRoomBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientMgtSystemDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.OliveDrab;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::PatientManagementSystem.Properties.Resources.Untitled_210;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(685, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Patient ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Patient Full Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ward ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ward Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Room Type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Room No.: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Price:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Date Admitted:";
            // 
            // cmbPatientID
            // 
            this.cmbPatientID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPatientID.FormattingEnabled = true;
            this.cmbPatientID.Location = new System.Drawing.Point(111, 94);
            this.cmbPatientID.Name = "cmbPatientID";
            this.cmbPatientID.Size = new System.Drawing.Size(230, 21);
            this.cmbPatientID.TabIndex = 16;
            this.cmbPatientID.Tag = "Patient ID";
            this.cmbPatientID.SelectedIndexChanged += new System.EventHandler(this.cmbPatientID_SelectedIndexChanged);
            // 
            // txtPatientNames
            // 
            this.txtPatientNames.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPatientNames.Location = new System.Drawing.Point(111, 123);
            this.txtPatientNames.Name = "txtPatientNames";
            this.txtPatientNames.Size = new System.Drawing.Size(231, 20);
            this.txtPatientNames.TabIndex = 17;
            this.txtPatientNames.Tag = "Full Name";
            // 
            // cmbWardID
            // 
            this.cmbWardID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWardID.FormattingEnabled = true;
            this.cmbWardID.Location = new System.Drawing.Point(111, 152);
            this.cmbWardID.Name = "cmbWardID";
            this.cmbWardID.Size = new System.Drawing.Size(230, 21);
            this.cmbWardID.TabIndex = 18;
            this.cmbWardID.Tag = "Ward ID:";
            this.cmbWardID.SelectedIndexChanged += new System.EventHandler(this.cmbWardID_SelectedIndexChanged);
            // 
            // cmbWardType
            // 
            this.cmbWardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWardType.FormattingEnabled = true;
            this.cmbWardType.Location = new System.Drawing.Point(111, 181);
            this.cmbWardType.Name = "cmbWardType";
            this.cmbWardType.Size = new System.Drawing.Size(231, 21);
            this.cmbWardType.TabIndex = 19;
            this.cmbWardType.Tag = "Ward Type ";
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(111, 210);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(231, 21);
            this.cmbRoomType.TabIndex = 20;
            this.cmbRoomType.Tag = "Room Type";
            this.cmbRoomType.SelectedIndexChanged += new System.EventHandler(this.cmbRoomType_SelectedIndexChanged);
            // 
            // cmbRoomNo
            // 
            this.cmbRoomNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomNo.FormattingEnabled = true;
            this.cmbRoomNo.Location = new System.Drawing.Point(111, 239);
            this.cmbRoomNo.Name = "cmbRoomNo";
            this.cmbRoomNo.Size = new System.Drawing.Size(231, 21);
            this.cmbRoomNo.TabIndex = 21;
            this.cmbRoomNo.Tag = "Room No";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(111, 268);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(231, 20);
            this.txtPrice.TabIndex = 22;
            this.txtPrice.Tag = "Price";
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // dtDateAdmitted
            // 
            this.dtDateAdmitted.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateAdmitted.Location = new System.Drawing.Point(111, 297);
            this.dtDateAdmitted.Name = "dtDateAdmitted";
            this.dtDateAdmitted.Size = new System.Drawing.Size(231, 20);
            this.dtDateAdmitted.TabIndex = 23;
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(360, 94);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(95, 108);
            this.picImage.TabIndex = 24;
            this.picImage.TabStop = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(15, 528);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 40;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(15, 340);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 182);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Patients Admitted";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.Column2});
            this.dataGridView1.DataSource = this.patientRoomBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(652, 163);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PatientID";
            this.dataGridViewTextBoxColumn1.HeaderText = "PID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 21;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FullName";
            this.dataGridViewTextBoxColumn2.HeaderText = "FullName";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 21;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "WardID";
            this.dataGridViewTextBoxColumn3.HeaderText = "WID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 21;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "WardType";
            this.dataGridViewTextBoxColumn4.HeaderText = "WT";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 21;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "RoomType";
            this.dataGridViewTextBoxColumn5.HeaderText = "RT";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 21;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "RoomNo";
            this.dataGridViewTextBoxColumn6.HeaderText = "RNo";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 21;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Price";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn7.HeaderText = "Price";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 21;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DateAdmitted";
            this.dataGridViewTextBoxColumn8.HeaderText = "Date";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 21;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "PatientID";
            this.Column2.HeaderText = "Discharge";
            this.Column2.Name = "Column2";
            this.Column2.Text = "Discharge";
            this.Column2.UseColumnTextForButtonValue = true;
            this.Column2.Width = 21;
            // 
            // patientRoomBindingSource
            // 
            this.patientRoomBindingSource.DataMember = "PatientRoom";
            this.patientRoomBindingSource.DataSource = this.patientMgtSystemDataSet;
            // 
            // patientMgtSystemDataSet
            // 
            this.patientMgtSystemDataSet.DataSetName = "PatientMgtSystemDataSet";
            this.patientMgtSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // patientRoomTableAdapter
            // 
            this.patientRoomTableAdapter.ClearBeforeFill = true;
            // 
            // frmPatientRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(685, 563);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.dtDateAdmitted);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.cmbRoomNo);
            this.Controls.Add(this.cmbRoomType);
            this.Controls.Add(this.cmbWardType);
            this.Controls.Add(this.cmbWardID);
            this.Controls.Add(this.txtPatientNames);
            this.Controls.Add(this.cmbPatientID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "frmPatientRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient Room";
            this.Load += new System.EventHandler(this.frmPatientRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientRoomBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patientMgtSystemDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbPatientID;
        private System.Windows.Forms.TextBox txtPatientNames;
        private System.Windows.Forms.ComboBox cmbWardID;
        private System.Windows.Forms.ComboBox cmbWardType;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.ComboBox cmbRoomNo;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.DateTimePicker dtDateAdmitted;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnSubmit;
        //private PatientMgtSystemDataSet1 patientMgtSystemDataSet1;
        //private PatientMgtSystemDataSet1TableAdapters.PatientRoomTableAdapter patientRoomTableAdapter1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn patientIDDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn wardIDDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn wardTypeDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn roomTypeDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn roomNoDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn dateAdmittedDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewImageColumn imageDataGridViewImageColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private PatientMgtSystemDataSet patientMgtSystemDataSet;
        private System.Windows.Forms.BindingSource patientRoomBindingSource;
        private PatientMgtSystemDataSetTableAdapters.PatientRoomTableAdapter patientRoomTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
    }
}