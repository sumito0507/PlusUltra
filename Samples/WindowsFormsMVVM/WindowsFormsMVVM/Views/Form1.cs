using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMVVM
{
    public partial class Form1 : Form
    {
        protected ViewModel ViewModel { get; private set; } = new ViewModel();
        public Form1()
        {
            InitializeComponent();
            label1.Bind(() => ViewModel.Counter);
            button1.Bind(ViewModel.UpCommand);
            button2.Bind(ViewModel.DownCommand);
        }
    }
}
