using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace PatientManagementSystem
{
    public partial class frmPatientInvoice : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;
        public frmPatientInvoice()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsValidateData())
            {
                string update = "UPDATE PatientInvoice SET DateAdmitted=@DateAdmitted, BloodTestFee=@BloodTestFee, Remarks=@Remarks, " +
                    "PatientBillID=@PatientBillID, DiagnosisDate=@DiagnosisDate, InvoiceNo=@Invoice, XRayFee=@XRayFee, DiagnosisFee=@DiagnosisFee, "+
                    "LabTestFee=@LabTestFee, InjectionFee=@InjectionFee, ConsultantFee=@ConsultantFee, MedicineFee=@MedicineFee, TotalFee=@TotalFee " +
                    "WHERE PatientID='"+cmbPatientID.Text+"'";
                using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                {
                    cnn.Open();
                    using (cmd = new SqlCommand(update, cnn))
                    {
                        cmd.Parameters.AddWithValue("@DateAdmitted", dateTimePicker1.Text);
                        cmd.Parameters.AddWithValue("@PatientBillID", txtPatientBillID.Text);
                        cmd.Parameters.AddWithValue("@DiagnosisDate", dtDiagnosisDate.Text);
                        cmd.Parameters.AddWithValue("@Invoice", txtInvoiceNo.Text);
                        cmd.Parameters.AddWithValue("@XRayFee", Convert.ToDouble(txtXRayFee.Text));
                        cmd.Parameters.AddWithValue("@DiagnosisFee", Convert.ToDouble(txtDiagnosisFee.Text));
                        cmd.Parameters.AddWithValue("@BloodTestFee", Convert.ToDouble(txtBloodTestFee.Text));
                        cmd.Parameters.AddWithValue("@LabTestFee", Convert.ToDouble(txtLabTestFee.Text));
                        cmd.Parameters.AddWithValue("@InjectionFee", Convert.ToDouble(txtInjectionFee.Text));
                        cmd.Parameters.AddWithValue("@ConsultantFee", Convert.ToDouble(txtConsultantFee.Text));
                        cmd.Parameters.AddWithValue("@MedicineFee", txtMedicine.Text);
                        cmd.Parameters.AddWithValue("@TotalFee", Convert.ToDouble(txtTotalFee.Text));
                        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Patient's Invoice has been Updated", "Patient Management System", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        clearControl();
                    }
                }
            }
        }

        private void frmPatientInvoice_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - Patient Management System";
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

            string select = "SELECT *FROM PatientInvoice";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            ListViewItem lst = new ListViewItem();
                            lst.ImageIndex = 0;
                            lst.Text = dr["PatientID"].ToString();
                            lst.SubItems.Add(dr["FirstName"].ToString() + " " + dr["LastName"].ToString());
                            lst.SubItems.Add(Convert.ToDateTime(dr["DateAdmitted"].ToString()).ToShortDateString());
                            lst.SubItems.Add(dr["InvoiceNo"].ToString());
                            lst.SubItems.Add(dr["XRayFee"].ToString());
                            lst.SubItems.Add(dr["DiagnosisFee"].ToString());
                            lst.SubItems.Add(dr["LabTestFee"].ToString());
                            lst.SubItems.Add(dr["BloodTestFee"].ToString());
                            lst.SubItems.Add(dr["InjectionFee"].ToString());
                            lst.SubItems.Add(dr["TotalFee"].ToString());
                            listView1.Items.Add(lst);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string select = "SELECT *FROM PatientRegistration WHERE PID = '" + cmbPatientID.Text + "'";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        txtFirstName.Text = dr["FirstName"].ToString();
                        txtLastName.Text = dr["Surname"].ToString();
                        byte[] data = (byte[])dr["Image"];
                        MemoryStream ms = new MemoryStream(data);
                        picImage.Image = Image.FromStream(ms);
                        picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        private bool IsValidateData()
        {
            if (Validators.IsPresent(txtLastName) &&
                Validators.IsPresent(txtFirstName) &&
                Validators.IsPresent(txtMedicine) &&
                Validators.IsPresent(cmbPatientID) &&
                Validators.IsImagePresent(picImage) &&
                Validators.IsPresent(dateTimePicker1) &&
                Validators.IsPresent(txtInjectionFee) &&
                Validators.IsPresent(txtInvoiceNo) &&
                Validators.IsPresent(txtPatientBillID) &&
                Validators.IsPresent(txtTotalFee) &&
                Validators.IsPresent(txtDiagnosisFee) &&
                Validators.IsPresent(txtBloodTestFee) &&
                Validators.IsPresent(txtLabTestFee))
            {
                return true;
            }
            else
                return false;
        }

        void clearControl()
        {
            txtBloodTestFee.Text = "";
            txtConsultantFee.Text = "";
            txtDiagnosisFee.Text = "";
            txtFirstName.Text = "";
            txtInjectionFee.Text = "";
            txtInvoiceNo.Text = "";
            txtLabTestFee.Text = "";
            txtLastName.Text = "";
            txtMedicine.Text = "";
            txtPatientBillID.Text = "";
            txtRemarks.Text = "";
            txtTotalFee.Text = "";
            txtXRayFee.Text = "";
            picImage.Image = null;
            cmbPatientID.Text = "";
            dtDiagnosisDate.Text = DateTime.Today.ToShortDateString();            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure you want to SUBMIT?", "Patient Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (r == DialogResult.Yes)
            {
                if (IsValidateData())
                {
                    string select = "SELECT *FROM PatientInvoice WHERE PatientID = '"+cmbPatientID.Text+"'";
                    string insert = "INSERT INTO PatientInvoice (PatientID,FirstName,LastName,DateAdmitted,PatientBillID,DiagnosisDate,InvoiceNo"
                        +",XRayFee,DiagnosisFee,LabTestFee,InjectionFee,ConsultantFee,MedicineFee,TotalFee,Remarks,Image,BloodTestFee)" 
                        +"VALUES" 
                        +"(@PatientID,@FirstName,@LastName,@DateAdmitted,@PatientBillID,@DiagnosisDate,@Invoice" 
                        +",@XRayFee,@DiagnosisFee,@LabTestFee,@InjectionFee,@ConsultantFee,@Medicine,@TotalFee,@Remarks,@Image,@BloodTestFee)";

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
                                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                                        cmd.Parameters.AddWithValue("@DateAdmitted", dateTimePicker1.Text);
                                        cmd.Parameters.AddWithValue("@PatientBillID", txtPatientBillID.Text);
                                        cmd.Parameters.AddWithValue("@DiagnosisDate", dtDiagnosisDate.Text);
                                        cmd.Parameters.AddWithValue("@Invoice", txtInvoiceNo.Text);
                                        cmd.Parameters.AddWithValue("@XRayFee", Convert.ToDouble(txtXRayFee.Text));
                                        cmd.Parameters.AddWithValue("@DiagnosisFee", Convert.ToDouble(txtDiagnosisFee.Text));
                                        cmd.Parameters.AddWithValue("@BloodTestFee", Convert.ToDouble(txtBloodTestFee.Text));
                                        cmd.Parameters.AddWithValue("@LabTestFee", Convert.ToDouble(txtLabTestFee.Text));
                                        cmd.Parameters.AddWithValue("@InjectionFee", Convert.ToDouble(txtInjectionFee.Text));
                                        cmd.Parameters.AddWithValue("@ConsultantFee", Convert.ToDouble(txtConsultantFee.Text));
                                        cmd.Parameters.AddWithValue("@Medicine", txtMedicine.Text);
                                        cmd.Parameters.AddWithValue("@TotalFee", Convert.ToDouble(txtTotalFee.Text));
                                        cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                                        MemoryStream ms = new MemoryStream();
                                        picImage.Image.Save(ms, picImage.Image.RawFormat);
                                        byte[] data = ms.GetBuffer();
                                        SqlParameter p = new SqlParameter("@Image", SqlDbType.Image);
                                        p.Value = data;
                                        cmd.Parameters.Add(p);

                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Data Submitted Successfully!", "Patient Registration", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                        clearControl();
                                    }
                                }
                                else
                                    MessageBox.Show("Data already Submitted!", "Patient Invoice", MessageBoxButtons.OK,
                                            MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string select = "SELECT *FROM PatientInvoice WHERE PatientID='"+listView1.SelectedItems[0].Text+"'";
                using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                {
                    cnn.Open();
                    using (cmd = new SqlCommand(select,cnn))
                    {
                        using (dr=cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                cmbPatientID.Text = dr["PatientID"].ToString();
                                txtFirstName.Text = dr["FirstName"].ToString();
                                txtLastName.Text = dr["LastName"].ToString();
                                dtDiagnosisDate.Value = Convert.ToDateTime(dr["DateAdmitted"].ToString());
                                txtPatientBillID.Text = dr["PatientBillID"].ToString();
                                dateTimePicker1.Text = Convert.ToDateTime(dr["DiagnosisDate"].ToString()).ToShortDateString();
                                txtInvoiceNo.Text = dr["InvoiceNo"].ToString();
                                txtXRayFee.Text = dr["XRayFee"].ToString();
                                txtDiagnosisFee.Text = dr["DiagnosisFee"].ToString();
                                txtBloodTestFee.Text = dr["BloodTestFee"].ToString();
                                txtLabTestFee.Text = dr["LabTestFee"].ToString();
                                txtInjectionFee.Text = dr["InjectionFee"].ToString();
                                txtConsultantFee.Text = dr["ConsultantFee"].ToString();
                                txtMedicine.Text = dr["MedicineFee"].ToString();
                                txtTotalFee.Text = dr["TotalFee"].ToString();
                                txtRemarks.Text = dr["Remarks"].ToString();
                                byte[] data = (byte[])dr["Image"];
                                MemoryStream ms = new MemoryStream(data);
                                picImage.Image = Image.FromStream(ms);
                                picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsValidateData())
            {
                string delete = "DELETE PatientInvoice WHERE PatientID='" + cmbPatientID.Text + "'";
                DialogResult r = MessageBox.Show("Are you sure you want to DELETE?", "Patient Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                if (r == DialogResult.Yes)
                {
                    using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                    {
                        cnn.Open();
                        using (cmd = new SqlCommand(delete, cnn))
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Patient's Invoice deleted from the Database", "Patient Manangement System");
                            clearControl();
                        }
                    }
                }
            }    
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
            char.IsSymbol(e.KeyChar) ||
            char.IsWhiteSpace(e.KeyChar) ||
            char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
    }
}
