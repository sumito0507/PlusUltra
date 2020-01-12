using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEx1_TextChanged(object sender, EventArgs e)
        {
            int result = -1;
            if (!int.TryParse(textBoxEx1.Text, out result))
            {
                textBoxEx1.CustomBorderColor = Color.Red;
            }
            else
            {
                textBoxEx1.CustomBorderColor = System.Drawing.SystemColors.ControlText;
            }
        }
    }
}
