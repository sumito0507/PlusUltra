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

namespace WpfApp4
{
    using ui = ModernWpf.Controls;

    // 新しいページが増えたら追加
    public enum NaviIcon
    {
        Home,
        Account,
        Document,

        None,
    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        // 新しいページが増えたら追加
        private static IReadOnlyDictionary<NaviIcon, Type> _pages = new Dictionary<NaviIcon, Type>()
        {
            {NaviIcon.Home, typeof(Pages.HomePage)},
            {NaviIcon.Account, typeof(Pages.AccountPage)},
            {NaviIcon.Document, typeof(Pages.DocumentPage)},
            // 空ページ
            {NaviIcon.None, typeof(Pages.BlankPage)},
        };


        public MainWindow()
        {
            InitializeComponent();
        }

        private void NaviView_SelectionChanged(ui.NavigationView sender, ui.NavigationViewSelectionChangedEventArgs args)
        {
            try
            {
                var selectedItem = (ui.NavigationViewItem)args.SelectedItem;
                // Tag取得
                string iconName = selectedItem.Tag?.ToString();
                // ヘッダー設定
                sender.Header = iconName;

                if (Enum.TryParse(iconName, out NaviIcon icon))
                {
                    // 対応するページ表示
                    ContentFrame.Navigate(_pages[icon]);
                }
                else
                {
                    // 空ページ表示
                    ContentFrame.Navigate(_pages[NaviIcon.None]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
