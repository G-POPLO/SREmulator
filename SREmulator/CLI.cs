using SREmulator.SRItems;
using SREmulator.SRPlayers;
using SREmulator.SRWarps;
using SREmulator.SRWarps.CharacterEventWarps;
using SREmulator.SRWarps.CommonWarps;
using SREmulator.SRWarps.LightConeEventWarps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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

                --warp-name <name>                  设置要抽取的卡池
                --warp-version <major> <minor>      设置卡池所在的版本（影响可抽取到的四星对象）

                --character-event-warp              设置卡池类型为角色活动跃迁（UP角色池）
                --light-cone-event-warp             设置卡池类型为光锥活动跃迁（UP光锥池）
                --stellar-warp                      设置卡池类型为群星跃迁（常驻池）
                --departure-warp                    设置卡池类型为始发跃迁（新手池）

                --target-count5 <count>             设置目标Up5星数量
                --target-count4 <count>             设置目标Up4星数量
                --attempts <count>                  设置计算抽数或可能性时的尝试次数
            """;

        public static void Execute(CLIArgs args)
        {
            if (args.Command is "achieve-average-warps")
            {
                AchieveAverageWarps(args);
            }
            else if (args.Command is "achieve-chance")
            {
                AchieveChance(args);
            }
            else
            {
                ResultStatistics(args);
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
            foreach (var pair in result.OrderByDescending(pair => pair.Key.Rarity).ThenByDescending(pair => pair.Value))
            {
                var origColor = SetColor(pair.Key);
                Console.WriteLine(pair.Key.Name);
                Console.ForegroundColor = origColor;
                Console.WriteLine($"{pair.Value}\t({((double)pair.Value / counter):0.00%})");
                Console.WriteLine();
            }
        }

        internal static void AchieveAverageWarps(CLIArgs args)
        {
            int total = args.Attempts;
            int warps = 0;
            var warp = args.Warp;

            var star5 = warp.Up5 ?? warp.Common5Characters[0];
            var star4 = warp.Up4?[0] ?? warp.Common4Characters[0];

            for (int i = 0; i < total; i++)
            {
                SRPlayer player = args.Player;
                int counter = 0, count5 = args.TargetCount5, count4 = args.TargetCount4;
                player.WarpCurrencyStats.StarRailPass = int.MaxValue;
                player.WarpCurrencyStats.StarRailSpecialPass = int.MaxValue;

                while (warp.TryWarp(player, out var item))
                {
                    counter++;
                    if (count5 > 0 && ISRWarpResultItem.Equals(star5, item))
                    {
                        count5--;
                    }
                    if (count4 > 0 && ISRWarpResultItem.Equals(star4, item))
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
                Console.Write(star5.Name);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($": {args.TargetCount5}");
                Console.ForegroundColor = origColor;
            }
            if (args.TargetCount4 > 0)
            {
                var origColor = SetColor(star4);
                Console.Write(string.Join(" / ", warp.Up4.Select(item => item.Name)));
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

            for (int i = 0; i < total; i++)
            {
                SRPlayer player = args.Player;
                int counter = 0, count5 = args.TargetCount5, count4 = args.TargetCount4;

                while (warp.TryWarp(player, out var item))
                {
                    counter++;
                    if (count5 > 0 && ISRWarpResultItem.Equals(warp.Up5, item))
                    {
                        count5--;
                    }
                    if (count4 > 0 && ISRWarpResultItem.Equals(warp.Up4[0], item))
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
                var origColor = SetColor(warp.Up5);
                Console.Write(warp.Up5.Name);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($": {args.TargetCount5}");
                Console.ForegroundColor = origColor;
            }
            if (args.TargetCount4 > 0)
            {
                var origColor = SetColor(warp.Up4[0]);
                Console.Write(string.Join(" / ", warp.Up4.Select(item => item.Name)));
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
            get
            {
                SRVersion version = WarpVersion;
                return WarpName.ToLower() switch
                {
                    "seele" or "xier"
                    => version switch
                    {
                        SRVersion.Ver1p4 => SRCharacterEventWarps.ButterflyOnSwordtip2,
                        _ => SRCharacterEventWarps.ButterflyOnSwordtip1
                    },

                    "jing-yuan" or "jingyuan"
                    => version switch
                    {
                        SRVersion.Ver2p0 => SRCharacterEventWarps.SwirlOfHeavenlySpear2,
                        _ => SRCharacterEventWarps.SwirlOfHeavenlySpear1
                    },

                    "silver-wolf" or "silverwolf" or "yinlang"
                    => version switch
                    {
                        SRVersion.Ver1p5 => SRCharacterEventWarps.ContractZero2,
                        _ => SRCharacterEventWarps.ContractZero1
                    },

                    "luocha"
                    => version switch
                    {
                        SRVersion.Ver2p1 => SRCharacterEventWarps.LaicPursuit2,
                        _ => SRCharacterEventWarps.LaicPursuit1
                    },

                    "blade" or "ren"
                    => version switch
                    {
                        SRVersion.Ver1p6 => SRCharacterEventWarps.ALostSoul2,
                        _ => SRCharacterEventWarps.ALostSoul1
                    },

                    "kafka" or "kafuka"
                    => version switch
                    {
                        SRVersion.Ver2p5 => SRCharacterEventWarps.IndelibleCoterieKafka1,
                        SRVersion.Ver1p6 => SRCharacterEventWarps.NessunDorma2,
                        _ => SRCharacterEventWarps.NessunDorma1
                    },

                    "dan-heng-imbibitor-lunae" or "dan-heng" or "danhengyinyue" or "yinyue" or "danheng"
                    => version switch
                    {
                        SRVersion.Ver2p6 => SRCharacterEventWarps.EpochalSpectrum3,
                        SRVersion.Ver2p0 => SRCharacterEventWarps.EpochalSpectrum2,
                        _ => SRCharacterEventWarps.EpochalSpectrum1
                    },

                    "fu-xuan" or "fuxuan"
                    => version switch
                    {
                        SRVersion.Ver2p2 => SRCharacterEventWarps.ForeseenForeknownForetold2,
                        _ => SRCharacterEventWarps.ForeseenForeknownForetold1
                    },

                    "jingliu"
                    => version switch
                    {
                        SRVersion.Ver2p1 => SRCharacterEventWarps.GentleEclipseOfTheMoon2,
                        _ => SRCharacterEventWarps.GentleEclipseOfTheMoon1
                    },

                    "topaz-numby" or "topaz" or "tuopa-zhangzhang" or "tuopa"
                    => version switch
                    {
                        SRVersion.Ver2p5 => SRCharacterEventWarps.SunsetClause3,
                        SRVersion.Ver2p2 => SRCharacterEventWarps.SunsetClause2,
                        _ => SRCharacterEventWarps.SunsetClause1
                    },

                    "huohuo"
                    => version switch
                    {
                        SRVersion.Ver2p4 => SRCharacterEventWarps.BloomInGloom2,
                        _ => SRCharacterEventWarps.BloomInGloom1
                    },

                    "argenti" or "yinzhi"
                    => version switch
                    {
                        SRVersion.Ver2p3 => SRCharacterEventWarps.ThornsOfScentedCrown2,
                        _ => SRCharacterEventWarps.ThornsOfScentedCrown1
                    },

                    "ruan-mei" or "ruanmei"
                    => version switch
                    {
                        SRVersion.Ver2p3 => SRCharacterEventWarps.FloralTriptych2,
                        _ => SRCharacterEventWarps.FloralTriptych1
                    },

                    "dr-ratio" or "ratio" or "zhenliyisheng"
                    => version switch
                    {
                        _ => SRCharacterEventWarps.PantaRhei1
                    },

                    "black-swan" or "heitiane"
                    => version switch
                    {
                        SRVersion.Ver2p5 => SRCharacterEventWarps.IndelibleCoterieBlackSwan1,
                        _ => SRCharacterEventWarps.RipplesInReflection1
                    },

                    "sparkle" or "huahuo"
                    => version switch
                    {
                        SRVersion.Ver2p4 => SRCharacterEventWarps.SparklingSplendor2,
                        _ => SRCharacterEventWarps.SparklingSplendor1
                    },

                    "acheron" or "huangquan"
                    => version switch
                    {
                        SRVersion.Ver2p6 => SRCharacterEventWarps.WordsOfYore2,
                        _ => SRCharacterEventWarps.WordsOfYore1
                    },
                    
                    "aventurine" or "shajin"
                    => version switch
                    {
                        SRVersion.Ver2p6 => SRCharacterEventWarps.GildedImprisonment2,
                        _ => SRCharacterEventWarps.GildedImprisonment1
                    },

                    "robin" or "zhigengniao"
                    => version switch
                    {
                        SRVersion.Ver2p5 => SRCharacterEventWarps.IndelibleCoterieRobin1,
                        _ => SRCharacterEventWarps.JustIntonation1
                    },

                    "boothill" or "botiou"
                    => version switch
                    {
                        _ => SRCharacterEventWarps.DustyTrailsLoneStar1
                    },

                    "firefly" or "liuying"
                    => version switch
                    {
                        _ => SRCharacterEventWarps.FirefullFlyshine1
                    },

                    "jade" or "feicui"
                    => version switch
                    {
                        _ => SRCharacterEventWarps.LienOnLifeLeaseOnFate1
                    },

                    "yunli"
                    => version switch
                    {
                        _ => SRCharacterEventWarps.EarthHurledEtherCurled1
                    },

                    "jiaoqiu"
                    => version switch
                    {
                        _ => SRCharacterEventWarps.CauldronContrivance1
                    },

                    "feixiao"
                    => version switch
                    {
                        _ => SRCharacterEventWarps.StormridersBolt1
                    },

                    "lingsha"
                    => version switch
                    {
                        _ => SRCharacterEventWarps.LetScentSinkIn1
                    },

                    "rappa" or "luanpo"
                    => version switch
                    {
                        _ => SRCharacterEventWarps.EyesOfANinja1
                    },

                    _ => SRCharacterEventWarps.EyesOfANinja1
                };
            }
        }
        internal SRLightConeEventWarp LightConeEventWarp
        {
            get
            {
                SRVersion version = WarpVersion;
                return WarpName.ToLower() switch
                {
                    "seele" or "xier"
                    => version switch
                    {
                        SRVersion.Ver1p4 => SRLightConeEventWarps.ButterflyOnSwordtip2,
                        _ => SRLightConeEventWarps.ButterflyOnSwordtip1
                    },

                    "jing-yuan" or "jingyuan"
                    => version switch
                    {
                        SRVersion.Ver2p0 => SRLightConeEventWarps.SwirlOfHeavenlySpear2,
                        _ => SRLightConeEventWarps.SwirlOfHeavenlySpear1
                    },

                    "silver-wolf" or "silverwolf" or "yinlang"
                    => version switch
                    {
                        SRVersion.Ver1p5 => SRLightConeEventWarps.ContractZero2,
                        _ => SRLightConeEventWarps.ContractZero1
                    },

                    "luocha"
                    => version switch
                    {
                        SRVersion.Ver2p1 => SRLightConeEventWarps.LaicPursuit2,
                        _ => SRLightConeEventWarps.LaicPursuit1
                    },

                    "blade" or "ren"
                    => version switch
                    {
                        SRVersion.Ver1p6 => SRLightConeEventWarps.ALostSoul2,
                        _ => SRLightConeEventWarps.ALostSoul1
                    },

                    "kafka" or "kafuka"
                    => version switch
                    {
                        SRVersion.Ver2p5 => SRLightConeEventWarps.IndelibleCoterieKafka1,
                        SRVersion.Ver1p6 => SRLightConeEventWarps.NessunDorma2,
                        _ => SRLightConeEventWarps.NessunDorma1
                    },

                    "dan-heng-imbibitor-lunae" or "dan-heng" or "danhengyinyue" or "yinyue" or "danheng"
                    => version switch
                    {
                        SRVersion.Ver2p6 => SRLightConeEventWarps.EpochalSpectrum3,
                        SRVersion.Ver2p0 => SRLightConeEventWarps.EpochalSpectrum2,
                        _ => SRLightConeEventWarps.EpochalSpectrum1
                    },

                    "fu-xuan" or "fuxuan"
                    => version switch
                    {
                        SRVersion.Ver2p2 => SRLightConeEventWarps.ForeseenForeknownForetold2,
                        _ => SRLightConeEventWarps.ForeseenForeknownForetold1
                    },

                    "jingliu"
                    => version switch
                    {
                        SRVersion.Ver2p1 => SRLightConeEventWarps.GentleEclipseOfTheMoon2,
                        _ => SRLightConeEventWarps.GentleEclipseOfTheMoon1
                    },

                    "topaz-numby" or "topaz" or "tuopa-zhangzhang" or "tuopa"
                    => version switch
                    {
                        SRVersion.Ver2p5 => SRLightConeEventWarps.SunsetClause3,
                        SRVersion.Ver2p2 => SRLightConeEventWarps.SunsetClause2,
                        _ => SRLightConeEventWarps.SunsetClause1
                    },

                    "huohuo"
                    => version switch
                    {
                        SRVersion.Ver2p4 => SRLightConeEventWarps.BloomInGloom2,
                        _ => SRLightConeEventWarps.BloomInGloom1
                    },

                    "argenti" or "yinzhi"
                    => version switch
                    {
                        SRVersion.Ver2p3 => SRLightConeEventWarps.ThornsOfScentedCrown2,
                        _ => SRLightConeEventWarps.ThornsOfScentedCrown1
                    },

                    "ruan-mei" or "ruanmei"
                    => version switch
                    {
                        SRVersion.Ver2p3 => SRLightConeEventWarps.FloralTriptych2,
                        _ => SRLightConeEventWarps.FloralTriptych1
                    },

                    "dr-ratio" or "ratio" or "zhenliyisheng"
                    => version switch
                    {
                        _ => SRLightConeEventWarps.PantaRhei1
                    },

                    "black-swan" or "heitiane"
                    => version switch
                    {
                        SRVersion.Ver2p5 => SRLightConeEventWarps.IndelibleCoterieBlackSwan1,
                        _ => SRLightConeEventWarps.RipplesInReflection1
                    },

                    "sparkle" or "huahuo"
                    => version switch
                    {
                        SRVersion.Ver2p4 => SRLightConeEventWarps.SparklingSplendor2,
                        _ => SRLightConeEventWarps.SparklingSplendor1
                    },

                    "acheron" or "huangquan"
                    => version switch
                    {
                        SRVersion.Ver2p6 => SRLightConeEventWarps.WordsOfYore2,
                        _ => SRLightConeEventWarps.WordsOfYore1
                    },

                    "aventurine" or "shajin"
                    => version switch
                    {
                        SRVersion.Ver2p6 => SRLightConeEventWarps.GildedImprisonment2,
                        _ => SRLightConeEventWarps.GildedImprisonment1
                    },

                    "robin" or "zhigengniao"
                    => version switch
                    {
                        SRVersion.Ver2p5 => SRLightConeEventWarps.IndelibleCoterieRobin1,
                        _ => SRLightConeEventWarps.JustIntonation1
                    },

                    "boothill" or "botiou"
                    => version switch
                    {
                        _ => SRLightConeEventWarps.DustyTrailsLoneStar1
                    },

                    "firefly" or "liuying"
                    => version switch
                    {
                        _ => SRLightConeEventWarps.FirefullFlyshine1
                    },

                    "jade" or "feicui"
                    => version switch
                    {
                        _ => SRLightConeEventWarps.LienOnLifeLeaseOnFate1
                    },

                    "yunli"
                    => version switch
                    {
                        _ => SRLightConeEventWarps.EarthHurledEtherCurled1
                    },

                    "jiaoqiu"
                    => version switch
                    {
                        _ => SRLightConeEventWarps.CauldronContrivance1
                    },

                    "feixiao"
                    => version switch
                    {
                        _ => SRLightConeEventWarps.StormridersBolt1
                    },

                    "lingsha"
                    => version switch
                    {
                        _ => SRLightConeEventWarps.LetScentSinkIn1
                    },

                    "rappa" or "luanpo"
                    => version switch
                    {
                        _ => SRLightConeEventWarps.EyesOfANinja1
                    },

                    _ => SRLightConeEventWarps.EyesOfANinja1
                };
            }
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
