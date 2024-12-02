using SREmulator.Localizations;
using SREmulator.SRItems;
using SREmulator.SRPlayers;
using SREmulator.SRWarps.CharacterEventWarps;
using SREmulator.SRWarps.LightConeEventWarps;
using System.Diagnostics;
using System.Text;

namespace SREmulator
{
    internal class Program
    {
        //private const int NotMyPass = 50_000_000;
        //private const int NotMyPass = 10_000_000;
        //private const int NotMyPass = 10_000;
        private const int NotMyPass = 0;

        private static readonly SRPlayerWarpCurrencyStats MyWarpCurrencyStats = new()
        {
            StarRailSpecialPass = 16 + NotMyPass,
            StarRailPass = NotMyPass,
            StellarJade = 18797,
            OneiricShard = 1335,
            UndyingStarlight = 120,
        };

        private static readonly SRPlayerCharacterStats MyCharacterStats = new()
        {
            CharacterEidolons = new()
            {
                // Star 5
                [SRCharacters.Bailu] = 0,
                [SRCharacters.Bronya] = 2,
                [SRCharacters.Himeko] = 1,
                [SRCharacters.Clara] = 1,
                [SRCharacters.Gepard] = 1,
                [SRCharacters.Yanqing] = 3,

                // Star 4
                [SRCharacters.Gallagher] = 6,
                [SRCharacters.March7th] = 6,
                [SRCharacters.Hanya] = 6,
                [SRCharacters.Xueyi] = 6,
                [SRCharacters.Guinaifen] = 6,
                [SRCharacters.Yukong] = 6,
                [SRCharacters.Sushang] = 2,
                [SRCharacters.Tingyun] = 6,
                [SRCharacters.Qingque] = 6,
                [SRCharacters.Lynx] = 6,
                [SRCharacters.Hook] = 6,
                [SRCharacters.Pela] = 6,
                [SRCharacters.Natasha] = 6,
                [SRCharacters.Serval] = 6,
                [SRCharacters.Herta] = 6,
                [SRCharacters.Asta] = 6,
                [SRCharacters.Misha] = 5,
                [SRCharacters.Moze] = 2,
                [SRCharacters.Luka] = 6,
                [SRCharacters.Sampo] = 6,
                [SRCharacters.Arlan] = 4,
                [SRCharacters.DanHeng] = 5,
            }
        };

        private static readonly SRPlayerWarpStats MyCharacterEventStats = new()
        {
            Counter5 = 8,
            Counter4 = 2,
            Counter4Character = 2,
            Counter4LightCone = 34,
        };

        public static void MyPlayer()
        {
            SRPlayer player = SRPlayerDatabase.Signup();
            //SRPlayerDatabase.InternalSetItems(player.UID,
            //    starRailSpecialPass: 16,
            //    stellarJade: 15487,
            //    oneiricShard: 1335,
            //    undyingStarlight: 120
            //    );
            //SRPlayerDatabase.InternalSetItems(player.UID,
            //    starRailSpecialPass: 1000000
            //    );
            int counter = 0;
            bool mustBeLimited = false;
            int counterPick = 0, counterNoPick = 0;
            int counter5 = 0, counterl5 = 0, counter4 = 0;
            while (SRLightConeEventWarps.ButterflyOnSwordtip1.TryWarp(player, out var result))
            {
                counter++;
                //Console.Write(counter + ":\t");
                if (result is SRStar5Character)
                {
                    counter5++;
                    if (result is SRLimitedStar5Character) counterl5++;
                    if (!mustBeLimited)
                    {
                        if (result is SRLimitedStar5Character) counterPick++;
                        else counterNoPick++;
                    }
                    mustBeLimited = result is not SRLimitedStar5Character;
                }
                else if (result is SRStar4Character || result is SRStar4LightCone)
                {
                    counter4++;
                }
                //PrintSRItem(result);
            }
            //Console.WriteLine(SRPlayerDatabase.Records[(player.UID, SRWarpType.CharacterEventWarp)].Count);
            //PrintPercent(counter5, counter);
            //PrintPercent(counterl5, counter5);
            //PrintPercent(counter4, counter);
            PrintPercent(counterPick, counterPick + counterNoPick);
        }
        public static void SingleMyPlayer()
        {
            SRPlayer player = SRPlayerDatabase.Signup();
            player.WarpCurrencyStats = MyWarpCurrencyStats;
            player.CharacterStats = MyCharacterStats;
            player.CharacterEventStats = MyCharacterEventStats;
            Dictionary<ISRWarpResultItem, int> counter = [];
            while (SRCharacterEventWarps.ButterflyOnSwordtip1.TryWarp(player, out var result))
            {
                //if (result.Rarity is not SRItemRarity.Star4) continue;
                //if (result.Rarity is not SRItemRarity.Star5) continue;
                counter.TryGetValue(result, out int count);
                counter[result] = count + 1;
            }

            double sum = counter.Values.Sum();
            Console.WriteLine(sum);
            foreach (var result in counter.OrderByDescending(pair => pair.Value))
            {
                PrintSRItem(result.Key);
                Console.WriteLine($"{result.Value}\t({result.Value / sum:0.0000%})");
            }
            //Console.WriteLine(SRPlayerDatabase.Records[(player.UID, SRWarpType.CharacterEventWarp)].Count);
            //PrintPercent(counter5, counter);
            //PrintPercent(counterl5, counter5);
            //PrintPercent(counter4, counter);
            //PrintPercent(counterPick, counterPick + counterNoPick);
        }

