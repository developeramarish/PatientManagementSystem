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
    public partial class frmVisitorReport : Form
    {
        public frmVisitorReport()
        {
            InitializeComponent();
        }

        private void frmVisitorReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PatientMgtSystemVisitor.VisitorsRegistration' table. You can move, or remove it, as needed.
            this.VisitorsRegistrationTableAdapter.Fill(this.PatientMgtSystemVisitor.VisitorsRegistration);

            this.reportViewer1.RefreshReport();
        }
    }
}
