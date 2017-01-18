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
    public partial class frmGuardianReport : Form
    {
        public frmGuardianReport()
        {
            InitializeComponent();
        }

        private void frmGuardianReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PatientMgtSystemDataSet2.GuardianRegistration' table. You can move, or remove it, as needed.
            this.GuardianRegistrationTableAdapter.Fill(this.PatientMgtSystemDataSet2.GuardianRegistration);

            this.reportViewer1.RefreshReport();
        }
    }
}
