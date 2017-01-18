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
    public partial class frmAppointReport : Form
    {
        public frmAppointReport()
        {
            InitializeComponent();
        }

        private void frmAppointReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'PatientMgtSystemAppointment.DoctorsAppointment' table. You can move, or remove it, as needed.
            this.DoctorsAppointmentTableAdapter.Fill(this.PatientMgtSystemAppointment.DoctorsAppointment);

            this.reportViewer1.RefreshReport();
        }
    }
}
