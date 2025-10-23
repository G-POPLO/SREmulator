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
using SREmulator.GUI.Properties;

namespace SREmulator.GUI.View
{
    /// <summary>
    /// Setting.xaml 的交互逻辑
    /// </summary>
    public partial class Setting : UserControl
    {
        public Setting()
        {
            InitializeComponent();
            Loaded += Setting_Loaded;
            btnSave.Click += BtnSave_Click;
        }

        private void Setting_Loaded(object sender, RoutedEventArgs e)
        {
            // 加载值到UI控件
            LoadSettings();
        }

        private void LoadSettings()
        {        
            chkAutoUpdate.IsChecked = Settings.Default.AutoUpdate;        
            cmbUpdateSource.SelectedIndex = Settings.Default.DownloadIndex;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // 保存UI控件的值到设置文件
            SaveSettings();
            MessageBox.Show("设置已保存", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SaveSettings()
        {          
            Settings.Default.AutoUpdate = chkAutoUpdate.IsChecked ?? false;         
            Settings.Default.DownloadIndex = (byte)cmbUpdateSource.SelectedIndex;                    
            Settings.Default.Save();
        }
    }
}
