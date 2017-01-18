namespace PatientManagementSystem
{
    partial class frmPatientReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PatientMgtSystemPatientReport = new PatientManagementSystem.PatientMgtSystemPatientReport();
            this.PatientRegistrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PatientRegistrationTableAdapter = new PatientManagementSystem.PatientMgtSystemPatientReportTableAdapters.PatientRegistrationTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PatientMgtSystemPatientReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientRegistrationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "patientReport";
            reportDataSource1.Value = this.PatientRegistrationBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PatientManagementSystem.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(920, 525);
            this.reportViewer1.TabIndex = 0;
            // 
            // PatientMgtSystemPatientReport
            // 
            this.PatientMgtSystemPatientReport.DataSetName = "PatientMgtSystemPatientReport";
            this.PatientMgtSystemPatientReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PatientRegistrationBindingSource
            // 
            this.PatientRegistrationBindingSource.DataMember = "PatientRegistration";
            this.PatientRegistrationBindingSource.DataSource = this.PatientMgtSystemPatientReport;
            // 
            // PatientRegistrationTableAdapter
            // 
            this.PatientRegistrationTableAdapter.ClearBeforeFill = true;
            // 
            // frmPatientReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 525);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmPatientReport";
            this.Text = "frmPatientReport";
            this.Load += new System.EventHandler(this.frmPatientReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PatientMgtSystemPatientReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientRegistrationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PatientRegistrationBindingSource;
        private PatientMgtSystemPatientReport PatientMgtSystemPatientReport;
        private PatientMgtSystemPatientReportTableAdapters.PatientRegistrationTableAdapter PatientRegistrationTableAdapter;
    }
}