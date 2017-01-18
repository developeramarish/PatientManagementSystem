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
    public partial class frmPatientDiagnosisInfo : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;

        public frmPatientDiagnosisInfo()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsValidateData())
            {
                DialogResult r = MessageBox.Show("Are you sure you want to UPDATE?", "Patient Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                if (r == DialogResult.Yes)
                {
                    string update = "UPDATE PatientDiagnosisInfo SET PatientID=@PatientID, DiagnosisNo=@DiagnosisNo, DiagnosisDate=@DiagnosisDate, "+
                        "BioChemistry=@BioChemistry, Blood=@Blood, Stool=@Stool, Colonoscopy=@Colonoscopy, Urine=@Urine, XRay=@XRay, EGC=@EGC, "+
                        "Sonography=@Sonography, Remarks=@Remarks WHERE PatientID='"+cmbPatientID.Text+"'";
                    using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                    {
                        cnn.Open();
                        using (cmd = new SqlCommand(update, cnn))
                        {
                            cmd.Parameters.AddWithValue("@PatientID", cmbPatientID.Text);
                            cmd.Parameters.AddWithValue("@DiagnosisNo", txtDiagnosisNo.Text);
                            cmd.Parameters.AddWithValue("@DiagnosisDate", Convert.ToDateTime(dtDiagnosisDate.Text).ToShortDateString());
                            cmd.Parameters.AddWithValue("@BioChemistry", txtBioChemistry.Text);
                            cmd.Parameters.AddWithValue("@Blood", txtBlood.Text);
                            cmd.Parameters.AddWithValue("@Stool", txtStool.Text);
                            cmd.Parameters.AddWithValue("@Colonoscopy", txtColonoscopy.Text);
                            cmd.Parameters.AddWithValue("@Urine", txtUrine.Text);
                            cmd.Parameters.AddWithValue("@XRay", txtXRay.Text);
                            cmd.Parameters.AddWithValue("@EGC", txtEGC.Text);
                            cmd.Parameters.AddWithValue("@Sonography", txtSonography.Text);
                            cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data Submitted Successfully!", "Patient Diagnosis Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            clearControl();
                        }
                    }
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {            
            if (lstPatientDiagnosisInfo.SelectedItems.Count != 0)
            {
                string select = "SELECT *FROM PatientDiagnosisInfo WHERE PatientID = '" + lstPatientDiagnosisInfo.SelectedItems[0].Text + "'";
                using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                {
                    cnn.Open();
                    using (cmd = new SqlCommand(select, cnn))
                    {
                        using (dr=cmd.ExecuteReader())
                        {
                            dr.Read();
                            cmbPatientID.Text = dr["PatientID"].ToString();
                            txtDiagnosisNo.Text = dr["DiagnosisNo"].ToString();
                            dtDiagnosisDate.Text = dr["DiagnosisDate"].ToString();
                            txtBioChemistry.Text = dr["BioChemistry"].ToString();
                            txtBlood.Text = dr["Blood"].ToString();
                            txtStool.Text = dr["Stool"].ToString();
                            txtColonoscopy.Text = dr["Colonoscopy"].ToString();
                            txtUrine.Text = dr["Urine"].ToString();
                            txtXRay.Text = dr["XRay"].ToString();
                            txtEGC.Text = dr["EGC"].ToString();
                            txtSonography.Text = dr["Sonography"].ToString();
                            txtRemarks.Text = dr["Remarks"].ToString();
                        }
                    }
                }
            }
            else
                MessageBox.Show("Select a row from the List to View", "Patient Bills");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure you want to DELETE?", "Patient Diagnosis Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (IsValidateData())
            {
                if (r == DialogResult.Yes)
                {
                    string del = "DELETE PatientDiagnosisInfo WHERE PatientID = '" + cmbPatientID.Text + "'";
                    using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                    {
                        cnn.Open();
                        using (cmd = new SqlCommand(del, cnn))
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Patient's Diagnosis Info deleted from the Database", "Patient Manangement System");
                            clearControl();
                        }
                    }
                }
            }
        }

        private void frmPatientDiagnosisInfo_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - Patient Management System";
            string select2 = "SELECT PID From PatientRegistration ORDER BY PID";
            string select = "SELECT *FROM PatientDiagnosisInfo ORDER BY PatientID";
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
                using (cmd = new SqlCommand(select, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ListViewItem lst = new ListViewItem();
                            lst.ImageIndex = 0;
                            lst.Text = dr["PatientID"].ToString();
                            lst.SubItems.Add(dr["DiagnosisNo"].ToString());
                            lst.SubItems.Add(dr["DiagnosisDate"].ToString());
                            lst.SubItems.Add(dr["BioChemistry"].ToString());
                            lst.SubItems.Add(dr["Blood"].ToString());
                            lst.SubItems.Add(dr["Stool"].ToString());
                            lst.SubItems.Add(dr["Colonoscopy"].ToString());
                            lst.SubItems.Add(dr["Urine"].ToString());
                            lst.SubItems.Add(dr["XRay"].ToString());
                            lst.SubItems.Add(dr["Sonography"].ToString());
                            lstPatientDiagnosisInfo.Items.Add(lst); 
                        }
                    }
                }
            }

        }

        void clearControl()
        {
            txtBioChemistry.Text = "";
            txtBlood.Text = "";
            txtColonoscopy.Text = "";
            txtDiagnosisNo.Text = "";
            txtEGC.Text = "";
            txtRemarks.Text = "";
            txtSonography.Text = "";
            txtStool.Text = "";
            txtUrine.Text = "";
            txtXRay.Text = "";
            dtDiagnosisDate.Value = DateTime.Now;
            cmbPatientID.Text = "";
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValidateData())
            {
                DialogResult r = MessageBox.Show("Are you sure you want to SUBMIT?", "Patient Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                if (r == DialogResult.Yes)
                {
                    string select = "SELECT *FROM PatientDiagnosisInfo WHERE PatientID = '"+cmbPatientID.Text +"'";
                    string insert = "INSERT INTO PatientDiagnosisInfo (PatientID, DiagnosisNo, DiagnosisDate, BioChemistry, Blood, Stool, Colonoscopy, Urine, " +
                        "XRay, EGC, Sonography, Remarks) VALUES (@PatientID, @DiagnosisNo, @DiagnosisDate, @BioChemistry, @Blood, @Stool, @Colonoscopy, @Urine, " +
                        "@XRay, @EGC, @Sonography, @Remarks)";
                    using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                    {
                        cnn.Open();
                        using (cmd = new SqlCommand(select, cnn))
                        {
                            using (dr = cmd.ExecuteReader())
                            {
                                if (!dr.Read())
                                {
                                    dr.Dispose();
                                    using (cmd = new SqlCommand(insert, cnn))
                                    {
                                        cmd.Parameters.AddWithValue("@PatientID", cmbPatientID.Text);
                                        cmd.Parameters.AddWithValue("@DiagnosisNo", txtDiagnosisNo.Text);
                                        cmd.Parameters.AddWithValue("@DiagnosisDate", Convert.ToDateTime(dtDiagnosisDate.Text).ToShortDateString());
                                        cmd.Parameters.AddWithValue("@BioChemistry", txtBioChemistry.Text);
                                        cmd.Parameters.AddWithValue("@Blood", txtBlood.Text);
                                        cmd.Parameters.AddWithValue("@Stool", txtStool.Text);
                                        cmd.Parameters.AddWithValue("@Colonoscopy", txtColonoscopy.Text);
                                        cmd.Parameters.AddWithValue("@Urine", txtUrine.Text);
                                        cmd.Parameters.AddWithValue("@XRay", txtXRay.Text);
                                        cmd.Parameters.AddWithValue("@EGC", txtEGC.Text);
                                        cmd.Parameters.AddWithValue("@Sonography", txtSonography.Text);
                                        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Data Submitted Successfully!", "Patient Diagnosis Information", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                        clearControl();

                                    }
                                }
                                else
                                    MessageBox.Show("Data already Submitted!", "Patient Diagnosis Information", MessageBoxButtons.OK,
                                                   MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                }
            }
        }

        private bool IsValidateData()
        {
            if (
                Validators.IsPresent(cmbPatientID) &&
                Validators.IsPresent(txtDiagnosisNo) &&
                Validators.IsPresent(dtDiagnosisDate) &&
                Validators.IsPresent(txtBioChemistry) &&
                Validators.IsPresent(txtBlood) &&
                Validators.IsPresent(txtStool) &&
                Validators.IsPresent(txtColonoscopy) &&
                Validators.IsPresent(txtUrine) &&
                Validators.IsPresent(txtXRay) &&
                Validators.IsPresent(txtEGC) &&
                Validators.IsPresent(txtSonography) &&
                Validators.IsPresent(txtRemarks))
            {
                return true;
            }
            else
                return false;
        }

        private void txtDiagnosisNo_KeyPress(object sender, KeyPressEventArgs e)
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
