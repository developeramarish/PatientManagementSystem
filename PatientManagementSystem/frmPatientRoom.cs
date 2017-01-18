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
    public partial class frmPatientRoom : Form
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;

        public frmPatientRoom()
        {
            InitializeComponent();
        }

        private void frmPatientRoom_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - Patient Management System";
            // TODO: This line of code loads data into the 'patientMgtSystemDataSet.PatientRoom' table. You can move, or remove it, as needed.
            this.patientRoomTableAdapter.Fill(this.patientMgtSystemDataSet.PatientRoom);
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

            string select3 = "SELECT WardID FROM WardInfo ORDER BY WardID";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select3, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbWardID.Items.Add(dr["WardID"].ToString());
                        }
                    }
                }
            }
        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbRoomNo.Items.Clear();
            string select = "SELECT DISTINCT RoomNo, Price FROM RoomInfo WHERE RoomType = '"+cmbRoomType.Text+"' AND RoomOccupy = 0 AND WardID = '"+cmbWardID.Text+"'";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbRoomNo.Items.Add(dr["RoomNo"].ToString());
                            txtPrice.Text = dr["Price"].ToString();
                        }
                    }
                }
            }
        }

        void clearControl()
        {
            cmbPatientID.Text = "";
            cmbRoomNo.Text = "";
            cmbRoomType.Text = "";
            cmbWardID.Text = "";
            cmbWardType.Text = "";
            txtPatientNames.Text = "";
            txtPrice.Text = "";
            dtDateAdmitted.Text = DateTime.Today.ToShortDateString();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValidateData())
            {
                string insert = "INSERT INTO PatientRoom (PatientID,WardID,WardType,RoomType,RoomNo,Price,DateAdmitted,FullName,Image)"
                    + "VALUES"
                    + "(@PID,@WardID,@WardType,@RoomType,@RoomNo,@Price,@DateAdmitted,@FullName,@Image)";
                string update = "UPDATE RoomInfo SET RoomOccupy = @RoomOccupy WHERE WardID = '"+cmbWardID.Text+"'"
                    +"AND RoomType = '"+cmbRoomType.Text+"' AND RoomNo = '"+cmbRoomNo.Text+"'";
                DialogResult r = MessageBox.Show("Are you sure you want to SUBMIT?", "Patient Room", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                if (r == DialogResult.Yes)
                {
                    using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                    {
                        cnn.Open();
                        using (cmd = new SqlCommand(insert, cnn))
                        {
                            cmd.Parameters.AddWithValue("@PID", cmbPatientID.Text);
                            cmd.Parameters.AddWithValue("@WardID", cmbWardID.Text);
                            cmd.Parameters.AddWithValue("@WardType", cmbWardType.Text);
                            cmd.Parameters.AddWithValue("@RoomType", cmbRoomType.Text);
                            cmd.Parameters.AddWithValue("@RoomNo", cmbRoomNo.Text);
                            cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                            cmd.Parameters.AddWithValue("@DateAdmitted", dtDateAdmitted.Text);
                            cmd.Parameters.AddWithValue("@FullName", txtPatientNames.Text);
                            MemoryStream ms = new MemoryStream();
                            picImage.Image.Save(ms, picImage.Image.RawFormat);
                            byte[] data = ms.GetBuffer();
                            SqlParameter p = new SqlParameter("@Image", SqlDbType.Image);
                            p.Value = data;
                            cmd.Parameters.Add(p);
                            cmd.ExecuteNonQuery();
                        }

                        using (cmd = new SqlCommand(update, cnn))
                        {
                            cmd.Parameters.AddWithValue("@RoomOccupy", "1");
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data Submitted Successfully!", "Patient Room", MessageBoxButtons.OK,
                                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            clearControl();
                        }
                    }
                }
            }
        }

        private bool IsValidateData()
        {
            if (Validators.IsPresent(cmbPatientID) &&
                Validators.IsPresent(cmbRoomNo) &&
                Validators.IsPresent(cmbRoomType) &&
                Validators.IsPresent(cmbWardID) &&
                Validators.IsImagePresent(picImage) &&
                Validators.IsPresent(cmbWardType) &&
                Validators.IsPresent(txtPatientNames) &&
                Validators.IsPresent(txtPrice) &&
                Validators.IsPresent(dtDateAdmitted))
            {
                return true;
            }
            else
                return false;
        }

        private void cmbPatientID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = "SELECT *FROM PatientRegistration WHERE PID ='" + cmbPatientID.Text + "'";
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

                        txtPatientNames.Text = dr["Surname"].ToString()
                            + " " + dr["FirstName"].ToString() + " " + dr["OtherName"].ToString();
                    }
                }
            }
        }

        private void cmbWardID_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbWardType.Items.Clear();
            cmbRoomType.Items.Clear();
            string select = "SELECT *FROM WardInfo WHERE WardID = '" + cmbWardID.Text + "'";
            string select2 = "SELECT DISTINCT RoomType FROM RoomInfo WHERE WardID = '" + cmbWardID.Text + "'";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbWardType.Items.Add(dr["WardType"].ToString());
                        }
                    }
                }
            }

            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select2, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbRoomType.Items.Add(dr["RoomType"].ToString());
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string fullName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string wardID = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string roomType = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string roomNo = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            if (e.ColumnIndex == 8 && wardID != "" && roomType != "" && roomNo != "")
            {               
                DialogResult r = MessageBox.Show("Are you sure you want to DISCHARGE\r" + fullName + "?", 
                    "Patient Management System", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                    MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);

                if (r == DialogResult.Yes)
                {                    
                    using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                    {
                        string update = "UPDATE RoomInfo SET RoomOccupy=@RoomOccupy WHERE WardID = '" + wardID + "' AND RoomType = '" + roomType + "'" +
                        "AND RoomNo ='" + roomNo + "'";
                        string delete = "DELETE PatientRoom WHERE PatientID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                        cnn.Open();
                        using (cmd = new SqlCommand(update, cnn))
                        {
                            cmd.Parameters.AddWithValue("@RoomOccupy", "0");
                            cmd.ExecuteNonQuery();
                        }
                        using (cmd = new SqlCommand(delete, cnn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    } 
                   
                }                
            }
            else
            {
                MessageBox.Show("Pls, select an Item from the Grid View ", "Patient Management System", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) ||
            char.IsSymbol(e.KeyChar) ||
            char.IsWhiteSpace(e.KeyChar) ||
            char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
    }
}
