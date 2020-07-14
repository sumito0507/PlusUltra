using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebGet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            GetSample getSample = new GetSample();
            string url = "https://script.google.com/macros/s/AKfycbwF-xQN6KAQnMzcLP-hsTnQUlqSmXrHK_aGZ6jc1cdSFbzuFEFj/exec?p1=AAA&p2=BBB&p3=CCC&p4=DDDD
            getSample.Execute(url);

            //Close();
        }
    }
}
