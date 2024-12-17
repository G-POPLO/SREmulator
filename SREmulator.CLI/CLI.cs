using SREmulator.Localizations;
using SREmulator.SRItems;
using SREmulator.SRPlayers;
using SREmulator.SRWarps;
using System.Text;

namespace SREmulator.CLI
{
    public static partial class CLI
    {
        public static void Execute(CLIArgs args)
        {
            if (args.Help)
            {
                Console.WriteLine(Help);
                return;
            }

            if (args.Language is not null)
            {
                if (args.Language.ToLower() is "null") args.Language = string.Empty;
                LocalizationManager.SetCulture(args.Language);
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

        private static void Print(ISRWarpResultItem item, string? info = null)
        {
            var origColor = SetColor(item);
            Console.Write(item.Name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(info ?? string.Empty);
            Console.ForegroundColor = origColor;
        }

        private static string GetFileName(string name, string extension)
        {
            return $"{name}.{DateTime.Now:yyyy-MM-dd-HH-mm-ss-fffffff}.{extension}";
        }

        internal static void ResultStatistics(CLIArgs args)
        {
            Dictionary<ISRWarpResultItem, int> result = [];
            int maxNameLength = 0;
            int counter = 0;

            var warp = args.Warp;
            var player = args.Player;
            StringBuilder builder = args.Export ? new StringBuilder() : null!;
            if (args.Export) builder.AppendLine("对象类型,对象名称,对象星级,跃迁类型");

            string warpTypeName = warp.WarpType switch
            {
                SRWarpType.DepartureWarp => "始发跃迁",
                SRWarpType.StellarWarp => "群星跃迁",
                SRWarpType.CharacterEventWarp => "角色活动跃迁",
                SRWarpType.LightConeEventWarp => "光锥活动跃迁",
                _ => string.Empty
            };

            while (warp.TryWarp(player, out var item))
            {
                result.TryGetValue(item, out var count);
                result[item] = count + 1;
                counter++;

                if (args.Export)
                {
                    builder.AppendLine($"{(item is SRCharacter ? "角色" : "光锥")}," +
                        $"{item.Name}," +
                        $"{(int)item.Rarity}," +
                        $"{warpTypeName}"
                        );
                }

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

            if (args.Export) File.WriteAllText(GetFileName("warps", "csv"), builder.ToString());

            builder = args.Output ? new StringBuilder() : null!;
            if (args.Output) builder.AppendLine("名称,数量,占比");

            Console.WriteLine("----------");
            Console.WriteLine(counter);
            foreach (var pair in result.OrderByDescending(pair => pair.Key.Rarity).ThenByDescending(pair => pair.Value))
            {
                Print(pair.Key, $"\n{pair.Value}\t({(double)pair.Value / counter:0.00%})");
                if (args.Output) builder.AppendLine($"{pair.Key},{pair.Value},{(double)pair.Value / counter:0.00%}");
            }

            if (args.Output) File.WriteAllText(GetFileName("result-statistics", "csv"), builder.ToString());
        }

        internal static void AchieveAverageWarps(CLIArgs args)
        {
            int total = args.Attempts;
            int warps = 0;
            var warp = args.Warp;

            for (int i = 0; i < total; i++)
            {
                SRPlayer player = args.Player;
                CLIWarpTarget target = args.Target.Clone();
                int counter = 0;
                player.WarpCurrencyStats.StarRailPass = int.MaxValue;
                player.WarpCurrencyStats.StarRailSpecialPass = int.MaxValue;

                while (warp.TryWarp(player, out var item))
                {
                    counter++;
                    target.Check(item);
                    if (target.IsAchieved())
                    {
                        warps += counter;
                        break;
                    }
                }
            }

            foreach (var pair in args.Target.Target)
            {
                Print(pair.Key, $": {pair.Value}");
            }
            var result = ((double)warps / total).ToString("0.##");
            Console.WriteLine(result);
            if (args.Output) File.WriteAllText(GetFileName("achieve-average-warps", "txt"), result);
        }

        internal static void AchieveChance(CLIArgs args)
        {
            int total = args.Attempts;
            int successful = 0;
            var warp = args.Warp;

            for (int i = 0; i < total; i++)
            {
                SRPlayer player = args.Player;
                CLIWarpTarget target = args.Target.Clone();
                int counter = 0;

                while (warp.TryWarp(player, out var item))
                {
                    counter++;
                    target.Check(item);
                    if (target.IsAchieved())
                    {
                        successful++;
                        break;
                    }
                }
            }

            foreach (var pair in args.Target.Target)
            {
                Print(pair.Key, $": {pair.Value}");
            }
            var result = ((double)successful / total).ToString("0.00%");
            Console.WriteLine(result);
            if (args.Output) File.WriteAllText(GetFileName("achieve-chance", "txt"), result);
        }
    }
}
