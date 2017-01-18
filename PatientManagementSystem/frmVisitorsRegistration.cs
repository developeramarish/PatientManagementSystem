using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace PatientManagementSystem
{
    public partial class frmVisitorsRegistration : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;

        public frmVisitorsRegistration()
        {
            InitializeComponent();
        }

        private void frmVisitorsRegistration_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - Patient Management System";
            string select = "SELECT PID, Image From PatientRegistration ORDER BY PID";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select, cnn))
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
        }

        private bool IsValidateData()
        {
            if (Validators.IsPresent(txtGNames) &&
                Validators.IsPresent(txtAddress) &&
                Validators.IsPresent(txtEmail) &&
                Validators.IsPresent(txtOccupation) &&
                Validators.IsImagePresent(picImage) &&
                Validators.IsPresent(txtPhoneNo) &&
                Validators.IsPresent(cmbPatientID) &&
                Validators.IsPresent(txtVisitorsTagID) &&
                Validators.IsPresent(cmbSex))
            {
                return true;
            }
            else
                return false;
        }

        private void cmbPatientID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = "SELECT PID,Image FROM PatientRegistration WHERE PID ='" + cmbPatientID.Text + "'";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        byte[] data = (byte[])dr["Image"];
                        MemoryStream ms = new MemoryStream(data);
                        picImage.Image = Image.FromStream(ms);
                        picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        void clearControl()
        {
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtGNames.Text = "";
            txtOccupation.Text = "";
            txtPhoneNo.Text = "";
            txtVisitorsTagID.Text = "";
            cmbPatientID.Text = "";
            cmbSex.Text = "";           
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string insert = "INSERT INTO VisitorsRegistration (PatientID,Name,Sex,Address,PhoneNo,Occupation,Image,VisitorsTagID,DateVisited)" +
                "VALUES(@PID,@Name,@Sex,@Address,@PhoneNo,@Occupation,@Image,@VisitorsTagID,@DateVisited)";
            if (IsValidateData())
            {
                DialogResult rs = MessageBox.Show("Are you sure you want to Submit?", "Visitors Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (rs == DialogResult.Yes)
                {
                    using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                    {
                        cnn.Open();
                        using (cmd = new SqlCommand(insert, cnn))
                        {
                            cmd.Parameters.AddWithValue("@PID", cmbPatientID.Text);
                            cmd.Parameters.AddWithValue("@VisitorsTagID", txtVisitorsTagID.Text);
                            cmd.Parameters.AddWithValue("@Name", txtGNames.Text);
                            cmd.Parameters.AddWithValue("@Sex", cmbSex.Text);
                            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                            cmd.Parameters.AddWithValue("@PhoneNo", txtPhoneNo.Text);
                            cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                            cmd.Parameters.AddWithValue("@DateVisited", DateTime.Now.Date.ToShortDateString());

                            MemoryStream ms = new MemoryStream();
                            picImage.Image.Save(ms, picImage.Image.RawFormat);
                            byte[] data = ms.GetBuffer();
                            SqlParameter p = new SqlParameter("@Image", SqlDbType.Image);
                            p.Value = data;
                            cmd.Parameters.Add(p);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data Submitted to the database", "Visitor Registration");
                        }
                    } 
                }
            } 
        }

        private void txtGNames_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.SelectAll();
                    e.Cancel = true;
                }
            } 

        }
    }
}
