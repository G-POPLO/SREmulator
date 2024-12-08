using SREmulator.Localizations;
using SREmulator.SRItems;
using SREmulator.SRPlayers;
using SREmulator.SRWarps;
using SREmulator.SRWarps.CommonWarps;
using SREmulator.SRWarps.EventWarps;

namespace SREmulator
{
    public static class CLI
    {
        public const string Help =
            """
            USAGE:
                sremulator.exe <COMMAND> [OPTIONS]
            
            COMMANDS:
                result-statistics                   统计所有抽取结果
                achieve-average-warps               计算实现目标所需抽数
                achieve-chance                      计算实现目标的可能性

            OPTIONS:
                --pause                             每次抽取后暂停（按任意键继续）
                --return                            前一次的抽取结果显示将被后一次的抽取结果覆盖
                --silent                            不显示每抽获取的物品

                --star-rail-pass <count>            设置星轨通票数量
                --star-rail-special-pass <count>    设置星轨专票数量
                --undying-starlight <count>         设置未熄的星芒数量
                --stellar-jade <count>              设置星琼数量
                --oneiric-shard <count>             设置古老梦华数量

                --counter5 <count>                  设置已多少抽未出5星
                --guarantee5                        设置为有大保底

                --warp-name <name>                  设置要抽取的卡池（参见 WARP-NAMES）
                --warp-version <major> <minor>      设置卡池所在的版本（影响可抽取到的四星对象）

                --character-event-warp              设置卡池类型为角色活动跃迁（UP角色池）
                --light-cone-event-warp             设置卡池类型为光锥活动跃迁（UP光锥池）
                --stellar-warp                      设置卡池类型为群星跃迁（常驻池）
                --departure-warp                    设置卡池类型为始发跃迁（新手池）

                --target-count5 <count>             设置目标5星数量（限定池中表示UP5星角色，普池中表示特定5星角色）
                --target-count4 <count>             设置目标4星数量（限定池中表示特定UP4星角色，普池中表示特定4星角色）
                --attempts <count>                  设置计算抽数或可能性时的尝试次数

                --help                              显示该帮助
                --language <name>                   更改语言（目前仅支持 zh-Hans, en-US）

            WARP-NAMES:
                希儿池: seele, xier
                景元池: jing-yuan, jingyuan
                银狼池: silver-wolf, silverwolf, yinlang
                罗刹池: luocha
                刃池: blade, ren
                卡芙卡池: kafka, kafuka
                丹恒•饮月池: dan-heng-imbibitor-lunae, dan-heng, danhengyinyue, yinyue, danheng
                符玄池: fu-xuan, fuxuan
                镜流池: jingliu
                托帕&账账池: topaz-numby, topaz, tuopa-zhangzhang, tuopa
                藿藿池: huohuo
                银枝池: argenti, yinzhi
                阮•梅池: ruan-mei, ruanmei
                真理医生池: dr-ratio, ratio, zhenliyisheng
                黑天鹅池: black-swan, heitiane
                花火池: sparkle, huahuo
                黄泉池: acheron, huangquan
                砂金池: aventurine, shajin
                知更鸟池: robin, zhigengniao
                波提欧池: boothill, botiou
                流萤池: firefly, liuying
                翡翠池: jade, feicui
                云璃池: yunli
                椒丘池: jiaoqiu
                飞霄池: feixiao
                灵砂池: lingsha
                乱破池: rappa, luanpo
                星期日池: sunday, xingqiri
                忘归人池: fugue, wangguiren
            """;

        public static void Execute(CLIArgs args)
        {
            if (args.Help)
            {
                Console.WriteLine(Help);
                return;
            }

            if (args.Language is not null)
            {
                Localization.Culture = new(args.Language);
            }

            if (args.Command is "achieve-average-warps")
            {
                AchieveAverageWarps(args);
            }
            else if (args.Command is "achieve-chance")
            {
                AchieveChance(args);
            }
            else if (args.Command is "result-statistics")
            {
                ResultStatistics(args);
            }
            else
            {
                Console.WriteLine(Help);
            }
        }

        private static ConsoleColor SetColor(ISRWarpResultItem item)
        {
            var origColor = Console.ForegroundColor;
            Console.ForegroundColor = item.Rarity switch
            {
                SRItemRarity.Star5 => ConsoleColor.Yellow,
                SRItemRarity.Star4 => ConsoleColor.Magenta,
                SRItemRarity.Star3 => ConsoleColor.Gray,
                _ => Console.ForegroundColor,
            };
            return origColor;
        }