        public static void TestPlayers()
        {
            int total = 0, times = 100000, gotTimes = 0;
            int mc3 = 0;
            for (int i = 0; i < times; i++)
            {
                SRPlayer player = SRPlayerDatabase.Signup();
                player.WarpCurrencyStats.StarRailSpecialPass = 1000;
                //SRPlayerDatabase.InternalSetItems(player.UID,
                //    starRailSpecialPass: 900
                //    );
                //Console.WriteLine(player.UID);
                //SRPlayerDatabase.InternalSetItems(player.UID,
                //    starRailSpecialPass: 16,
                //    stellarJade: 15487,
                //    oneiricShard: 1335,
                //    undyingStarlight: 120
                //    );
                //SRPlayerDatabase.InternalSetWarps(player.UID, SRWarpType.CharacterEventWarp,
                //counter5: 8,
                //counter4: 2
                //);
                //SRPlayerDatabase.InternalSetCharacters(player.UID, [
                //    (SRCharacters.Gallagher, 7),
                //    (SRCharacters.March7th, 7),
                //    (SRCharacters.Hanya, 7),
                //    (SRCharacters.Xueyi, 7),
                //    (SRCharacters.Guinaifen, 7),
                //    (SRCharacters.Yukong, 7),
                //    (SRCharacters.Sushang, 3),
                //    (SRCharacters.Tingyun, 7),
                //    (SRCharacters.Qingque, 7),
                //    (SRCharacters.Lynx, 7),
                //    (SRCharacters.Hook, 7),
                //    (SRCharacters.Pela, 7),
                //    (SRCharacters.Natasha, 7),
                //    (SRCharacters.Serval, 7),
                //    (SRCharacters.Herta, 7),
                //    (SRCharacters.Asta, 7),
                //    (SRCharacters.Misha, 6),
                //    (SRCharacters.Moze, 3),
                //    (SRCharacters.Luka, 7),
                //    (SRCharacters.Sampo, 7),
                //    (SRCharacters.Arlan, 5),
                //    (SRCharacters.DanHeng, 6),
                //    ]);

                int counter = 0;
                int counter5 = 0, counterl5 = 0, counter4 = 0, c3 = 0, count4ch = 0, count4lc = 0;
                while (SRCharacterEventWarps.ButterflyOnSwordtip1.TryWarp(player, out var result))
                {
                    counter++;
                    //Console.Write(counter + ":\t");
                    if (result is SRStar5Character)
                    {
                        counter5++;
                        if (result is SRLimitedStar5Character)
                        {
                            gotTimes++;
                            counterl5++;
                            break;
                        }
                        c3 = 0;

                    }
                    else if (result is SRStar4Character || result is SRStar4LightCone)
                    {
                        counter4++;
                        if (result is SRStar4Character ch)
                        {
                            count4ch++;
                            //if (ch == SRCharacterEventWarps.ButterflyOnSwordtip1.UpStar4Character1 ||
                            //    ch == SRCharacterEventWarps.ButterflyOnSwordtip1.UpStar4Character2 ||
                            //    ch == SRCharacterEventWarps.ButterflyOnSwordtip1.UpStar4Character3)
                            //{
                            //    gotTimes++;
                            //    break;
                            //}
                            //if (ch == SRCharacterEventWarps.ButterflyOnSwordtip1.UpStar4Character1)
                            //{
                            //    gotTimes++;
                            //    break;
                            //}
                        }
                        else
                        {
                            count4lc++;
                        }
                        c3 = 0;
                    }
                    else
                    {
                        mc3 = Math.Max(++c3, mc3);
                    }
                    //Console.WriteLine(mc3);
                    //PrintSRItem(result);
                }
                total += counter;


                //total += SRPlayerDatabase.Records[(player.UID, SRWarpType.CharacterEventWarp)].Count;


                //Console.WriteLine(counter);
                //Console.WriteLine(SRPlayerDatabase.Records[(player.UID, SRWarpType.CharacterEventWarp)].Count);
                //Console.WriteLine(((double)counter5 / counter).ToString("0.00%"));
                //Console.WriteLine(((double)counterl5 / counter5).ToString("0.00%"));
                //Console.WriteLine(((double)counter4 / counter).ToString("0.00%"));
                //Console.WriteLine((count4ch, count4lc));
            }

            PrintPercent(gotTimes, times);
            PrintDiv(total, times);
        }

