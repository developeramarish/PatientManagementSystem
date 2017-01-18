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
    public partial class frmLogin : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;
        public frmLogin()
        {
            InitializeComponent();
        }

        frmIndexForm form;
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text == "" && txtPassword.Text != "")
            {
                MessageBox.Show("Please Enter your UserName.", "Patient Management System", 
                    MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            }
            else if (txtPassword.Text == "" && txtUserName.Text != "")
            {
                MessageBox.Show("Please Enter your Password.", "Patient Management System", 
                    MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            }

            else if (txtUserName.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Please Enter UserName and Password.", "Patient Management System", 
                    MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            }
            else
            {
                int x = 0;
                progressBar1.Visible = true;
                progressBar1.Minimum = 1;
                progressBar1.Maximum = 100000;
                progressBar1.Step = 1;

                for (x = 1; x <= 100000; x++)
                {
                    progressBar1.PerformStep();
                }
                string select = "SELECT Username,Password FROM CreateUser WHERE Username='" + txtUserName.Text + "' AND Password='" + txtPassword.Text + "'";
                using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                {
                    cnn.Open();
                    using (cmd = new SqlCommand(select, cnn))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                this.Hide();
                                form = new frmIndexForm();
                                form.username = txtUserName.Text;
                                form.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Login details", "Patient Management System",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                                this.Hide();
                                frmLogin lg = new frmLogin();
                                lg.Show();
                            }
                        }
                    }
                }
            }            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
