using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Door_Code_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(label2, "Double click to copy to clipboard!");
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            /*
                1. we start with a 10-digit base10 integer: for example, 0007956654.
                2. we convert that to binary: 11110010110100010101110.
                3. strip the first 8 (that's the facility code section; we don't use it). it becomes 110100010101110. 
                4. convert that back to decimal. finally, the door code for badge 0007956654 is 26798.

                see https://www.getkisi.com/blog/how-to-calculate-facility-code-using-card-bit-calculators for solid explanation
             */
            if (textBox1.Text.Length == 10) {
                // create binary string from input numbers - only the last 16 digits. this is step 2
                string s24 = Convert.ToString(Int32.Parse(textBox1.Text), 2);
                // depending on the number, it might omit a leading zero - ensure that's here so conversions are always consistently done on 24-bit strings.
                if (s24.Length < 24) {
                    s24 = "0" + s24;
                }
                //MessageBox.Show(s24.ToString() + " - length: " + s24.Length.ToString());
                string s16 = s24.Substring(8); // slice off the first 8 - step 3
                // convert binary string back to decimal (int32). step 4.
                label2.Text = Convert.ToInt32(s16, 2).ToString();
                label2.Visible = true;
            }
            else
            {
                label2.Text = "";
                label2.Visible = false;
            }
        }
    }
}
