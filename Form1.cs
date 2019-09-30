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
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 10) {
                // create binary string from input numbers - only the last 16 digits
                string s = Convert.ToString(Int32.Parse(textBox1.Text), 2).Substring(8);
                // convert binary string to Int32
                label2.Text = Convert.ToInt32(s, 2).ToString();
            }
        }
    }
}
