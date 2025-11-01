using SREmulator.Attributes;
using SREmulator.GUI.Model;
using SREmulator.Localizations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            var commandArgs = new List<string>();

            // 命令类型
            commandArgs.Add(isAverageWarps ? "achieve-average-warps" : "achieve-chance");

            // 卡池类型
            commandArgs.Add("--new-warp");
            commandArgs.Add("character");

            // 卡池名称
            AddRequiredArg(commandArgs, "--warp-name", cmbWarpName.SelectedItem as string);

            // 目标
            if (cmbTarget.SelectedItem != null && !string.IsNullOrWhiteSpace(cmbTargetCount.Text))
            {
                commandArgs.Add("--target");
                commandArgs.Add(cmbTarget.SelectedItem.ToString());
                commandArgs.Add(cmbTargetCount.Text);
            }

            // 资源
            AddNumericArg(commandArgs, "--stellar-jade", txtStellarJade.Text);
            AddNumericArg(commandArgs, "--star-rail-special-pass", txtStellarTicket.Text);

            // 版本
            if (cmbCardPoolVersion.SelectedItem is WarpVersionInfo ver)
            {
                commandArgs.Add("--warp-version");
                commandArgs.Add(ver.MajorVersion.ToString());
                commandArgs.Add(ver.MinorVersion.ToString());
            }

            // 开关参数
            AddFlagIfChecked(commandArgs, chkguarantee, "--guarantee5");
            AddFlagIfChecked(commandArgs, chkInfiniteResources, "--unlimited-resources");
            AddFlagIfChecked(commandArgs, chknoreward, "--no-rewards");

            // 输出
            if (isExportCSV)
            {
                string outputPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    $"sr_result_{DateTime.Now:yyyyMMddHHmmss}.csv"
                );
                commandArgs.Add("--output");
                commandArgs.Add(outputPath);
            }

            // 执行 CLI
            string cliExePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SREmulator.CLI.exe");

            if (!File.Exists(cliExePath))
            {
                txtResult.Text = "错误：未找到 SREmulator.CLI.exe";
                return;
            }

            try
            {
                var startInfo = new ProcessStartInfo(cliExePath)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };

                foreach (var arg in commandArgs)
                    startInfo.ArgumentList.Add(arg);

#if DEBUG
                string cmdLine = $"{cliExePath} {string.Join(" ", commandArgs.Select(QuoteArg))}";
                Console.WriteLine("执行命令: " + cmdLine);
#endif

                using var process = Process.Start(startInfo);
                var output = new StringBuilder();
                var error = new StringBuilder();

                process.OutputDataReceived += (_, e) => { if (e.Data != null) output.AppendLine(e.Data); };
                process.ErrorDataReceived += (_, e) => { if (e.Data != null) error.AppendLine(e.Data); };

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                await process.WaitForExitAsync();

                string result = output.ToString();
                if (!string.IsNullOrEmpty(error.ToString()))
                    result += "\n\n错误信息:\n" + error.ToString();

                txtResult.Text = result.Trim();
            }
            catch (Exception ex)
            {
                txtResult.Text = "执行失败: " + ex.Message;
            }
        }

        // 辅助方法
        private static void AddRequiredArg(List<string> args, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                args.Add(key);
                args.Add(value);
            }
        }

        private static void AddNumericArg(List<string> args, string key, string value)
        {
            if (int.TryParse(value, out _) && !string.IsNullOrWhiteSpace(value))
            {
                args.Add(key);
                args.Add(value);
            }
        }

        private static void AddFlagIfChecked(List<string> args, CheckBox checkBox, string flag)
        {
            if (checkBox.IsChecked == true)
                args.Add(flag);
        }

        // 简单地对含空格的参数加引号（仅用于Debug）
        private static string QuoteArg(string s) => s.Contains(' ') ? $"\"{s}\"" : s;
    }
}
