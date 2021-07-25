using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            string url = "https://script.google.com/macros/s/AKfycbxnYNiM32bZPHpp7KRYX00pnqsKZtxmIzI4Ke1jcaahOoz3fuY/exec";
            Dictionary<string, string> dic = new Dictionary<string, string> { {"p1", "田中"}, { "p2", "田中　一 郎" } };

            getSample.Execute(url, dic);

            //Close();
        }
    }
}
