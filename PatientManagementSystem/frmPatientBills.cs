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
    public partial class frmPatientBills : Form
    {
        SqlCommand cmd;
        SqlConnection cnn;
        SqlDataReader dr;
        public DateTime receiptDate, dateToPay;

        public frmPatientBills()
        {
            InitializeComponent();
        }

        private void frmPatientBills_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - Patient Management System";
            string select = "SELECT *FROM PatientBills";
            string select2 = "SELECT PatientID, Image From PatientInvoice ORDER BY PatientID";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select2, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbPatientID.Items.Add(dr["PatientID"].ToString());
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
                            lst.SubItems.Add(dr["FirstName"].ToString() + " " + dr["LastName"].ToString());
                            lst.SubItems.Add(dr["PatientBillID"].ToString());
                            lst.SubItems.Add(dr["InvoiceNo"].ToString());
                            lst.SubItems.Add(dr["TotalAmountDue"].ToString());
                            lst.SubItems.Add(Convert.ToDateTime(dr["DateToPay"].ToString()).ToShortDateString());
                            lst.SubItems.Add(Convert.ToDateTime(dr["ReceiptDate"].ToString()).ToShortDateString());
                            lstPatientBills.Items.Add(lst);
                        }
                    }
                }
            }




        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string select = "SELECT *FROM PatientInvoice WHERE PatientID = '" + cmbPatientID.Text + "'";
            using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
            {
                cnn.Open();
                using (cmd = new SqlCommand(select, cnn))
                {
                    using (dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        txtFirstName.Text = dr["FirstName"].ToString();
                        txtLastName.Text = dr["LastName"].ToString();
                        txtPatientBillID.Text = dr["PatientBillID"].ToString();
                        txtInvoiceNo.Text = dr["InvoiceNo"].ToString();
                        txtTotalAmount.Text = dr["TotalFee"].ToString();
                        byte[] data = (byte[])dr["Image"];
                        MemoryStream ms = new MemoryStream(data);
                        picImage.Image = Image.FromStream(ms);
                        picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        void clearControls()
        {
            txtFirstName.Text = "";
            txtInvoiceNo.Text = "";
            txtLastName.Text = "";
            txtPatientBillID.Text = "";
            txtTotalAmount.Text = "";
            cmbPatientID.Text = "";
            picImage.Image = null;
            dtDateToPay.Value = DateTime.Now;
            dtReceiptDate.Value = DateTime.Now;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            receiptDate = dtReceiptDate.Value;
            dateToPay = dtDateToPay.Value;
            if (dateToPay >= receiptDate)
            {
                string insert = "INSERT INTO PatientBills (PatientID, FirstName, LastName, PatientBillID, InvoiceNo, TotalAmountDue, DateToPay, ReceiptDate, Image)" +
                 "VALUES (@PatientID, @FirstName, @LastName, @PatientBillID, @InvoiceNo, @TotalAmountDue, @DateToPay, @ReceiptDate, @Image)";
                string select = "SELECT *FROM PatientBills WHERE PatientID = '" + cmbPatientID.Text + "'";
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
                                        cmd.Parameters.AddWithValue("@PatientBillID", txtPatientBillID.Text);
                                        cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                                        cmd.Parameters.AddWithValue("@TotalAmountDue", txtTotalAmount.Text);
                                        cmd.Parameters.AddWithValue("@DateToPay", Convert.ToDateTime(dtReceiptDate.Text).ToShortDateString());
                                        cmd.Parameters.AddWithValue("@ReceiptDate", Convert.ToDateTime(dtDateToPay.Text).ToShortDateString());
                                        MemoryStream ms = new MemoryStream();
                                        picImage.Image.Save(ms, picImage.Image.RawFormat);
                                        byte[] data = ms.GetBuffer();
                                        SqlParameter p = new SqlParameter("@Image", SqlDbType.Image);
                                        p.Value = data;
                                        cmd.Parameters.Add(p);

                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Data Submitted Successfully!", "Patient Bills", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                        clearControls();
                                    }
                                }
                                else
                                    MessageBox.Show("Data already Submitted!", "Patient Bills", MessageBoxButtons.OK,
                                                   MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                            }
                        }
                    } 
                }
                }
            }
            else
                MessageBox.Show("Wrong receipt date", "Patient Bills");
        }

        private bool IsValidateData()
        {
            if (
                Validators.IsPresent(cmbPatientID) &&
                Validators.IsPresent(txtFirstName) && 
                Validators.IsPresent(txtLastName) &&
                Validators.IsPresent(txtPatientBillID) &&
                Validators.IsImagePresent(picImage) &&
                Validators.IsPresent(dtDateToPay) &&
                Validators.IsPresent(dtReceiptDate) &&
                Validators.IsPresent(txtInvoiceNo)&&
                Validators.IsPresent(txtTotalAmount))
            {
                return true;
            }
            else
                return false;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (lstPatientBills.SelectedItems.Count != 0)
            {
                string select = "SELECT *FROM PatientBills WHERE PatientID = '" + lstPatientBills.SelectedItems[0].Text + "'";
                using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                {
                    cnn.Open();
                    using (cmd = new SqlCommand(select, cnn))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            dr.Read();
                            cmbPatientID.Text = dr["PatientID"].ToString();
                            txtFirstName.Text = dr["FirstName"].ToString();
                            txtLastName.Text = dr["LastName"].ToString();
                            txtPatientBillID.Text = dr["PatientBillID"].ToString();
                            txtInvoiceNo.Text = dr["InvoiceNo"].ToString();
                            txtTotalAmount.Text = dr["TotalAmountDue"].ToString();
                            dtDateToPay.Text = dr["DateToPay"].ToString();
                            dtReceiptDate.Text = dr["ReceiptDate"].ToString();
                            byte[] data = (byte[])dr["Image"];
                            MemoryStream ms = new MemoryStream(data);
                            picImage.Image = Image.FromStream(ms);
                            picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                }
            }
            else
                MessageBox.Show("Select a row from the List to View","Patient Bills");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            receiptDate = dtReceiptDate.Value;
            dateToPay = dtDateToPay.Value;
            if (dateToPay >= receiptDate)
            {
                DialogResult r = MessageBox.Show("Are you sure you want to UPDATE?", "Patient Bills", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                if (r == DialogResult.Yes)
                {
                    if (IsValidateData())
                    {
                        string update = "UPDATE PatientBills SET PatientID=@PatientID, FirstName=@FirstName, LastName=@LastName, PatientBillID=@PatientBillID,"+
                            "InvoiceNo=@InvoiceNo, TotalAmountDue=@TotalAmountDue, DateToPay=@DateToPay, ReceiptDate=@ReceiptDate WHERE PatientID = '"+cmbPatientID.Text+"'";
                        using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                        {
                            cnn.Open();
                            using (cmd = new SqlCommand(update, cnn))
                            {
                                cmd.Parameters.AddWithValue("@PatientID", cmbPatientID.Text);
                                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                                cmd.Parameters.AddWithValue("@PatientBillID", txtPatientBillID.Text);
                                cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                                cmd.Parameters.AddWithValue("@TotalAmountDue", txtTotalAmount.Text);
                                cmd.Parameters.AddWithValue("@DateToPay", Convert.ToDateTime(dtReceiptDate.Text).ToShortDateString());
                                cmd.Parameters.AddWithValue("@ReceiptDate", Convert.ToDateTime(dtDateToPay.Text).ToShortDateString());
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Data updated Successfully!", "Patient Bills", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                clearControls();
                            }
                        }
                    }
                } 
            }
            else
                MessageBox.Show("Wrong receipt date", "Patient Bills");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure you want to DELETE?", "Patient Bills", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (IsValidateData())
            {
                if (r == DialogResult.Yes)
                {
                    string del = "DELETE PatientBills WHERE PatientID = '" + cmbPatientID.Text + "'";
                    using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                    {
                        cnn.Open();
                        using (cmd = new SqlCommand(del, cnn))
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Patient's Invoice deleted from the Database", "Patient Manangement System");
                            clearControls();
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
