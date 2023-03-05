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
using ui = ModernWpf.Controls;

namespace WpfApp1_ModernWpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<EachMenu> menu_list = new List<EachMenu>()
            {
                new EachMenu("Home", ui.Symbol.Home, typeof(Home)),
                new EachMenu("Settings", ui.Symbol.Setting, typeof(Settings)),
                new EachMenu("Exit", ui.Symbol.Cancel, typeof(Settings))
            };

        ui.NavigationViewItem[] naviitems;

        ui.Frame mainFrame = new ui.Frame();

        public MainWindow()
        {
            InitializeComponent();

            ui.NavigationView naviview = new ui.NavigationView();
            naviview.IsBackButtonVisible = ui.NavigationViewBackButtonVisible.Collapsed;
            naviview.IsSettingsVisible = false;
            naviview.OpenPaneLength = 150;
            naviview.SelectionChanged += NaviView_SelectionChanged;
            naviview.Content = mainFrame;

            naviitems = new ui.NavigationViewItem[menu_list.Count()];
            for (int i = 0; i < menu_list.Count(); i++)
            {
                naviitems[i] = new ui.NavigationViewItem();
                naviitems[i].Content = menu_list[i].text;
                naviitems[i].Icon = new ui.SymbolIcon(menu_list[i].icon);
                naviitems[i].Tag = menu_list[i].page;
                naviview.MenuItems.Add(naviitems[i]);
            }

            Content = naviview;
        }
        private void NaviView_SelectionChanged(ui.NavigationView sender, ui.NavigationViewSelectionChangedEventArgs args)
        {
            var selectedItem = (ui.NavigationViewItem)args.SelectedItem;

            mainFrame.Navigate((Type)selectedItem.Tag);
        }
        public class EachMenu
        {
            public string text;
            public ui.Symbol icon;
            public Type page;

            public EachMenu(string _text, ui.Symbol _icon, Type _page)
            {
                text = _text;
                icon = _icon;
                page = _page;
            }
        }
    }
}