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
using SecuGen.FDxSDKPro.Windows;

namespace PatientManagementSystem
{
    public partial class frmPatientRegistration : Form
    {
        private SGFingerPrintManager m_FPM;
        private bool m_LedOn = false;
        private Int32 m_ImageWidth;
        private Int32 m_ImageHeight;
        private Byte[] m_RegMin1;
        private Byte[] m_RegMin2;
        private Byte[] m_RegMin3;
        private SGFPMDeviceList[] m_DevList; // Used for EnumerateDevice

        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;

        public frmPatientRegistration()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    picImage.Image = Image.FromFile(openFileDialog1.FileName);
                    picImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ///////////////////////
        /// EnumerateDevice(), GetEnumDeviceInfo()
        /// EnumerateDevice() can be called before Initializing SGFingerPrintManager
        private void EnumerateBtn_Click(object sender, System.EventArgs e)
        {
            Int32 iError;
            string enum_device;

            cmbDeviceName.Items.Clear();

            // Enumerate Device
            iError = m_FPM.EnumerateDevice();

            // Get enumeration info into SGFPMDeviceList
            m_DevList = new SGFPMDeviceList[m_FPM.NumberOfDevice];

            for (int i = 0; i < m_FPM.NumberOfDevice; i++)
            {
                m_DevList[i] = new SGFPMDeviceList();
                m_FPM.GetEnumDeviceInfo(i, m_DevList[i]);
                enum_device = m_DevList[i].DevName.ToString() + " : " + m_DevList[i].DevID;
                cmbDeviceName.Items.Add(enum_device);
            }

            if (cmbDeviceName.Items.Count > 0)
            {
                // Add Auto Selection
                enum_device = "Auto Selection";
                cmbDeviceName.Items.Add(enum_device);

                cmbDeviceName.SelectedIndex = 0;  //First selected one
            }

        }

