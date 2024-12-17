using SREmulator.SRItems;
using SREmulator.SRPlayers;
using SREmulator.SRWarps;
using SREmulator.SRWarps.CommonWarps;
using SREmulator.SRWarps.EventWarps;

namespace SREmulator.CLI
{
    public class CLIArgs
    {
        public bool Pause = false;
        public bool Silent = false;
        public bool Return = false;
        public bool Export = false;
        public bool Output = false;

        public int StarRailPass = 180;
        public int StarRailSpecialPass = 180;
        public int UndyingStarlight = 0;
        public int StellarJade = 0;
        public int OneiricShard = 0;
        public Dictionary<SRCharacter, int> Eidolons = [];

        public int Counter5 = 0;
        public bool Guarantee5 = false;
        public int Counter4 = 0;
        public bool Guarantee4 = false;
        public int Counter5Character = 0;
        public int Counter5LightCone = 0;
        public int Counter4Character = 0;
        public int Counter4LightCone = 0;

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

        public CLIWarpTarget Target = new();
        [Obsolete("Use CLIArgs.Target")]
        public int TargetCount5 = 0;
        [Obsolete("Use CLIArgs.Target")]
        public int TargetCount4 = 0;
        public int Attempts = 10000;

        public int Days = 0;
        public bool ExpressSupplyPassDays = false;

        public string Command = "result-statistics";

        public bool Help = false;
        public string? Language = null;

        // TODO: 优化 只计算一次 之后Clone
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
                    Counter4 = Counter4,
                    Guarantee4 = Guarantee4,
                    Counter5Character = Counter5Character,
                    Counter5LightCone = Counter5LightCone,
                    Counter4Character = Counter4Character,
                    Counter4LightCone = Counter4LightCone,
                };
            }
        }
        internal SRPlayerEidolonsStats EidolonsStats
        {
            get
            {
                return new SRPlayerEidolonsStats(Eidolons);
            }
        }
        private SRPlayer? _player = null;
        internal SRPlayer Player
        {
            get
            {
                if (_player is null)
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
                    player.EidolonsStats = EidolonsStats;
                    if (Days > 0)
                    {
                        player.LevelStats.EquilibriumLevel = 6;
                        player.WarpCurrencyStats.DaysLater(Days, ExpressSupplyPassDays, player.LevelStats);
                    }
                    _player = player;
                }
                return _player.Clone();
            }
        }
        internal SRCharacterEventWarp CharacterEventWarp
        {
            get => SRCharacterEventWarps.GetWarpByNameAndVersion(WarpName, WarpVersion) ?? SRCharacterEventWarps.TheLongVoyageHome1;
        }
        internal SRLightConeEventWarp LightConeEventWarp
        {
            get => SRLightConeEventWarps.GetWarpByNameAndVersion(WarpName, WarpVersion) ?? SRLightConeEventWarps.TheLongVoyageHome1;
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

                        case "export":
                            result.Export = true;
                            break;

                        case "output":
                            result.Output = true;
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

                        case "eidolon":
                            var name = args[++i];
                            if (int.TryParse(args[++i], out count))
                            {
                                count = Math.Clamp(count, -1, 6);
                                var character = SRCharacters.GetItemByName(name);
                                if (character is not null) result.Eidolons[character] = count;
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

                        case "counter4":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.Counter4 = count;
                            }
                            break;

                        case "guarantee4":
                            result.Guarantee4 = true;
                            break;

                        case "counter5character":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.Counter5Character = count;
                            }
                            break;

                        case "counter5lightcone":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.Counter5LightCone = count;
                            }
                            break;

                        case "counter4character":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.Counter4Character = count;
                            }
                            break;

                        case "counter4lightcone":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.Counter4LightCone = count;
                            }
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

                        case "target":
                            name = args[++i];
                            if (int.TryParse(args[++i], out count))
                            {
                                result.Target[ISRWarpResultItem.GetItemByName(name)] = count;
                            }
                            break;

                        case "target-count5":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.Target[result.Warp.Up5] = count;
                            }
                            break;

                        case "target-count4":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.Target[result.Warp.Up4[0]] = count;
                            }
                            break;

                        case "attempts":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.Attempts = count;
                            }
                            break;

                        case "days":
                            if (int.TryParse(args[++i], out count))
                            {
                                result.Days = count;
                            }
                            break;

                        case "express-supply-pass":
                            result.ExpressSupplyPassDays = true;
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
