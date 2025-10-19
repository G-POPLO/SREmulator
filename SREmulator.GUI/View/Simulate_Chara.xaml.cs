using SREmulator.GUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using SREmulator; // 添加对SREmulator命名空间的引用
using System.Reflection; // 添加反射命名空间

namespace SREmulator.GUI.View
{
    /// <summary>
    /// Simulate_Chara.xaml 的交互逻辑
    /// </summary>
    public partial class Simulate_Chara : Page
    {
        public Simulate_Chara()
        {
            InitializeComponent();
            Loaded += Simulate_Chara_Loaded;
        }

        private void Simulate_Chara_Loaded(object sender, RoutedEventArgs e)
        {
            // 绑定无限资源复选框事件
            chkInfiniteResources.Checked += ChkInfiniteResources_Checked;
            chkInfiniteResources.Unchecked += ChkInfiniteResources_Unchecked;

            // 初始化卡池版本数据
            InitializeWarpVersions();

            // 初始化资源输入状态
            UpdateResourceInputState();
        }

        /// <summary>
        /// 初始化卡池版本数据
        /// </summary>
        private void InitializeWarpVersions()
        {
            // 创建版本信息列表
            var versions = new List<WarpVersionInfo>();

            // 使用反射动态获取SRVersion枚举中所有以"Ver"开头的版本值
            var versionType = typeof(SRVersion);
            var versionValues = Enum.GetValues(versionType).Cast<SRVersion>()
                .Where(v => v.ToString().StartsWith("Ver") && v != SRVersion.VersionForWarps)
                .OrderBy(v => v); // 按枚举值排序

            // 为每个版本创建WarpVersionInfo对象
            foreach (var version in versionValues)
            {
                string versionName = version.ToString();
                // 从版本名称中提取主版本号和次版本号
                // 例如: Ver1p0 -> 主版本号: 1, 次版本号: 0
                string versionNumber = versionName.Substring(3); // 去掉"Ver"前缀
                string[] parts = versionNumber.Split('p');
                
                if (parts.Length == 2 && 
                    int.TryParse(parts[0], out int majorVersion) && 
                    int.TryParse(parts[1], out int minorVersion))
                {
                    string displayName = $"{majorVersion}.{minorVersion}";
                    versions.Add(new WarpVersionInfo(displayName, (int)version, majorVersion, minorVersion));
                }
            }

            // 绑定数据到ComboBox
            cmbCardPoolVersion.ItemsSource = versions;
            cmbCardPoolVersion.SelectedIndex = 0;
        }

        private void ChkInfiniteResources_Checked(object sender, RoutedEventArgs e)
        {
            UpdateResourceInputState();
        }

        private void ChkInfiniteResources_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateResourceInputState();
        }

        private void UpdateResourceInputState()
        {
            bool isInfinite = chkInfiniteResources.IsChecked == true;
            txtStellarJade.IsEnabled = !isInfinite;
            txtStellarTicket.IsEnabled = !isInfinite;
        }

        /// <summary>
        /// 限制TextBox只允许输入数字
        /// </summary>
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // 使用正则表达式验证输入是否为数字
            e.Handled = !IsTextAllowed(e.Text);
        }

        /// <summary>
        /// 禁止粘贴非数字内容
        /// </summary>
        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        /// <summary>
        /// 检查文本是否只包含数字
        /// </summary>
        private static bool IsTextAllowed(string text)
        {
            // 使用正则表达式检查文本是否只包含数字
            return Regex.IsMatch(text, @"^[0-9]+$");
        }
    }
}
