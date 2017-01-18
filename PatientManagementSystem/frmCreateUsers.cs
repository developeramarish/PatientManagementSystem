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
    public partial class frmCreateUsers : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;
        public frmCreateUsers()
        {
            InitializeComponent();
        }

        //frmCreateUsers form;
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string insert2 = "INSERT INTO Priviledges (Username, Registration, Administrator, Patients, BillInvoice, Appointments, Admission, Visitors, Reports)"
                + "VALUES (@Username, @Registration, @Administrator, @Patients, @BillInvoice, @Appointments, @Admission, @Visitors, @Reports)";
            string select = "SELECT Username FROM CreateUser WHERE Username='" + txtUserName.Text + "'";
            string insert = "INSERT INTO CreateUser(Username,Password,ConfirmPassword)VALUES(@user,@password,@cpassword)";

            if (txtUserName.Text == "" && txtPassword.Text == "" && txtC_Password.Text == "")
            {
                MessageBox.Show("Enter all reqiured values", "Create User - PMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (txtUserName.Text == "" && txtPassword.Text == "" && txtC_Password.Text != "")
            {
                MessageBox.Show("Enter Username and Password", "Create User - PMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (txtUserName.Text == "" && txtPassword.Text != "" && txtC_Password.Text == "")
            {
                MessageBox.Show("Enter Username and Confirm password", "Create User - PMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (txtUserName.Text == "" && txtPassword.Text != "" && txtC_Password.Text != "")
            {
                MessageBox.Show("Enter Username", "Create User - PMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (txtUserName.Text != "" && txtPassword.Text == "" && txtC_Password.Text == "")
            {
                MessageBox.Show("Enter all Password and Confirm password", "Create User - PMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (txtUserName.Text != "" && txtPassword.Text == "" && txtC_Password.Text != "")
            {
                MessageBox.Show("Enter all Password", "Create User - PMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (txtUserName.Text != "" && txtPassword.Text != "" && txtC_Password.Text == "")
            {
                MessageBox.Show("Enter Confirm Password", "Create User - PMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (txtUserName.Text != "" && txtPassword.Text != txtC_Password.Text)
            {
                MessageBox.Show("Mismatch passwords", "Create User - PMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (txtUserName.Text != "" && txtPassword.Text != "" && txtC_Password.Text != "" && txtC_Password.Text == txtPassword.Text)
            {
                using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                {
                    cnn.Open();
                    using (cmd = new SqlCommand(select, cnn))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                MessageBox.Show("Username already exist", "Create User - PMS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                dr.Dispose();
                                using (cmd = new SqlCommand(insert, cnn))
                                {
                                    cmd.Parameters.AddWithValue("@user", txtUserName.Text);
                                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                                    cmd.Parameters.AddWithValue("@cpassword", txtC_Password.Text);
                                    cmd.ExecuteNonQuery();
                                }
                                using (cmd = new SqlCommand(insert2, cnn))
                                {
                                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim().ToUpper());
                                    cmd.Parameters.AddWithValue("@Registration", "0");
                                    cmd.Parameters.AddWithValue("@Administrator", "0");
                                    cmd.Parameters.AddWithValue("@Patients", "0");
                                    cmd.Parameters.AddWithValue("@BillInvoice", "0");
                                    cmd.Parameters.AddWithValue("@Appointments", "0");
                                    cmd.Parameters.AddWithValue("@Admission", "0");
                                    cmd.Parameters.AddWithValue("@Visitors", "0");
                                    cmd.Parameters.AddWithValue("@Reports", "0");
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("User has been created successfully", "Create User - Patient Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtC_Password.Text = "";
                                    txtPassword.Text = "";
                                    txtUserName.Text = "";
                                }
                            }
                        }
                    }
                }
            }
        } 
    }
}