        ///////////////////////
        // Initialize SGFingerprint manage with device name
        // Init(), OpenDeice()
        private void btnOpenDevice_Click(object sender, EventArgs e)
        {
            if (btnInitDevice.Text == "Initialize Device")
            {
                if (m_FPM.NumberOfDevice == 0)
                {
                    StatusBars.Text = "Please Plug Device And Then Click On Load Device";
                    return;
                }
                if (cmbDeviceName.SelectedIndex == -1) return;
                Int32 iError;
                SGFPMDeviceName device_name;
                Int32 device_id;

                Int32 numberOfDevices = cmbDeviceName.Items.Count;
                Int32 deviceSelected = cmbDeviceName.SelectedIndex;
                Boolean autoSelection = (deviceSelected == (numberOfDevices - 1));  // Last index

                if (autoSelection)
                {
                    // Order of search: Hamster IV(HFDU04) -> Plus(HFDU03) -> III (HFDU02)
                    device_name = SGFPMDeviceName.DEV_AUTO;

                    device_id = (Int32)(SGFPMPortAddr.USB_AUTO_DETECT);
                }
                else
                {
                    device_name = m_DevList[deviceSelected].DevName;
                    device_id = m_DevList[deviceSelected].DevID;
                }

                iError = m_FPM.Init(device_name);
                iError = m_FPM.OpenDevice(device_id);

                iError = m_FPM.Init(device_name);
                iError = m_FPM.OpenDevice(device_id);
                if (iError == (Int32)SGFPMError.ERROR_NONE)
                {
                    SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
                    Int32 iError2 = m_FPM.GetDeviceInfo(pInfo);

                    if (iError2 == (Int32)SGFPMError.ERROR_NONE)
                    {
                        m_ImageWidth = pInfo.ImageWidth;
                        m_ImageHeight = pInfo.ImageHeight;
                    }

                    StatusBars.Text = "Device Initialization Success";

                    btnInitDevice.Text = "Close Device";


                }
                else
                    DisplayError("OpenDevice()", iError);
            }
            else
            {
                m_FPM.CloseDevice();
                btnInitDevice.Text = "Open Device";

                btnInitDevice.Text = "Device Close";
            }
        }
        void DisplayError(string funcName, int iError)
        {
            string text = "";

            switch (iError)
            {
                case 0:                             //SGFDX_ERROR_NONE				= 0,
                    text = "Error none";
                    break;

                case 1:                             //SGFDX_ERROR_CREATION_FAILED	= 1,
                    text = "Can not create object";
                    break;

                case 2:                             //   SGFDX_ERROR_FUNCTION_FAILED	= 2,
                    text = "Function Failed";
                    break;

                case 3:                             //   SGFDX_ERROR_INVALID_PARAM	= 3,
                    text = "Invalid Parameter";
                    break;

                case 4:                          //   SGFDX_ERROR_NOT_USED			= 4,
                    text = "Not used function";
                    break;

                case 5:                                //SGFDX_ERROR_DLLLOAD_FAILED	= 5,
                    text = "Can not create object";
                    break;

                case 6:                                //SGFDX_ERROR_DLLLOAD_FAILED_DRV	= 6,
                    text = "Can not load device driver";
                    break;
                case 7:                                //SGFDX_ERROR_DLLLOAD_FAILED_ALGO = 7,
                    text = "Can not load sgfpamx.dll";
                    break;

                case 51:                //SGFDX_ERROR_SYSLOAD_FAILED	   = 51,	// system file load fail
                    text = "Can not load driver kernel file";
                    break;

                case 52:                //SGFDX_ERROR_INITIALIZE_FAILED  = 52,   // chip initialize fail
                    text = "Failed to initialize the device";
                    break;

                case 53:                //SGFDX_ERROR_LINE_DROPPED		   = 53,   // image data drop
                    text = "Data transmission is not good";
                    break;

                case 54:                //SGFDX_ERROR_TIME_OUT			   = 54,   // getliveimage timeout error
                    text = "Time out";
                    break;

                case 55:                //SGFDX_ERROR_DEVICE_NOT_FOUND	= 55,   // device not found
                    text = "Device not found";
                    break;

                case 56:                //SGFDX_ERROR_DRVLOAD_FAILED	   = 56,   // dll file load fail
                    text = "Can not load driver file";
                    break;

                case 57:                //SGFDX_ERROR_WRONG_IMAGE		   = 57,   // wrong image
                    text = "Wrong Image";
                    break;

                case 58:                //SGFDX_ERROR_LACK_OF_BANDWIDTH  = 58,   // USB Bandwith Lack Error
                    text = "Lack of USB Bandwith";
                    break;

                case 59:                //SGFDX_ERROR_DEV_ALREADY_OPEN	= 59,   // Device Exclusive access Error
                    text = "Device is already opened";
                    break;

                case 60:                //SGFDX_ERROR_GETSN_FAILED		   = 60,   // Fail to get Device Serial Number
                    text = "Device serial number error";
                    break;

                case 61:                //SGFDX_ERROR_UNSUPPORTED_DEV		   = 61,   // Unsupported device
                    text = "Unsupported device";
                    break;

                // Extract & Verification error
                case 101:                //SGFDX_ERROR_FEAT_NUMBER		= 101, // utoo small number of minutiae
                    text = "The number of minutiae is too small";
                    break;

                case 102:                //SGFDX_ERROR_INVALID_TEMPLATE_TYPE		= 102, // wrong template type
                    text = "Template is invalid";
                    break;

                case 103:                //SGFDX_ERROR_INVALID_TEMPLATE1		= 103, // wrong template type
                    text = "1st template is invalid";
                    break;

                case 104:                //SGFDX_ERROR_INVALID_TEMPLATE2		= 104, // vwrong template type
                    text = "2nd template is invalid";
                    break;

                case 105:                //SGFDX_ERROR_EXTRACT_FAIL		= 105, // extraction fail
                    text = "Minutiae extraction failed";
                    break;

                case 106:                //SGFDX_ERROR_MATCH_FAIL		= 106, // matching  fail
                    text = "Matching failed";
                    break;

            }

            text = funcName + " Error # " + iError + " :" + text;
            StatusBars.Text = text;
        }
        private void DrawImage(Byte[] imgData, PictureBox picBox)
        {
            int colorval;
            Bitmap bmp = new Bitmap(m_ImageWidth, m_ImageHeight);
            picBox.Image = (Image)bmp;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    colorval = (int)imgData[(j * m_ImageWidth) + i];
                    bmp.SetPixel(i, j, Color.FromArgb(colorval, colorval, colorval));
                }
            }
            picBox.Refresh();
        }
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == (int)SGFPMMessages.DEV_AUTOONEVENT)
            {
                if (message.WParam.ToInt32() == (Int32)SGFPMAutoOnEvent.FINGER_ON)
                    StatusBars.Text = "Device Message: Finger On";
                else if (message.WParam.ToInt32() == (Int32)SGFPMAutoOnEvent.FINGER_OFF)
                    StatusBars.Text = "Device Message: Finger Off";
            }
            base.WndProc(ref message);
        }
        public int verify(Byte[] image1, Byte[] image2, Byte[] image3)
        {
            string select = "SELECT PID, Finger1, Finger2, Finger3 FROM PatientRegistration";
            using (cmd = new SqlCommand(select, cnn))
            {
                using (dr = cmd.ExecuteReader())
                {
                    Int32 iError;
                    bool matched1 = false;
                    bool matched2 = false;
                    bool matched3 = false;
                    SGFPMSecurityLevel secu_level = SGFPMSecurityLevel.NORMAL;
                    int id = -1;

                    while (dr.Read())
                    {
                        matched1 = false;
                        matched2 = false;
                        matched3 = false;
                        iError = m_FPM.MatchTemplate((Byte[])dr[1], image1, secu_level, ref matched1);
                        iError = m_FPM.MatchTemplate((Byte[])dr[2], image2, secu_level, ref matched2);
                        iError = m_FPM.MatchTemplate((Byte[])dr[3], image3, secu_level, ref matched3);

                        if (iError == (Int32)SGFPMError.ERROR_NONE)
                        {
                            if (matched1 & matched2 & matched3)
                            {
                                id = int.Parse(dr[0].ToString());
                                break;
                            }
                        }
                        else
                        {
                            DisplayError("MatchTemplate()", iError);
                            break;
                        }
                    }
                    return id;
                }
            }
        }

        private void btnEnumDevice_Click(object sender, EventArgs e)
        {
            Int32 iError;
            string enum_device;

            cmbDeviceName.Items.Clear();

            // Enumerate Device
            iError = m_FPM.EnumerateDevice();

            // Get enumeration info into SGFPMDeviceList
            m_DevList = new SGFPMDeviceList[m_FPM.NumberOfDevice];

            for (int i = 0; i < m_FPM.NumberOfDevice; i++)
            {
                m_DevList[i] = new SGFPMDeviceList();
                m_FPM.GetEnumDeviceInfo(i, m_DevList[i]);
                enum_device = m_DevList[i].DevName.ToString() + " : " + m_DevList[i].DevID;
                cmbDeviceName.Items.Add(enum_device);
            }

            if (cmbDeviceName.Items.Count > 0)
            {
                // Add Auto Selection
                enum_device = "Auto Selection";
                cmbDeviceName.Items.Add(enum_device);

                cmbDeviceName.SelectedIndex = 0;  //First selected one
            }
        }

        private void btnR1_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 iError;
                Byte[] fp_image;
                Int32 img_qlty;

                m_RegMin1 = new Byte[400];
                fp_image = new Byte[m_ImageWidth * m_ImageHeight];
                img_qlty = 0;

                iError = m_FPM.GetImage(fp_image);

                m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
                prgR1.Value = img_qlty;

                if (iError == (Int32)SGFPMError.ERROR_NONE)
                {
                    DrawImage(fp_image, picR1);
                    iError = m_FPM.CreateTemplate(fp_image, m_RegMin1);

                    if (iError == (Int32)SGFPMError.ERROR_NONE)
                        StatusBars.Text = "First image is captured";
                    else
                        DisplayError("CreateTemplate()", iError);
                }
                else
                    DisplayError("GetImage()", iError);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }
        }

        private void btnR2_Click(object sender, EventArgs e)
        {
            try
            {
                //Byte[] m_RegMin2;
                Int32 iError;
                Byte[] fp_image;
                Int32 img_qlty;

                m_RegMin2 = new Byte[400];
                fp_image = new Byte[m_ImageWidth * m_ImageHeight];
                img_qlty = 0;

                iError = m_FPM.GetImage(fp_image);

                m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
                prgR2.Value = img_qlty;

                if (iError == (Int32)SGFPMError.ERROR_NONE)
                {
                    DrawImage(fp_image, picR2);
                    iError = m_FPM.CreateTemplate(fp_image, m_RegMin2);

                    if (iError == (Int32)SGFPMError.ERROR_NONE)
                        StatusBars.Text = "First image is captured";
                    else
                        DisplayError("CreateTemplate()", iError);
                }
                else
                    DisplayError("GetImage()", iError);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnR3_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 iError;
                Byte[] fp_image;
                Int32 img_qlty;

                m_RegMin3 = new Byte[400];
                fp_image = new Byte[m_ImageWidth * m_ImageHeight];
                img_qlty = 0;

                iError = m_FPM.GetImage(fp_image);

                m_FPM.GetImageQuality(m_ImageWidth, m_ImageHeight, fp_image, ref img_qlty);
                prgR3.Value = img_qlty;

                if (iError == (Int32)SGFPMError.ERROR_NONE)
                {
                    DrawImage(fp_image, picR3);
                    iError = m_FPM.CreateTemplate(fp_image, m_RegMin3);

                    if (iError == (Int32)SGFPMError.ERROR_NONE)
                        StatusBars.Text = "First image is captured";
                    else
                        DisplayError("CreateTemplate()", iError);
                }
                else
                    DisplayError("GetImage()", iError);
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message);
            }
        }

        private void btnVerifyFingerPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 iError;
                bool matched1 = false;
                bool matched2 = false;
                SGFPMSecurityLevel secu_level;
                Int32 match_score = 0;

                secu_level = SGFPMSecurityLevel.BELOW_NORMAL;

                iError = m_FPM.MatchTemplate(m_RegMin1, m_RegMin3, secu_level, ref matched1);
                iError = m_FPM.MatchTemplate(m_RegMin2, m_RegMin3, secu_level, ref matched2);
                iError = m_FPM.GetMatchingScore(m_RegMin1, m_RegMin2, ref match_score);

                if (picR1 != null && picR2 != null && picR3 != null)
                {
                    if (iError == (Int32)SGFPMError.ERROR_NONE)
                    {
                        if (matched1 & matched2)
                            StatusBars.Text = "Verification Success, Matching Score: " + match_score;
                        else
                            StatusBars.Text = "Verification Failed";
                    }
                    else
                        DisplayError("MatchTemplate()", iError);
                }
                else
                    MessageBox.Show("Please load an image", "Error Loading Image");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Please Load Image");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Are you sure you want to SUBMIT?", "Patient Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
            if (r == DialogResult.Yes)
            {
                if (IsValidateData())
                {
                    using (cnn = new SqlConnection(PatientManagementSystem.Properties.Settings.Default.PatientDBConn))
                    {
                        cnn.Open();
                        string insert = "INSERT INTO PatientRegistration(Surname,FirstName,OtherName,Gender,DOB,Address,Nationality,"
                            + "State,LGA,Occupation,NextOfKin,PhoneNo,MaritalStatus,BloodGroup,Image,Capability,Finger1,Finger2,Finger3)"
                            + "VALUES(@Surname,@FirstName,@OtherName,@Gender,@DOB,@Address,@Nationality,@State,@LGA,@Occupation,@NextOfKin,"
                            + "@PhoneNo,@MaritalStatus,@BloodGroup,@Image,@Capability,@Finger1,@Finger2,@Finger3)";
                        int k = verify(m_RegMin1, m_RegMin2, m_RegMin3);
                        if (k == -1)
                        {
                            using (cmd = new SqlCommand(insert, cnn))
                            {
                                cmd.Parameters.AddWithValue("@Surname", txtSurname.Text);
                                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                                cmd.Parameters.AddWithValue("@OtherName", txtOtherName.Text);
                                cmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
                                cmd.Parameters.AddWithValue("@DOB", dateTimePicker1.Text);
                                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                                cmd.Parameters.AddWithValue("@Nationality", txtNationality.Text);
                                cmd.Parameters.AddWithValue("@State", cmbState.Text);
                                cmd.Parameters.AddWithValue("@LGA", txtLGA.Text);
                                cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                                cmd.Parameters.AddWithValue("@NextOfKin", txtNextOfKin.Text);
                                cmd.Parameters.AddWithValue("@PhoneNo", mskPhoneNumber.Text);
                                cmd.Parameters.AddWithValue("@MaritalStatus", cmbMaritalStatus.Text);
                                cmd.Parameters.AddWithValue("@BloodGroup", cmbBloodGroup.Text);
                                cmd.Parameters.AddWithValue("@Capability", cmbCapability.Text);
                                cmd.Parameters.AddWithValue("@Finger1", m_RegMin1);
                                cmd.Parameters.AddWithValue("@Finger2", m_RegMin2);
                                cmd.Parameters.AddWithValue("@Finger3", m_RegMin3);

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
                        {
                            StatusBars.Text = "You Have Registered Before";
                            m_FPM.EnableAutoOnEvent(false, 0);
                        }
                    } 
                }
            }
        }

        void clearControl()
        {
            txtAddress.Text = "";
            txtFirstName.Text = "";
            txtLGA.Text = "";
            txtNationality.Text = "";
            txtNextOfKin.Text = "";
            txtOccupation.Text = "";
            txtOtherName.Text = "";
            txtSurname.Text = "";
            cmbBloodGroup.Text = "";
            cmbCapability.Text = "";
            cmbDeviceName.Text = "";
            cmbGender.Text = "";
            cmbMaritalStatus.Text = "";
            cmbState.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - Patient Management System";
            m_LedOn = false;
            m_FPM = new SGFingerPrintManager();
            EnumerateBtn_Click(sender, e);  
        }

        private void btnInitDevice_Click_1(object sender, EventArgs e)
        {
            if (btnInitDevice.Text == "Initialize Device")
            {
                if (m_FPM.NumberOfDevice == 0)
                {
                    StatusBars.Text = "Please Plug Device And Then Click On Enumerate Device";
                    return;
                }
                if (cmbDeviceName.SelectedIndex == -1) return;
                Int32 iError;
                SGFPMDeviceName device_name;
                Int32 device_id;

                Int32 numberOfDevices = cmbDeviceName.Items.Count;
                Int32 deviceSelected = cmbDeviceName.SelectedIndex;
                Boolean autoSelection = (deviceSelected == (numberOfDevices - 1));  // Last index

                if (autoSelection)
                {
                    // Order of search: Hamster IV(HFDU04) -> Plus(HFDU03) -> III (HFDU02)
                    device_name = SGFPMDeviceName.DEV_AUTO;

                    device_id = (Int32)(SGFPMPortAddr.USB_AUTO_DETECT);
                }
                else
                {
                    device_name = m_DevList[deviceSelected].DevName;
                    device_id = m_DevList[deviceSelected].DevID;
                }

                iError = m_FPM.Init(device_name);
                iError = m_FPM.OpenDevice(device_id);

                iError = m_FPM.Init(device_name);
                iError = m_FPM.OpenDevice(device_id);
                if (iError == (Int32)SGFPMError.ERROR_NONE)
                {
                    SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
                    Int32 iError2 = m_FPM.GetDeviceInfo(pInfo);

                    if (iError2 == (Int32)SGFPMError.ERROR_NONE)
                    {
                        m_ImageWidth = pInfo.ImageWidth;
                        m_ImageHeight = pInfo.ImageHeight;
                    }

                    //StatusBars.ForeColor = System.Drawing.Color.Red;
                    StatusBars.Text = "Device Initialization Success";

                    btnInitDevice.Text = "Close Device";


                }
                else
                    DisplayError("OpenDevice()", iError);
            }
            else
            {
                m_FPM.CloseDevice();
                btnInitDevice.Text = "Open Device";

                btnInitDevice.Text = "Device Close";
            }
        }

        private bool IsValidateData()
        {
            if (Validators.IsPresent(txtSurname) &&
                Validators.IsPresent(txtFirstName) &&
                Validators.IsPresent(txtOtherName) &&
                Validators.IsPresent(cmbGender) &&
                Validators.IsImagePresent(picImage) &&
                Validators.IsPresent(dateTimePicker1) &&
                Validators.IsPresent(txtAddress) &&
                Validators.IsPresent(txtNationality) &&
                Validators.IsPresent(cmbState) &&
                Validators.IsPresent(txtLGA) &&
                Validators.IsPresent(txtOccupation) &&
                Validators.IsPresent(txtNextOfKin) &&
                Validators.IsPresent(mskPhoneNumber) &&
                Validators.IsPresent(cmbMaritalStatus) &&
                Validators.IsPresent(cmbBloodGroup) &&
                Validators.IsPresent(cmbCapability) &&
                Validators.IsPhoneNumber(mskPhoneNumber))
            {
                return true;
            }
            else
                return false;
        }

        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Invalid Input, Characters only", "Wrong Input Data");
                e.Handled = true;
            } 
        }
    }
}
