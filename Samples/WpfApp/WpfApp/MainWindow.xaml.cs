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

namespace WpfApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _textToday = string.Empty;
        public string TextToday
        {
            get
            {
                _textToday = DateTime.Today.ToString("M月d日 (ddd)");
                return _textToday;
            }
            set
            {
                _textToday = value;
            }
        }
        public string _textOvertime { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += (sender, e) => this.DragMove();

            //// 本日日付
            //textToday.Text = DateTime.Today.ToString("M月d日 (ddd)");
            // 勤務時間
            {
                string start = "09:15";
                string end = "17:30";
                textWorkingTime.Text = " 勤務時間    " + start + " ～ " + end + " ";
            }
            // 時間外
            {
                string overtimeSum = "01:30";
                textOvertime.Text = " 延長時間    " + overtimeSum + " ";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
