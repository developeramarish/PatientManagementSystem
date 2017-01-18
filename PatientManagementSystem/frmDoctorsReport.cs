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
    public partial class frmDoctorsReport : Form
    {
        public frmDoctorsReport()
        {
            InitializeComponent();
        }

        private void frmDoctorsReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DoctorInfoDataSet.DoctorRegistration' table. You can move, or remove it, as needed.
            this.DoctorRegistrationTableAdapter.Fill(this.DoctorInfoDataSet.DoctorRegistration);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
