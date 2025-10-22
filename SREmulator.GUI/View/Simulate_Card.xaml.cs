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
using SREmulator.Localizations;
using System.Reflection;
using SREmulator.Attributes;
using SREmulator.SRItems;

namespace SREmulator.GUI.View
{
    /// <summary>
    /// 光锥跃迁页面的交互逻辑
    /// </summary>
    public partial class Simulate_Card : Page
    {
        public Simulate_Card()
        {
            InitializeComponent();
            Loaded += SimulateCard_Loaded;
        }

        private void SimulateCard_Loaded(object sender, RoutedEventArgs e)
        {
            // 初始化时设置事件处理程序
            chkInfiniteResources.Checked += ChkInfiniteResources_Checked;
            chkInfiniteResources.Unchecked += ChkInfiniteResources_Unchecked;
            // 初始化卡池版本数据
            InitializeWarpVersions();
            // 初始化角色数据
            InitializeCharacters();
            // 初始化状态
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
            // 当"拥有无限抽卡资源"选中时，禁用星轨通票和星琼数量输入框
            bool isInfinite = chkInfiniteResources.IsChecked == true;
            txtStarRailPassCount.IsEnabled = !isInfinite;
            txtStellarJadeCount.IsEnabled = !isInfinite;
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
        /// 初始化光锥数据
        /// </summary>
        private void InitializeCharacters()
        {
            // 创建光锥列表
            var lightConeItems = new List<string>();

            // 使用反射获取SRLightConeKeys类中的所有光锥常量
            var lightConeKeysType = typeof(SRLightConeKeys);
            var constFields = lightConeKeysType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string));

            // 获取每个光锥的别名并添加到列表中
            foreach (var field in constFields)
            {
                // 获取SRAliases属性
                var aliasesAttr = field.GetCustomAttribute<SRAliasesAttribute>();
                if (aliasesAttr != null)
                {
                    // 使用字段名作为显示文本
                    string lightConeName = field.Name;
                    lightConeItems.Add(lightConeName);
                }
            }

            // 绑定数据到ComboBox
            cmbTarget.ItemsSource = lightConeItems;
            // 只有当列表不为空时才设置选中索引
            if (lightConeItems.Count > 0)
            {
                cmbTarget.SelectedIndex = 0;
            }
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
                commandArgs.Add(isAverageWarps ? "achieve-average-warps" : "result-statistics");
                
                // 添加warp-name参数
                if (cmbTarget.SelectedItem != null)
                {
                    string targetName = cmbTarget.SelectedItem.ToString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(targetName))
                    {
                        commandArgs.Add("--warp-name");
                        commandArgs.Add(targetName);
                    }
                }
                
                // 添加stellar-jade参数
                int stellarJadeCount;
                if (int.TryParse(txtStellarJadeCount.Text, out stellarJadeCount))
                {
                    commandArgs.Add("--stellar-jade");
                    commandArgs.Add(stellarJadeCount.ToString());
                }
                
                // 添加star-rail-special-pass参数
                int starRailPassCount;
                if (int.TryParse(txtStarRailPassCount.Text, out starRailPassCount))
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
                
                // 添加--new-warp参数，指定光锥卡池类型
                commandArgs.Add("--new-warp");
                commandArgs.Add("light-cone");
                
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
                        CreateNoWindow = true,
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
