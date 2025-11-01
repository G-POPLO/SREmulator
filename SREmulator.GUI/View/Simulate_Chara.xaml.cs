using SREmulator.Attributes;
using SREmulator.GUI.Model;
using SREmulator.Localizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection; 
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

            // 初始化卡池名称
            InitializeWarpNames();
            // 初始化卡池版本数据
            InitializeWarpVersions();
            // 初始化角色数据
            InitializeCharacters();
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

            // 使用反射动态获取SRVersion枚举中所有以"Ver"开头的字段名
            var versionType = typeof(SRVersion);
            var versionNames = Enum.GetNames(versionType)
                .Where(v => v.StartsWith("Ver") && v != "VersionForWarps")
                .OrderBy(v => v);

            // 为每个版本创建WarpVersionInfo对象
            foreach (var versionName in versionNames)
            {
                // 从版本名称中提取主版本号和次版本号
                // 例如: Ver1p0 -> 主版本号: 1, 次版本号: 0
                string versionNumber = versionName.Substring(3); // 去掉"Ver"前缀
                string[] parts = versionNumber.Split('p');
                
                if (parts.Length == 2 && 
                    int.TryParse(parts[0], out int majorVersion) && 
                    int.TryParse(parts[1], out int minorVersion))
                {
                    string displayName = $"{majorVersion}.{minorVersion}";
                    versions.Add(new WarpVersionInfo(displayName, (int)Enum.Parse<SRVersion>(versionName), majorVersion, minorVersion));
                }
            }

            // 绑定数据到ComboBox
            cmbCardPoolVersion.ItemsSource = versions;
            cmbCardPoolVersion.SelectedIndex = 0;
        }

        /// <summary>
        /// 初始化角色数据
        /// </summary>
        private void InitializeCharacters()
        {
            cmbTarget.ItemsSource = Utils.CreateStringValuePairFromSRKeys(typeof(SRCharacterKeys));
            cmbTarget.SelectedIndex = 0;
        }

        private void InitializeWarpNames()
        {
            cmbWarpName.ItemsSource = Utils.CreateStringValuePairFromSRKeys(typeof(SREventWarpKeys));
            cmbWarpName.SelectedIndex = 0;
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

        /// <summary>
        /// 计算配置抽取可能性按钮点击事件
        /// </summary>
        private async void BtnCalculateChance_Click(object sender, RoutedEventArgs e)
        {
            await ExecuteCommandAsync(false);
        }

        /// <summary>
        /// 计算所需抽数按钮点击事件
        /// </summary>
        private async void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            await ExecuteCommandAsync(true);
        }

        /// <summary>
        /// 导出CSV按钮点击事件
        /// </summary>
        private async void BtnExportCSV_Click(object sender, RoutedEventArgs e)
        {
            await ExecuteCommandAsync(false, true);
        }

        /// <summary>
        /// 执行命令并显示结果
        /// </summary>
        private async Task ExecuteCommandAsync(bool isAverageWarps = false, bool isExportCSV = false)
        {
            try
            {
                // 构建命令参数
                var commandArgs = new List<string>();
                
                // 设置命令类型
                commandArgs.Add(isAverageWarps ? "achieve-average-warps" : "achieve-chance");

                // 添加--new-warp参数，指定角色卡池类型
                commandArgs.Add("--new-warp");
                commandArgs.Add("character");

                // 添加warp-name参数
                commandArgs.Add("--warp-name");
                commandArgs.Add(((StringValuePair)cmbWarpName.SelectedItem).ActualValue);

                // 添加target参数
                commandArgs.Add("--target");
                commandArgs.Add(((StringValuePair)cmbTarget.SelectedItem).ActualValue);
                commandArgs.Add(cmbTargetCount.Text);
                
                // 添加stellar-jade参数
                if (int.TryParse(txtStellarJade.Text, out int stellarJadeCount))
                {
                    commandArgs.Add("--stellar-jade");
                    commandArgs.Add(stellarJadeCount.ToString());
                }
                
                // 添加star-rail-special-pass参数
                if (int.TryParse(txtStellarTicket.Text, out int starRailPassCount))
                {
                    commandArgs.Add("--star-rail-special-pass");
                    commandArgs.Add(starRailPassCount.ToString());
                }
                
                // 添加warp-version参数
                if (cmbCardPoolVersion.SelectedItem is WarpVersionInfo selectedVersion)
                {
                    commandArgs.Add("--warp-version");
                    commandArgs.Add(selectedVersion.MajorVersion.ToString());
                    commandArgs.Add(selectedVersion.MinorVersion.ToString());
                }
                
                // 添加guarantee5参数
                if (chkguarantee.IsChecked == true)
                {
                    commandArgs.Add("--guarantee5");
                }
                
                // 添加output参数（导出CSV）
                if (isExportCSV)
                {

                    commandArgs.Add("--output");
       
                }
                                
                // 添加--unlimited-resources参数
                if (chkInfiniteResources.IsChecked == true)
                {
                    commandArgs.Add("--unlimited-resources");
                }
                
                // 添加--no-rewards参数
                if (chknoreward.IsChecked == true)
                {
                    commandArgs.Add("--no-rewards");
                }
                
                // CLI可执行文件路径
                string cliExePath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "SREmulator.CLI.exe");
                
                
                
                StringBuilder output = new();
                StringBuilder error = new();
                
                // 执行命令
                var process = new System.Diagnostics.Process
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = cliExePath,
                        Arguments = string.Join(" ", commandArgs),
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = false,
                        StandardOutputEncoding = System.Text.Encoding.UTF8,
                        StandardErrorEncoding = System.Text.Encoding.UTF8
                    }
                };
                
                // 添加调试信息，显示完整命令
                string fullCommand = $"{cliExePath} {process.StartInfo.Arguments}";
                output.AppendLine("执行命令: " + fullCommand);
                
                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        output.AppendLine(e.Data);
                    }
                };
                
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                    {
                        error.AppendLine(e.Data);
                    }
                };
                
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                
                await process.WaitForExitAsync();
                
                // 显示结果
                string result = output.ToString();
                if (!string.IsNullOrEmpty(error.ToString()))
                {
                    result += "\n\n错误信息:\n" + error.ToString();
                }
                
                // 在页面上显示结果
                txtResult.Text = result;
                
            }
            catch (Exception ex)
            {
                txtResult.Text = "执行命令时发生错误: " + ex.Message;
            }
        }
    }
}
