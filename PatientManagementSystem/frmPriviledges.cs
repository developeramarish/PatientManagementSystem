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
    public partial class frmPriviledges : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;
        string reg, admin, patients, bill, app, admission, visitors, rpt;
        public frmPriviledges()
        {
            InitializeComponent();
        }

        private void frmPriviledges_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - Patient Management System";
            string select = "SELECT *FROM Priviledges ORDER BY Username";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LstUsers.Items.Add(dr.GetValue(0).ToString());
                        }
                    }
                }
            }
        }

        private void btnSetAccess_Click(object sender, EventArgs e)
        {
            if (LstUsers.Text != "")
            {
                if (chkListbox.GetItemChecked(0) == false)
                    reg = "0";
                else
                    reg = "1";
                if (chkListbox.GetItemChecked(1) == false)
                    admin = "0";
                else
                    admin = "1";
                if (chkListbox.GetItemChecked(2) == false)
                    patients = "0";
                else
                    patients = "1";
                if (chkListbox.GetItemChecked(3) == false)
                    bill = "0";
                else
                    bill = "1";
                if (chkListbox.GetItemChecked(4) == false)
                    app = "0";
                else
                    app = "1";
                if (chkListbox.GetItemChecked(5) == false)
                    admission = "0";
                else
                    admission = "1";
                if (chkListbox.GetItemChecked(6) == false)
                    visitors = "0";
                else
                    visitors = "1";
                if (chkListbox.GetItemChecked(7) == false)
                    rpt = "0";
                else
                    rpt = "1";

                string update = "UPDATE Priviledges SET Registration = @reg, Administrator = @admin, Patients = @patients, BillInvoice=@bill,"
                    + "Appointments=@app, Admission=@admission, Visitors=@visitors, Reports=@rpt WHERE Username='" + LstUsers.Text + "'";
                using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                {
                    cnn.Open();
                    using (cmd = new SqlCommand(update, cnn))
                    {
                        cmd.Parameters.AddWithValue("@reg", reg);
                        cmd.Parameters.AddWithValue("@admin", admin);
                        cmd.Parameters.AddWithValue("@patients", patients);
                        cmd.Parameters.AddWithValue("@bill", bill);
                        cmd.Parameters.AddWithValue("@app", app);
                        cmd.Parameters.AddWithValue("@admission", admission);
                        cmd.Parameters.AddWithValue("@visitors", visitors);
                        cmd.Parameters.AddWithValue("@rpt", rpt);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Access set sucessfully", "Patient Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("You must a select username", "Patient Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = "SELECT *FROM Priviledges WHERE Username = '" + LstUsers.Text + "'";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            /********* Registration *************/
                            if (dr.GetValue(1).ToString() == "0")
                                chkListbox.SetItemChecked(0, false);
                            else
                                chkListbox.SetItemChecked(0, true);
                            /********* Administrator *************/
                            if (dr.GetValue(2).ToString() == "0")
                                chkListbox.SetItemChecked(1, false);
                            else
                                chkListbox.SetItemChecked(1, true);
                            /*********    Patients    *************/
                            if (dr.GetValue(3).ToString() == "0")
                                chkListbox.SetItemChecked(2, false);
                            else
                                chkListbox.SetItemChecked(2, true);
                            /*********   Bill Invoice *************/
                            if (dr.GetValue(4).ToString() == "0")
                                chkListbox.SetItemChecked(3, false);
                            else
                                chkListbox.SetItemChecked(3, true);
                            /*********** Appointments *************/
                            if (dr.GetValue(5).ToString() == "0")
                                chkListbox.SetItemChecked(4, false);
                            else
                                chkListbox.SetItemChecked(4, true);
                            /*********    Admission   *************/
                            if (dr.GetValue(6).ToString() == "0")
                                chkListbox.SetItemChecked(5, false);
                            else
                                chkListbox.SetItemChecked(5, true);
                            /*********    Visitors    *************/
                            if (dr.GetValue(7).ToString() == "0")
                                chkListbox.SetItemChecked(6, false);
                            else
                                chkListbox.SetItemChecked(6, true);
                            /************   Report  **************/
                            if (dr.GetValue(8).ToString() == "0")
                                chkListbox.SetItemChecked(7, false);
                            else
                                chkListbox.SetItemChecked(7, true);
                        }
                        else
                            MessageBox.Show("Cannot read data", "Patient Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }
    }
}