        public static int[] ints => [1, 2, 3];
        public static (int, double)[] choices = [(1, 5), (2, 10), (3, 15)];

        static void Main(string[] args)
        {
            //Console.Write("啊啊啊啊啊啊");
            //Console.CursorLeft = 0;
            //Console.Write("aa");
            //Console.WriteLine("Resolution Shines As Pearls of Sweat".Length);
            //return;
            //args = "xxx.exe --pause --return --star-rail-special-pass 100 --warp-name seele --warp-version 2 1 --stellar-jade 1600 --light-cone-event-warp".Split(' ');
            if (args.Length is 0)
            {
                Console.WriteLine(CLI.Help);
                Console.ReadKey(true);
                return;
            }
            CLI.Execute(CLIArgs.Parse(args));
            Console.WriteLine("OVER");
            Console.ReadLine();
            return;



            //Console.WriteLine(SRCharacters.Clara == SRCharacters.Clara);
            //return;
            //SRCharacterEventWarp.GetBalanceWeight(18, out var w1, out var w2);
            //Console.WriteLine(w1);
            //Console.WriteLine(w2);
            //return;
            //int[] counter = new int[4];
            //for (int i = 0; i < 10; i++)
            //{
            //    counter[GachaRandom.Shared.GetItem(choices)]++;
            //}
            //Console.WriteLine(counter[0]);
            //Console.WriteLine(counter[1]);
            //Console.WriteLine(counter[2]);
            //Console.WriteLine(counter[3]);
            //GachaRandom.Shared.Redistribute(counter);
            //Console.WriteLine();
            //Console.WriteLine(counter[0]);
            //Console.WriteLine(counter[1]);
            //Console.WriteLine(counter[2]);
            //Console.WriteLine(counter[3]);

            //for (int i = 1; i <= 90; i++)
            //{
            //    SRCharacterEventWarp.GetChance(i, 0, out var chance5, out _);
            //    Console.WriteLine(i + ": " + chance5);
            //}
            //return;
            //for (int i = 1; i <= 10; i++)
            //{
            //    SRCharacterEventWarp.GetChance(0, i, out _, out var chance4);
            //    Console.WriteLine(i + ": " + chance4);
            //}
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            //Localization.Culture = new System.Globalization.CultureInfo("en-US");
            //foreach (var c in SRCharacterEventWarps.ButterflyOnSwordtip1.AvailableStar5Characters)
            //{
            //    Console.WriteLine(c);
            //}
            Stopwatch stopwatch = Stopwatch.StartNew();
            //MyPlayer();
            TestPlayers();
            //SingleMyPlayer();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.ToString());
            //int count1 = 0, count2 = 0;
            //for (int i = 0; i < 100000; i++)
            //{
            //    if (SRWarp.NextBool(10)) count1++;
            //    else count2++;
            //}
            //Console.WriteLine((count1, count2));
            //Console.ReadLine();


        }

        public static void PrintDiv(int a, int b)
        {
            Console.WriteLine((double)a / b);
        }
        public static void PrintPercent(int a, int b)
        {
            Console.WriteLine(((double)a / b).ToString("0.00%"));
        }

        public static void PrintSRCharacter(SRCharacter character)
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Console.Write("角色\t");
            Console.ForegroundColor =
                character is SRStar5Character ?
                ConsoleColor.Yellow :
                character is SRStar4Character ?
                ConsoleColor.Magenta :
                ConsoleColor.Gray;
            //Console.Write(character.RarityStarsText + "\t");
            Console.WriteLine(character.Name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintSRLightCone(SRLightCone lightCone)
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Console.Write("光锥\t");
            Console.ForegroundColor =
                lightCone is SRStar5LightCone ?
                ConsoleColor.Yellow :
                lightCone is SRStar4LightCone ?
                ConsoleColor.Magenta :
                ConsoleColor.Gray;
            //Console.Write(lightCone.RarityStarsText + "\t");
            Console.WriteLine(lightCone.Name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintSRItem(ISRWarpResultItem item)
        {
            if (item is SRCharacter character) PrintSRCharacter(character);
            else if (item is SRLightCone lightCone) PrintSRLightCone(lightCone);
        }
    }
}
