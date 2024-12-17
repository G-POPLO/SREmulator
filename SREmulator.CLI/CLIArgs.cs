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
                return SRVersions.CreateAvailable(WarpVersionMajor, WarpVersionMinor);
            }
        }
        public SRWarpType WarpType = SRWarpType.CharacterEventWarp;

        public CLIWarpTarget Target = new();
        public int Attempts = 10000;

        public int Days = 0;
        public bool ExpressSupplyPass = false;

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
                        player.WarpCurrencyStats.DaysLater(Days, ExpressSupplyPass, player.LevelStats);
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
            CLIArgsSource source = new(args);

            while (true)
            {
                string arg = source.Next().ToLower();
                if (arg == string.Empty) break;
                if (arg.StartsWith("--"))
                {
                    string option = arg[2..];

                    if (!CLIOptions.TryApplyOption(option, result, source))
                    {
                        Console.WriteLine($"警告：错误的选项或参数在 --{arg}");
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
