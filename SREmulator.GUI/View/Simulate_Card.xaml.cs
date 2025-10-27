using SREmulator.Attributes;
using SREmulator.GUI.Model;
using SREmulator.Localizations;
using SREmulator.SRItems;
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
            InitializeWarpNames();
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


        private void InitializeWarpNames()
        {
            // 创建卡池列表，添加默认选项
            var warpNames = new List<string>();

            // 使用反射获取SRCharacterKeys类中的所有字符常量
            var characterKeysType = typeof(SREventWarpKeys);
            var constFields = characterKeysType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string));

            // 获取每个字符的别名并添加到列表中
            foreach (var field in constFields)
            {
                // 获取SRAliases属性
                var aliasesAttr = field.GetCustomAttribute<SRAliasesAttribute>();
                if (aliasesAttr != null)
                {
                    // 使用字段名作为显示文本
                    warpNames.Add(field.Name);
                }
            }

            // 绑定数据到ComboBox
            cmbWarpName.ItemsSource = warpNames;
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
            // 当"拥有无限抽卡资源"选中时，禁用星轨通票和星琼数量输入框
            bool isInfinite = chkInfiniteResources.IsChecked == true;
            txtStarRailPass.IsEnabled = !isInfinite;
            txtStellarJade.IsEnabled = !isInfinite;
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
            await ExecuteCommandAsync();
        }




        // 简单地对含空格的参数加引号（仅用于Debug）
        private static string QuoteArg(string s) => s.Contains(' ') ? $"\"{s}\"" : s;

        /// <summary>
        /// 执行命令并显示结果
        /// </summary>
        private async Task ExecuteCommandAsync()
        {
            var commandArgs = new List<string>
            {

                // 卡池类型：光锥
                "--new-warp",
                "light-cone"
            };



            // 卡池名称
            AddRequiredArg(commandArgs, "--warp-name", cmbWarpName.SelectedItem as string);

            // 抽取目标
            if (cmbTarget.SelectedItem != null && !string.IsNullOrWhiteSpace(cmbTargetCount.Text))
            {
                commandArgs.Add("--target");
                commandArgs.Add(cmbTarget.SelectedItem.ToString());
                commandArgs.Add(cmbTargetCount.Text);
            }

            // 配置参数
            AddNumericArg(commandArgs, "--stellar-jade", txtStellarJade.Text);
            AddNumericArg(commandArgs, "--star-rail-special-pass", txtStarRailPass.Text);

            // 卡池版本
            if (cmbCardPoolVersion.SelectedItem is WarpVersionInfo ver)
            {
                commandArgs.Add("--warp-version");
                commandArgs.Add(ver.MajorVersion.ToString());
                commandArgs.Add(ver.MinorVersion.ToString());
            }

            // checkbox 选项
            if (chkCalculateAverage.IsChecked == true)
            {
                commandArgs.Add("achieve-average-warps");
            }
            else
            {
                commandArgs.Add("achieve-chance");
            }
            AddFlagIfChecked(commandArgs, chkguarantee, "--guarantee5");
            AddFlagIfChecked(commandArgs, chkInfiniteResources, "--unlimited-resources");
            AddFlagIfChecked(commandArgs, chknoreward, "--no-rewards");

            // 导出 CSV
            if ((bool)chkExportCSV.IsChecked)
            {
                string outputPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    $"sr_lightcone_result_{DateTime.Now:yyyyMMddHHmmss}.csv"
                );
                commandArgs.Add("--output");
                commandArgs.Add(outputPath);
            }

            // CLI 路径
            string cliExePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SREmulator.CLI.exe");

            if (!File.Exists(cliExePath))
            {
                txtResult.Text = "错误：未找到 SREmulator.CLI.exe，请确认程序文件是否存在。\n路径：" + cliExePath;
                return;
            }

            try
            {
                var startInfo = new ProcessStartInfo(cliExePath)
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                };

                // 添加参数（自动处理空格/引号问题）
                foreach (var arg in commandArgs)
                {
                    startInfo.ArgumentList.Add(arg);
                }

#if DEBUG
                string fullCommand = $"{cliExePath} {string.Join(" ", commandArgs.Select(QuoteArg))}";
                Console.WriteLine("执行命令: " + fullCommand);
#endif

                using var process = Process.Start(startInfo);
                var output = new StringBuilder();
                var error = new StringBuilder();

                process.OutputDataReceived += (_, e) =>
                {
                    if (!string.IsNullOrEmpty(e?.Data))
                        output.AppendLine(e.Data);
                };

                process.ErrorDataReceived += (_, e) =>
                {
                    if (!string.IsNullOrEmpty(e?.Data))
                        error.AppendLine(e.Data);
                };

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await process.WaitForExitAsync();

                string result = output.ToString().Trim();
                if (!string.IsNullOrEmpty(error.ToString()))
                {
                    result += "\n\n错误信息:\n" + error.ToString().Trim();
                }

                txtResult.Text = result;
            }
            catch (FileNotFoundException)
            {
                txtResult.Text = "错误：找不到 SREmulator.CLI.exe 文件。";
            }
            catch (Exception ex)
            {
                txtResult.Text = "执行命令时发生未知错误: " + ex.Message;
            }
        }


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


    }
}
