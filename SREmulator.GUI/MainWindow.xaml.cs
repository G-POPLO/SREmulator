using iNKORE.UI.WPF.Modern.Controls;
using SREmulator.GUI.Model;
using SREmulator.GUI.View;
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

namespace SREmulator.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            contentFrame.Navigate(new Simulate_Chara());
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.AutoUpdate)
            {
                await Update.CheckForUpdatesAsync(); // ¼ì²é¸üÐÂ
            }
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is NavigationViewItem item)
            {
                switch (item.Tag.ToString())
                {
                    case "Simulate_Chara":
                        contentFrame.Navigate(new Simulate_Chara());
                        break;
                    case "Simulate_Card":
                        contentFrame.Navigate(new Simulate_Card());
                        break;
                    case "Setting":
                        contentFrame.Navigate(new Setting());
                        break;
                    case "About":
                        contentFrame.Navigate(new About());
                        break;
                }
            }
        }
    }
}