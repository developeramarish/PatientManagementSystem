using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PatientManagementSystem
{
    public partial class frmIndexForm : Form
    {
        public string username;
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;
        public frmIndexForm()
        {
            InitializeComponent();
        }

        private void frmIndexForm_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - Index Form";
            string select = "SELECT *FROM Priviledges WHERE Username='" + username + "'";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            if (dr.GetValue(1).ToString() == "0")
                                menuRegistration.Visible = false;
                            else
                                menuRegistration.Visible = true;
                            if (dr.GetValue(2).ToString() == "0")
                                menuAdministrator.Visible = false;
                            else
                                menuAdministrator.Visible = true;
                            if (dr.GetValue(3).ToString() == "0")
                                menuPatients.Visible = false;
                            else
                                menuPatients.Visible = true;
                            if (dr.GetValue(4).ToString() == "0")
                                menuBillInvoice.Visible = false;
                            else
                                menuBillInvoice.Visible = true;
                            if (dr.GetValue(5).ToString() == "0")
                                menuAppointments.Visible = false;
                            else
                                menuAppointments.Visible = true;
                            if (dr.GetValue(6).ToString() == "0")
                                menuAdmission.Visible = false;
                            else
                                menuAdmission.Visible = true;
                            if (dr.GetValue(7).ToString() == "0")
                                menuVisitors.Visible = false;
                            else
                                menuVisitors.Visible = true;
                            if (dr.GetValue(8).ToString() == "0")
                                menuReports.Visible = false;
                            else
                                menuReports.Visible = true;
                        }
                    }
                }
            }
        }

        frmLogin login;
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            login = new frmLogin();
            login.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        frmDoctorRegistration doctorReg;
        private void tsMenuDoctors_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form a = this.ActiveMdiChild;
            //a.Show();

            if (doctorReg == null)
            {
                doctorReg = new frmDoctorRegistration();
                doctorReg.MdiParent = this;
                doctorReg.FormClosed += new FormClosedEventHandler(doctorReg_FormClosed);
                doctorReg.Show();
            }
            else
            {
                doctorReg.Activate();
                doctorReg.WindowState = FormWindowState.Normal;
            }
               
        }

        void doctorReg_FormClosed(object sender, FormClosedEventArgs e)
        {
            doctorReg = null;
        }

        frmPatientRegistration patientReg;
        private void tsMenuPatients_Click(object sender, EventArgs e)
        {
            if (patientReg == null)
            {
                patientReg = new frmPatientRegistration();
                patientReg.MdiParent = this;
                patientReg.FormClosed += new FormClosedEventHandler(patientReg_FormClosed);
                patientReg.Show();
            }
            else
            {
                patientReg.Activate();
                patientReg.WindowState = FormWindowState.Normal;
            }
        }

        void patientReg_FormClosed(object sender, FormClosedEventArgs e)
        {
            patientReg = null;
        }

        frmGuardianRegistration guardianReg;
        private void tsMenuGuardians_Click(object sender, EventArgs e)
        {            
            if (guardianReg == null)
            {
                guardianReg = new frmGuardianRegistration();
                guardianReg.MdiParent = this;
                guardianReg.FormClosed += new FormClosedEventHandler(guardianReg_FormClosed);
                guardianReg.Show();
            }
            else
            {
                guardianReg.Activate();
                guardianReg.WindowState = FormWindowState.Normal;
            }
        }

        void guardianReg_FormClosed(object sender, FormClosedEventArgs e)
        {
            guardianReg = null;
        }

        frmCreateUsers creatUsers;
        private void tsMenuCreateUsers_Click(object sender, EventArgs e)
        {
            if (creatUsers == null)
            {
                creatUsers = new frmCreateUsers();
                creatUsers.MdiParent = this;
                creatUsers.FormClosed += new FormClosedEventHandler(creatUsers_FormClosed);
                creatUsers.Show();
            }
            else
            {
                creatUsers.Activate();
                creatUsers.WindowState = FormWindowState.Normal;
            }
        }

        void creatUsers_FormClosed(object sender, FormClosedEventArgs e)
        {
            creatUsers = null;
        }

        frmPriviledges priviledges;
        private void tsMenuPriviledges_Click(object sender, EventArgs e)
        {
            if (priviledges == null)
            {
                priviledges = new frmPriviledges();
                priviledges.MdiParent = this;
                priviledges.FormClosed += new FormClosedEventHandler(priviledges_FormClosed);
                priviledges.Show();
            }
            else
            {
                priviledges.Activate();
                priviledges.WindowState = FormWindowState.Normal;
            }

        }

        void priviledges_FormClosed(object sender, FormClosedEventArgs e)
        {
            priviledges = null;
        }

        frmPatientDiagnosisInfo diagnosiInfo;
        private void tsDiagnosisInfo_Click(object sender, EventArgs e)
        {
            if (diagnosiInfo == null)
            {
                diagnosiInfo = new frmPatientDiagnosisInfo();
                diagnosiInfo.MdiParent = this;
                diagnosiInfo.FormClosed += new FormClosedEventHandler(diagnosiInfo_FormClosed);
                diagnosiInfo.Show();
            }
            else
            {
                diagnosiInfo.Activate();
                diagnosiInfo.WindowState = FormWindowState.Normal;      
            }
        }

        void diagnosiInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            diagnosiInfo = null;
        }

        frmPatientPrescription prescription;
        private void tsPrecrisptions_Click(object sender, EventArgs e)
        {
            if (prescription == null)
            {
                prescription = new frmPatientPrescription();
                prescription.MdiParent = this;
                prescription.FormClosed += new FormClosedEventHandler(prescription_FormClosed);
                prescription.Show();
            }
            else
            {
                prescription.Activate();
                prescription.WindowState = FormWindowState.Normal;
            }

        }

        void prescription_FormClosed(object sender, FormClosedEventArgs e)
        {
            prescription = null;
        }

        frmDoctorsAppointment appointment;
        private void tsAppointments_Click(object sender, EventArgs e)
        {
            if (appointment == null)
            {
                appointment = new frmDoctorsAppointment();
                appointment.MdiParent = this;
                appointment.FormClosed += new FormClosedEventHandler(appointment_FormClosed);
                appointment.Show();
            }
            else
            {
                appointment.Activate();
                appointment.WindowState = FormWindowState.Normal;
            }
        }

        void appointment_FormClosed(object sender, FormClosedEventArgs e)
        {
            appointment = null;
        }

        frmPatientInvoice invoice;
        private void tsPatientInvoice_Click(object sender, EventArgs e)
        {
            if (invoice == null)
            {
                invoice = new frmPatientInvoice();
                invoice.MdiParent = this;
                invoice.FormClosed += new FormClosedEventHandler(invoice_FormClosed);
                invoice.Show();
            }
            else
            {
                invoice.Activate();
                invoice.WindowState = FormWindowState.Normal;
            }
        }

        void invoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            invoice = null;
        }

        frmPatientBills bill;
        private void tsPatientBill_Click(object sender, EventArgs e)
        {
            if (bill == null)
            {
                bill = new frmPatientBills();
                bill.MdiParent = this;
                bill.FormClosed += new FormClosedEventHandler(bill_FormClosed);
                bill.Show();
            }
            else
            {
                bill.Activate();
                bill.WindowState = FormWindowState.Normal;
            }
        }

        void bill_FormClosed(object sender, FormClosedEventArgs e)
        {
            bill = null;
        }

        frmDoctorsAppointment appnt;
        private void tsDoctorAppointment_Click(object sender, EventArgs e)
        {
            if (appnt == null)
            {
                appnt = new frmDoctorsAppointment();
                appnt.MdiParent = this;
                appnt.FormClosed += new FormClosedEventHandler(appnt_FormClosed);
                appnt.Show();
            }
            else
            {
                appnt.Activate();
                appnt.WindowState = FormWindowState.Normal;
            }
        }

        void appnt_FormClosed(object sender, FormClosedEventArgs e)
        {
            appnt = null;
        }

        frmPatientRoom room;
        private void tsPatientRoom_Click(object sender, EventArgs e)
        {
            if (room == null)
            {
                room = new frmPatientRoom();
                room.MdiParent = this;
                room.FormClosed += new FormClosedEventHandler(room_FormClosed);
                room.Show();   
            }
            else
            {
                room.Activate();
                room.WindowState = FormWindowState.Normal;
            }
        }

        void room_FormClosed(object sender, FormClosedEventArgs e)
        {
            room = null;
        }

        frmVisitorsRegistration visitors;
        private void visitorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (visitors == null)
            {
                visitors = new frmVisitorsRegistration();
                visitors.MdiParent = this;
                visitors.FormClosed += new FormClosedEventHandler(visitors_FormClosed);
                visitors.Show(); 
            }
            else
            {
                visitors.Activate();
                visitors.WindowState = FormWindowState.Normal;
            }
        }

        void visitors_FormClosed(object sender, FormClosedEventArgs e)
        {
            visitors = null;
        }

        private void toolStripLogout_Click(object sender, EventArgs e)
        {
            loginToolStripMenuItem.PerformClick();
        }

        private void toolStripDoctors_Click(object sender, EventArgs e)
        {
            tsMenuDoctors.PerformClick();
        }

        private void toolStripPatient_Click(object sender, EventArgs e)
        {
            tsMenuPatients.PerformClick();
        }

        private void toolStripAppointment_Click(object sender, EventArgs e)
        {
            tsAppointments.PerformClick();
        }

        private void toolStripDischarge_Click(object sender, EventArgs e)
        {
            tsPatientRoom.PerformClick();
        }

        private void toolStripBills_Click(object sender, EventArgs e)
        {
            tsPatientBill.PerformClick();
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Arrange MDI child icons within the client region of the MDI parent form.
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cascade all child forms.
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void arrangeHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tile all child forms horizontally.
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void arrangeVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tile all child forms vertically.
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void maximizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            Form[] charr = this.MdiChildren;

            //for each child form set the window state to Maximized
            foreach (Form chform in charr)
                chform.WindowState = FormWindowState.Maximized;
        }

        private void minimizeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            Form[] charr = this.MdiChildren;

            //for each child form set the window state to Minimized
            foreach (Form chform in charr)
                chform.WindowState = FormWindowState.Minimized;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            Form[] charr = this.MdiChildren;

            //for each child form set the window state to Minimized
            foreach (Form chform in charr)
                chform.Close();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //Gets the currently active MDI child window.
            Form a = this.ActiveMdiChild;
            //Close the MDI child window
            a.Close();
        }
    }
}
