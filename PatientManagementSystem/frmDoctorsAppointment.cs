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
    public partial class frmDoctorsAppointment : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;
        public string date;
        public int day;
        public int month;
        public int year;

        public frmDoctorsAppointment()
        {
            InitializeComponent();
        }

        private bool IsValidateData()
        {
            if (Validators.IsPresent(cmbDoctorID) &&
                Validators.IsPresent(cmbPatientID) &&
                Validators.IsPresent(mskTimeIn) &&
                Validators.IsPresent(mskTimeOut) &&
                Validators.IsImagePresent(picImage))
            {
                return true;
            }
            else
                return false;
        }

        private void frmDoctorsAppointment_Load(object sender, EventArgs e)
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

            string select3 = "SELECT *FROM DoctorsAppointment";
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
                            lst.Text = dr["DID"].ToString();
                            lst.SubItems.Add(dr["PID"].ToString());
                            lst.SubItems.Add(dr["AppmntDate"].ToString());
                            lst.SubItems.Add(dr["AppmntTimeIn"].ToString());
                            lst.SubItems.Add(dr["AppmntTimeOut"].ToString());
                            lstAppointment.Items.Add(lst);
                        }
                    }
                }
            }

            
        }

        private void cmbDoctorID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = "SELECT DID,Image FROM DoctorRegistration WHERE DID ='" + cmbDoctorID.Text + "'";
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

        public void mthAppointmentDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            date = mthAppointmentDate.SelectionEnd.ToShortDateString();
            day = mthAppointmentDate.SelectionEnd.Day;
            month = mthAppointmentDate.SelectionEnd.Month;
            year = mthAppointmentDate.SelectionEnd.Year;
        }

        public int verifyAppointments()
        {
            string select = "SELECT DID, AppmntDate, AppmntTimeIn FROM DoctorsAppointment WHERE DID = '" + cmbDoctorID.Text + "' AND AppmntDate = '" + mthAppointmentDate.SelectionEnd.ToShortDateString() + "' AND AppmntTimeIn = '" + mskTimeIn.Text + "'";                
            using (cmd = new SqlCommand(select,cnn))
            {
                using (dr = cmd.ExecuteReader())
                {
                    int id = -1;
                    if (dr.Read())
                    {
                        id = int.Parse(dr["DID"].ToString());
                    }
                    return id;
                }
            }                
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            day = mthAppointmentDate.SelectionEnd.Day;
            month = mthAppointmentDate.SelectionEnd.Month;
            year = mthAppointmentDate.SelectionEnd.Year;
            DialogResult r = MessageBox.Show("Are you sure you want to SUBMIT?", "Doctors Appointment", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (r == DialogResult.Yes)
            {
                using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                {
                    cnn.Open();
                    string insert = "INSERT INTO DoctorsAppointment"
                        + "(DID,PID,AppmntDate,AppmntTimeIn,AppmntTimeOut,AppmntDay,AppmntMonth,AppmntYear,Image)"
                        + "VALUES"
                        + "(@DID,@PID,@AppmntDate,@AppmntTimeIn,@AppmntOut,@AppmntDay,@AppmntMonth,@AppmntYear,@Image)";
                    int k = verifyAppointments();
                    if (k == -1)
                    {
                        using (cmd = new SqlCommand(insert,cnn))
                        {
                            cmd.Parameters.AddWithValue("@DID", cmbDoctorID.Text);
                            cmd.Parameters.AddWithValue("@PID", cmbPatientID.Text);
                            cmd.Parameters.AddWithValue("@AppmntDate", mthAppointmentDate.SelectionEnd.ToShortDateString());
                            cmd.Parameters.AddWithValue("@AppmntTimeIn", mskTimeIn.Text);
                            cmd.Parameters.AddWithValue("@AppmntOut", mskTimeOut.Text);
                            cmd.Parameters.AddWithValue("@AppmntDay", day);
                            cmd.Parameters.AddWithValue("@AppmntMonth", month);
                            cmd.Parameters.AddWithValue("@AppmntYear", year);

                            MemoryStream ms = new MemoryStream();
                            picImage.Image.Save(ms, picImage.Image.RawFormat);
                            byte[] data = ms.GetBuffer();
                            SqlParameter p = new SqlParameter("@Image", SqlDbType.Image);
                            p.Value = data;
                            cmd.Parameters.Add(p);
                                                        
                            cmd.ExecuteNonQuery();                            
                            MessageBox.Show("Data Submitted Successfully!", "Doctors Appointment", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                            this.Hide();
                            var frm = new frmDoctorsAppointment();
                            frm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("This particular Doctor is booked", "Doctors Appointment");
                    }
                }
            }
        }
    }
}