        internal static void ResultStatistics(CLIArgs args)
        {
            Dictionary<ISRWarpResultItem, int> result = [];
            int maxNameLength = 0;
            int counter = 0;

            var warp = args.Warp;
            var player = args.Player;

            while (warp.TryWarp(player, out var item))
            {
                result.TryGetValue(item, out var count);
                result[item] = count + 1;
                counter++;

                if (args.Silent) continue;

                var origColor = SetColor(item);

                maxNameLength = Math.Max(maxNameLength, item.Name.Length);

                if (args.Return)
                {
                    if (counter > 1)
                    {
                        Console.CursorLeft = 0;
                        Console.CursorTop--;
                    }
                    Console.WriteLine(item.Name.PadRight(maxNameLength * 2));
                }
                else
                {
                    Console.WriteLine(item.Name);
                }

                Console.ForegroundColor = origColor;

                if (args.Pause) _ = Console.ReadKey(true);
            }

            Console.WriteLine("----------");
            Console.WriteLine(counter);
            foreach (var pair in result.OrderByDescending(pair => pair.Key.Rarity).ThenByDescending(pair => pair.Value))
            {
                var origColor = SetColor(pair.Key);
                Console.WriteLine(pair.Key.Name);
                Console.ForegroundColor = origColor;
                Console.WriteLine($"{pair.Value}\t({(double)pair.Value / counter:0.00%})");
                Console.WriteLine();
            }
        }

        internal static void AchieveAverageWarps(CLIArgs args)
        {
            int total = args.Attempts;
            int warps = 0;
            var warp = args.Warp;

            ISRWarpResultItem[] star5s, star4s;
            if (args.WarpType is SRWarpType.CharacterEventWarp or SRWarpType.LightConeEventWarp)
            {
                star5s = [warp.Up5];
                star4s = warp.Up4;
            }
            else
            {
                star5s = warp.Common5Characters;
                star4s = warp.Common4Characters;
            }
            ISRWarpResultItem star5 = star5s[0], star4 = star4s[0];


            for (int i = 0; i < total; i++)
            {
                SRPlayer player = args.Player;
                int counter = 0, count5 = args.TargetCount5, count4 = args.TargetCount4;
                player.WarpCurrencyStats.StarRailPass = int.MaxValue;
                player.WarpCurrencyStats.StarRailSpecialPass = int.MaxValue;

                while (warp.TryWarp(player, out var item))
                {
                    counter++;
                    if (count5 > 0 && star5.Equals(item))
                    {
                        count5--;
                    }
                    if (count4 > 0 && star4.Equals(item))
                    {
                        count4--;
                    }
                    if (count5 <= 0 && count4 <= 0)
                    {
                        warps += counter;
                        break;
                    }
                }
            }

            if (args.TargetCount5 > 0)
            {
                var origColor = SetColor(star5);
                Console.Write(string.Join(" / ", star5s.Select(item => item.Name)));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($": {args.TargetCount5}");
                Console.ForegroundColor = origColor;
            }
            if (args.TargetCount4 > 0)
            {
                var origColor = SetColor(star4);
                Console.Write(string.Join(" / ", star4s.Select(item => item.Name)));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($": {args.TargetCount4}");
                Console.ForegroundColor = origColor;
            }
            Console.WriteLine(((double)warps / total).ToString("0.##"));
        }

        internal static void AchieveChance(CLIArgs args)
        {
            int total = args.Attempts;
            int successful = 0;
            var warp = args.Warp;

            ISRWarpResultItem[] star5s, star4s;
            if (args.WarpType is SRWarpType.CharacterEventWarp or SRWarpType.LightConeEventWarp)
            {
                star5s = [warp.Up5];
                star4s = warp.Up4;
            }
            else
            {
                star5s = warp.Common5Characters;
                star4s = warp.Common4Characters;
            }
            ISRWarpResultItem star5 = star5s[0], star4 = star4s[0];

            for (int i = 0; i < total; i++)
            {
                SRPlayer player = args.Player;
                int counter = 0, count5 = args.TargetCount5, count4 = args.TargetCount4;

                while (warp.TryWarp(player, out var item))
                {
                    counter++;
                    if (count5 > 0 && star5.Equals(item))
                    {
                        count5--;
                    }
                    if (count4 > 0 && star4.Equals(item))
                    {
                        count4--;
                    }
                    if (count5 <= 0 && count4 <= 0)
                    {
                        successful++;
                        break;
                    }
                }
            }

            if (args.TargetCount5 > 0)
            {
                var origColor = SetColor(star5);
                Console.Write(string.Join(" / ", star5s.Select(item => item.Name)));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($": {args.TargetCount5}");
                Console.ForegroundColor = origColor;
            }
            if (args.TargetCount4 > 0)
            {
                var origColor = SetColor(star4);
                Console.Write(string.Join(" / ", star4s.Select(item => item.Name)));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($": {args.TargetCount4}");
                Console.ForegroundColor = origColor;
            }
            Console.WriteLine(((double)successful / total).ToString("0.00%"));
        }
    }

    public record class CLIArgs
    {
        public bool Pause = false;
        public bool Silent = false;
        public bool Return = false;

        public int StarRailPass = 180;
        public int StarRailSpecialPass = 180;
        public int UndyingStarlight = 0;
        public int StellarJade = 0;
        public int OneiricShard = 0;

        public int Counter5 = 0;
        public bool Guarantee5 = false;

