using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1_ModernWpfUI
{
    /// <summary>
    /// Home.xaml の相互作用ロジック
    /// </summary>
    public partial class Home : Page
    {
        TextBlock txt = new TextBlock();
        public Home()
        {
            InitializeComponent();

            txt.HorizontalAlignment = HorizontalAlignment.Center;
            txt.VerticalAlignment = VerticalAlignment.Center;
            txt.FontSize = 60;
            txt.Text = "ホーム画面";

            Content = txt;
        }
    }
}
