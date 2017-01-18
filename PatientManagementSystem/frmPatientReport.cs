using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PatientManagementSystem
{
    public partial class frmPatientReport : Form
    {
        public frmPatientReport()
        {
            InitializeComponent();
        }

        private void frmPatientReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PatientMgtSystemPatientReport.PatientRegistration' table. You can move, or remove it, as needed.
            this.PatientRegistrationTableAdapter.Fill(this.PatientMgtSystemPatientReport.PatientRegistration);

            this.reportViewer1.RefreshReport();
        }
    }
}
