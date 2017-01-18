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
    public partial class frmPatientPrescription : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;
        public frmPatientPrescription()
        {
            InitializeComponent();
        }

        private bool IsValidateData()
        {
            if (Validators.IsPresent(cmbDoctorID) &&
                Validators.IsPresent(cmbPatientID) &&
                Validators.IsPresent(txtDiagnosis) &&
                Validators.IsPresent(txtDrugs) &&
                Validators.IsPresent(txtReferral) &&
                Validators.IsPresent(dtPrescribedDate))
            {
                return true;
            }
            else
                return false;
        }

        private void frmPatientPrescription_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - Patient Management System";
            string select = "SELECT DID, Image From DoctorRegistration ORDER BY DID";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbDoctorID.Items.Add(dr["DID"].ToString());
                        }
                    }
                }
            }

            string select2 = "SELECT PID, Image From PatientRegistration ORDER BY PID";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select2, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbPatientID.Items.Add(dr["PID"].ToString());
                        }
                    }
                }
            }

            string select3 = "SELECT *FROM PatientsPrescription";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select3, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ListViewItem lst = new ListViewItem();
                            lst.ImageIndex = 0;
                            lst.Text = dr["DoctorID"].ToString();
                            lst.SubItems.Add(dr["PatientID"].ToString());
                            lst.SubItems.Add(dr["Drugs"].ToString());
                            lst.SubItems.Add(dr["Diagnosis"].ToString());
                            lst.SubItems.Add(dr["PrescribedDate"].ToString());
                            lst.SubItems.Add(dr["Referral"].ToString());
                            lstPatientPrescription.Items.Add(lst);
                        }
                    }
                }
            }
        }

        void clearControl()
        {
            txtDiagnosis.Text = "";
            txtDrugs.Text = "";
            txtReferral.Text = "";
            dtPrescribedDate.Text = DateTime.Today.ToShortDateString();
            cmbDoctorID.Text = "";
            cmbPatientID.Text = "";
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string insert = "INSERT INTO PatientsPrescription" +                
                "(DoctorID,PatientID, Drugs,Diagnosis, PrescribedDate, Referral)" +
                "VALUES" +
                "(@DoctorID, @PatientID, @Drugs, @Diagnosis, @PrescribedDate, @Referral)";                

            string select = "SELECT *FROM PatientsPrescription WHERE DoctorID = '" + cmbDoctorID.Text + "' AND PatientID = '" + cmbPatientID.Text + "'"; 
             DialogResult r = MessageBox.Show("Are you sure you want to SUBMIT?", "Patient Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
             if (r == DialogResult.Yes)
             {
                 if (IsValidateData())
                 {
                     using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                     {
                         cnn.Open();
                         using (cmd = new SqlCommand(select, cnn))
                         {
                             using (dr= cmd.ExecuteReader())
                             {
                                 if (!dr.Read())
                                 {
                                     dr.Dispose();
                                     using (cmd = new SqlCommand(insert, cnn))
                                     {                                        
                                             cmd.Parameters.AddWithValue("@DoctorID", cmbDoctorID.Text);
                                             cmd.Parameters.AddWithValue("@PatientID", cmbPatientID.Text);
                                             cmd.Parameters.AddWithValue("@Drugs", txtDrugs.Text);
                                             cmd.Parameters.AddWithValue("@Diagnosis", txtDiagnosis.Text);
                                             cmd.Parameters.AddWithValue("@PrescribedDate", dtPrescribedDate.Text);
                                             cmd.Parameters.AddWithValue("@Referral", txtReferral.Text);
                                             cmd.ExecuteNonQuery();
                                             MessageBox.Show("Patient's Drugs Prescribed", "Patient Management System", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                             clearControl();
                                     }
                                 }
                                 else
                                     MessageBox.Show("This Patient's Prescription already Exists.", "Patient Prescription", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                             }
                         }
                     }
                 }
             }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lstPatientPrescription.SelectedItems.Count != 0)
            {
                string select = "SELECT *FROM PatientsPrescription WHERE DoctorID ='" + lstPatientPrescription.SelectedItems[0].Text + "'"
                    + "AND PatientID ='" + lstPatientPrescription.SelectedItems[0].SubItems[1].Text + "'";
                using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                {
                    cnn.Open();
                    using (cmd = new SqlCommand(select, cnn))
                    {                        
                        using (dr = cmd.ExecuteReader())
                        {
                            dr.Read();
                            cmbDoctorID.Text = dr["DoctorID"].ToString();
                            cmbPatientID.Text = dr["PatientID"].ToString();
                            txtDrugs.Text = dr["Drugs"].ToString();
                            txtDiagnosis.Text = dr["Diagnosis"].ToString();
                            txtReferral.Text = dr["Referral"].ToString();
                            dtPrescribedDate.Value = Convert.ToDateTime(dr["PrescribedDate"].ToString());
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Select an item from the list to view", "Patient Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string update = "UPDATE PatientsPrescription SET DoctorID=@DoctorID, PatientID=@PatientID, Drugs=@Drugs, Diagnosis=@Diagnosis,"+
                "PrescribedDate=@PrescribedDate, Referral=@Referral WHERE DoctorID='"+cmbDoctorID.Text+"' AND PatientID='"+cmbPatientID.Text+"'";
            if (IsValidateData())
            {
                using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                {
                    cnn.Open();
                    using (cmd = new SqlCommand(update, cnn))
                    {
                        cmd.Parameters.AddWithValue("@DoctorID", cmbDoctorID.Text);
                        cmd.Parameters.AddWithValue("@PatientID", cmbPatientID.Text);
                        cmd.Parameters.AddWithValue("@Drugs", txtDrugs.Text);
                        cmd.Parameters.AddWithValue("@Diagnosis", txtDiagnosis.Text);
                        cmd.Parameters.AddWithValue("@PrescribedDate", dtPrescribedDate.Text);
                        cmd.Parameters.AddWithValue("@Referral", txtReferral.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Patient's Drugs Prescription is Updated", "Patient Management System", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        clearControl();
                    }
                } 
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsValidateData())
            {
                string delete = "DELETE PatientsPrescription WHERE PatientID='" + cmbPatientID.Text + "' AND DoctorID='" + cmbDoctorID.Text + "'";
                DialogResult r = MessageBox.Show("Are you sure you want to DELETE?", "Patient Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                if (r == DialogResult.Yes)
                {
                    using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                    {
                        cnn.Open();
                        using (cmd = new SqlCommand(delete, cnn))
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Patient's Prescription deleted from the Database", "Patient Manangement System");
                            clearControl();
                            
                        }
                    }
                }                
            }
        }

        private void txtDrugs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Invalid Input");
                e.Handled = true;
            } 
        }
    }
}
