using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PatientManagementSystem
{
    class Validators
    {
        private static string title = "Entry Error";

        public static string Title
        {
            get { return title; }
            set { title = value; }
        }

        public static bool IsPhoneNumber(MaskedTextBox textBox)
        {
            string phoneChars = textBox.Text.Replace(" ", "");
            try
            {
                Convert.ToInt64(phoneChars);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag.ToString() + " must be in this format: "
                    + "9999 999 9999", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsImagePresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.PictureBox")
            {
                PictureBox pictureBox = (PictureBox)control;
                if (pictureBox.Image == null)
                {                   
                    MessageBox.Show(pictureBox.Tag.ToString() + " is a required.", Title);
                    pictureBox.Focus();
                    return false;
                }
                else
                    return true;
            }
            return true;
        }        

        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Tag.ToString() + " is a required field.", Title);
                    textBox.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if(control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.Text == "")
                {
                    MessageBox.Show(comboBox.Tag.ToString() + " is a required field.", Title);
                    comboBox.Focus();
                    return false;
                }
                else
                    return true;
            }
            return true;
        }        
    }
}
