namespace PatientManagementSystem
{
    partial class frmVisitorReport
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
            this.PatientMgtSystemVisitor = new PatientManagementSystem.PatientMgtSystemVisitor();
            this.VisitorsRegistrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VisitorsRegistrationTableAdapter = new PatientManagementSystem.PatientMgtSystemVisitorTableAdapters.VisitorsRegistrationTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PatientMgtSystemVisitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisitorsRegistrationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "visitorReport";
            reportDataSource1.Value = this.VisitorsRegistrationBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PatientManagementSystem.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(804, 562);
            this.reportViewer1.TabIndex = 0;
            // 
            // PatientMgtSystemVisitor
            // 
            this.PatientMgtSystemVisitor.DataSetName = "PatientMgtSystemVisitor";
            this.PatientMgtSystemVisitor.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VisitorsRegistrationBindingSource
            // 
            this.VisitorsRegistrationBindingSource.DataMember = "VisitorsRegistration";
            this.VisitorsRegistrationBindingSource.DataSource = this.PatientMgtSystemVisitor;
            // 
            // VisitorsRegistrationTableAdapter
            // 
            this.VisitorsRegistrationTableAdapter.ClearBeforeFill = true;
            // 
            // frmVisitorReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 562);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmVisitorReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visitor Report";
            this.Load += new System.EventHandler(this.frmVisitorReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PatientMgtSystemVisitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisitorsRegistrationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource VisitorsRegistrationBindingSource;
        private PatientMgtSystemVisitor PatientMgtSystemVisitor;
        private PatientMgtSystemVisitorTableAdapters.VisitorsRegistrationTableAdapter VisitorsRegistrationTableAdapter;
    }
}