        public string WarpName = string.Empty;
        public int WarpVersionMajor = 1;
        public int WarpVersionMinor = 0;
        public SRVersion WarpVersion
        {
            get
            {
                SRVersion major = (SRVersion)(WarpVersionMajor << 12);
                SRVersion minor = (SRVersion)(WarpVersionMinor << 8);
                return major | minor | SRVersion.Specified;
            }
        }
        public SRWarpType WarpType = SRWarpType.CharacterEventWarp;

        public int TargetCount5 = 0;
        public int TargetCount4 = 0;
        public int Attempts = 10000;

        public string Command = "result-statistics";

        public bool Help = false;
        public string? Language = null;

        internal SRPlayerWarpCurrencyStats WarpCurrencyStats
        {
            get
            {
                return new SRPlayerWarpCurrencyStats()
                {
                    StarRailPass = StarRailPass,
                    StarRailSpecialPass = StarRailSpecialPass,
                    UndyingStarlight = UndyingStarlight,
                    StellarJade = StellarJade,
                    OneiricShard = OneiricShard,
                };
            }
        }
        internal SRPlayerWarpStats WarpStats
        {
            get
            {
                return new SRPlayerWarpStats()
                {
                    Counter5 = Counter5,
                    Guarantee5 = Guarantee5,
                };
            }
        }
        internal SRPlayer Player
        {
            get
            {
                var player = new SRPlayer()
                {
                    WarpCurrencyStats = WarpCurrencyStats,
                };
                if (WarpType is SRWarpType.CharacterEventWarp)
                {
                    player.CharacterEventStats = WarpStats;
                }
                else if (WarpType is SRWarpType.LightConeEventWarp)
                {
                    player.LightConeEventStats = WarpStats;
                }
                else if (WarpType is SRWarpType.StellarWarp)
                {
                    player.StellarStats = WarpStats;
                }
                else if (WarpType is SRWarpType.DepartureWarp)
                {
                    player.DepartureStats = WarpStats;
                }
                return player;
            }
        }
        internal SRCharacterEventWarp CharacterEventWarp
        {
            get => SRCharacterEventWarps.GetWarpByNameAndVersion(WarpName, WarpVersion);
        }
        internal SRLightConeEventWarp LightConeEventWarp
        {
            get => SRLightConeEventWarps.GetWarpByNameAndVersion(WarpName, WarpVersion);
        }
        internal SRStellarWarp StellarWarp
        {
            get
            {
                return new SRStellarWarp(WarpVersion);
            }
        }
        internal SRWarp Warp
        {
            get
            {
                return WarpType switch
                {
                    SRWarpType.LightConeEventWarp => LightConeEventWarp,
                    SRWarpType.StellarWarp => StellarWarp,
                    SRWarpType.DepartureWarp => SRDepartureWarp.DepartureWarp,
                    _ => CharacterEventWarp,
                };
            }
        }

        public static CLIArgs Parse(string[] args)
        {
            CLIArgs result = new();
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i].ToLower();
                if (arg.StartsWith("--"))
                {
                    string option = arg[2..];
                    switch (option)
                    {
                        case "pause":
                            result.Pause = true;
                            break;

                        case "silent":
                            result.Silent = true;
                            break;

                        case "return":
                            result.Return = true;
                            break;

                        case "star-rail-pass":
                            if (int.TryParse(args[++i], out int count))
                            {
                                result.StarRailPass = count;
                            }
                            break;

                        case "star-rail-special-pass":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.StarRailSpecialPass = count;
                            }
                            break;

                        case "undying-starlight":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.UndyingStarlight = count;
                            }
                            break;

                        case "stellar-jade":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.StellarJade = count;
                            }
                            break;

                        case "oneiric-shard":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.OneiricShard = count;
                            }
                            break;

                        case "counter5":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.Counter5 = count;
                            }
                            break;

                        case "guarantee5":
                            result.Guarantee5 = true;
                            break;

                        case "warp-name":
                            result.WarpName = args[++i];
                            break;

                        case "warp-version":
                            if (int.TryParse(args[++i], out int major))
                            {
                                result.WarpVersionMajor = major;
                            }
                            if (int.TryParse(args[++i], out int minor))
                            {
                                result.WarpVersionMinor = minor;
                            }
                            break;

                        case "character-event-warp":
                            result.WarpType = SRWarpType.CharacterEventWarp;
                            break;

                        case "light-cone-event-warp":
                            result.WarpType = SRWarpType.LightConeEventWarp;
                            break;

                        case "stellar-warp":
                            result.WarpType = SRWarpType.StellarWarp;
                            break;

                        case "departure-warp":
                            result.WarpType = SRWarpType.DepartureWarp;
                            break;

                        case "target-count5":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.TargetCount5 = count;
                            }
                            break;

                        case "target-count4":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.TargetCount4 = count;
                            }
                            break;

                        case "attempts":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.Attempts = count;
                            }
                            break;

                        case "help":
                            result.Help = true;
                            break;

                        case "language":
                            result.Language = args[++i];
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    result.Command = arg;
                }
            }
            return result;
        }
    }
}
