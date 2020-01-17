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
        private static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Form1()
        {
            InitializeComponent();
            logger.Fatal("log1");
            logger.Error("log2");
            logger.Warn("log3");
            logger.Info("log4");
            logger.Debug("log5");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var aaaa = new RazorSample();
            aaaa.Create();
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
