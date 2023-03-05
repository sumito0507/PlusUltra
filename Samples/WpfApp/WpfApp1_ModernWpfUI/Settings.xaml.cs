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
    /// Settings.xaml の相互作用ロジック
    /// </summary>
    public partial class Settings : Page
    {
        Grid mainGrid = new Grid();
        public Settings()
        {
            InitializeComponent();

            Button Btn1 = new Button() { Content = "button1" };
            Button Btn2 = new Button() { Content = "button2" };

            Btn1.HorizontalAlignment = HorizontalAlignment.Stretch;
            Btn1.VerticalAlignment = VerticalAlignment.Stretch;
            Btn1.Margin = new Thickness(40);

            Btn2.HorizontalAlignment = HorizontalAlignment.Stretch;
            Btn2.VerticalAlignment = VerticalAlignment.Stretch;
            Btn2.Margin = new Thickness(40);

            Grid.SetRow(Btn1, 0);
            Grid.SetRow(Btn2, 1);

            mainGrid.RowDefinitions.Add(new RowDefinition());
            mainGrid.RowDefinitions.Add(new RowDefinition());

            mainGrid.Children.Add(Btn1);
            mainGrid.Children.Add(Btn2);

            Content = mainGrid;
        }
    }
}
