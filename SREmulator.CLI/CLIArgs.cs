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
        public bool UnlimitedResources = false;
        public bool NoRewards = false;

        public int StarRailPass = 0;
        public int StarRailSpecialPass = 0;
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

        public ISRWarpResultItem? Up5;
        public ISRWarpResultItem? Up41;
        public ISRWarpResultItem? Up42;
        public ISRWarpResultItem? Up43;

        public string WarpName = string.Empty;
        public int WarpVersionMajor = 0;
        public int WarpVersionMinor = 0;
        public SRVersion WarpVersion
        {
            get
            {
                return SRVersions.CreateAvailable(WarpVersionMajor, WarpVersionMinor);
            }
        }
        public string? WarpTypeName = null;
        public SRWarpType WarpType => SRWarpTypes.FromeName(WarpTypeName);

        private CLIWarpTargetFactory? _targets = null;
        public CLIWarpTargetFactory Targets => _targets ??= new(this);
        public int Attempts = 10000;

        public int Days = 0;
        public bool ExpressSupplyPass = false;

        public string Command = "help";

        public bool Help = false;
        public string? Language = null;

        internal bool FirstWarp = true;
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
                    UnlimitedResources = UnlimitedResources,
                    NoWarpRewards = NoRewards,
                };
            }
        }
        private SRPlayerWarpStats? _characterEventStats;
        private SRPlayerWarpStats? _lightConeEventStats;
        private SRPlayerWarpStats? _stellarStats;
        private SRPlayerWarpStats? _departureStats;
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
                    if (_characterEventStats is not null) player.CharacterEventStats = _characterEventStats.Clone();
                    if (_lightConeEventStats is not null) player.LightConeEventStats = _lightConeEventStats.Clone();
                    if (_stellarStats is not null) player.StellarStats = _stellarStats.Clone();
                    if (_departureStats is not null) player.DepartureStats = _departureStats.Clone();
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
        internal SRCharacterEventWarp CustomCharacterEventWarp
        {
            get => SRCharacterEventWarps.Create(
                (SRStar5Character)Up5!,
                (SRStar4Character)Up41!,
                (SRStar4Character)Up42!,
                (SRStar4Character)Up43!,
                WarpVersion
                );
        }
        internal SRLightConeEventWarp CustomLightConeEventWarp
        {
            get => SRLightConeEventWarps.Create(
                (SRStar5LightCone)Up5!,
                (SRStar4LightCone)Up41!,
                (SRStar4LightCone)Up42!,
                (SRStar4LightCone)Up43!,
                WarpVersion
                );
        }
        internal SRWarp Warp
        {
            get
            {
                if (WarpName is "__custom")
                {
                    return WarpType switch
                    {
                        SRWarpType.CharacterEventWarp => CustomCharacterEventWarp,
                        SRWarpType.LightConeEventWarp => CustomLightConeEventWarp,
                        _ => throw new InvalidOperationException()
                    };
                }

                return WarpType switch
                {
                    SRWarpType.CharacterEventWarp => CharacterEventWarp,
                    SRWarpType.LightConeEventWarp => LightConeEventWarp,
                    SRWarpType.StellarWarp => StellarWarp,
                    SRWarpType.DepartureWarp => SRDepartureWarp.DepartureWarp,
                    _ => throw new InvalidOperationException()
                };
            }
        }
        internal List<SRWarp> Warps = [];

        internal void TryAddAndResetWarp()
        {
            if (WarpType is not SRWarpType.None)
            {
                Warps.Add(Warp);
                if (WarpType is SRWarpType.CharacterEventWarp)
                {
                    _characterEventStats ??= WarpStats;
                }
                else if (WarpType is SRWarpType.LightConeEventWarp)
                {
                    _lightConeEventStats ??= WarpStats;
                }
                else if (WarpType is SRWarpType.StellarWarp)
                {
                    _stellarStats ??= WarpStats;
                }
                else if (WarpType is SRWarpType.DepartureWarp)
                {
                    _departureStats ??= WarpStats;
                }
            }
            Counter5 = 0;
            Guarantee5 = false;
            Counter4 = 0;
            Guarantee4 = false;
            Counter5Character = 0;
            Counter5LightCone = 0;
            Counter4Character = 0;
            Counter4LightCone = 0;
            WarpName = string.Empty;
            WarpVersionMajor = 0;
            WarpVersionMinor = 0;
            WarpTypeName = null;
        }

        public static CLIArgs Parse(string[] args)
        {
            CLIArgs result = new();
            CLIArgsSource source = new(args);

            while (true)
            {
                try
                {
                    string arg = source.Next().ToLower();
                    if (arg == string.Empty) break;
                    if (arg.StartsWith("--"))
                    {
                        string option = arg[2..];

                        if (CLIOptions.Options.ContainsKey(option))
                        {
                            if (!CLIOptions.TryApplyOption(option, result, source))
                            {
                                source.Warning($"参数错误 （在 '{arg}' 选项中）");
                            }
                        }
                        else
                        {
                            source.Warning($"无法识别的选项 '{arg}'");
                        }
                    }
                    else
                    {
                        if (CLICommands.Commands.ContainsKey(arg))
                        {
                            result.Command = arg;
                            if (result.Command is "help") return result;
                        }
                        else
                        {
                            source.Warning($"无法识别的命令 '{arg}'");
                        }
                    }
                }
                catch (Exception e)
                {
                    source.Warning(e.Message);
                }
            }

            result.TryAddAndResetWarp();
            if (result.Warps.Count is 0)
            {
                source.Warning("未选择任何卡池，请使用 --new-warp 指定卡池");
            }

            _ = result.Targets.Create();

            foreach (var invalidTarget in result.Targets.InvalidTargets)
            {
                source.Warning($"无法实现的目标 '{invalidTarget.Name}' （该目标已被忽略）");
            }

            foreach (var warning in source.Warnings)
            {
                Console.WriteLine($"【警告】{warning}");
            }
            if (source.Warnings.Count > 0)
            {
                Console.WriteLine("----------");
            }


            return result;
        }
    }
}
