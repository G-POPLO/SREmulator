using SREmulator.SRItems;
using SREmulator.SRWarps;

namespace SREmulator.CLI
{
    public static class CLIOptions
    {
        public static readonly Dictionary<string, CLIOption> Options;

        static CLIOptions()
        {
            List<CLIOption> options = [];
            var optionType = typeof(CLIOption);
            var assembly = optionType.Assembly;
            foreach (var type in assembly.GetTypes())
            {
                if (!type.IsAbstract && type.IsSubclassOf(optionType))
                {
                    options.Add((CLIOption)Activator.CreateInstance(type)!);
                }
            }
            Options = options.ToDictionary(option => option.Name);
        }

        public static bool TryApplyOption(string name, CLIArgs args, CLIArgsSource source)
        {
            if (!Options.TryGetValue(name, out CLIOption? option)) return false;
            return option.TryApplyToCLIArgs(args, source);
        }
    }

    public abstract class CLIOption
    {
        public abstract string Name { get; }

        public abstract bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source);
    }

    public sealed class PauseOption : CLIOption
    {
        public override string Name => "pause";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Pause = true;
            return true;
        }
    }

    public sealed class SilentOption : CLIOption
    {
        public override string Name => "silent";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Silent = true;
            return true;
        }
    }

    public sealed class ReturnOption : CLIOption
    {
        public override string Name => "return";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Return = true;
            return true;
        }
    }

    public sealed class ExportOption : CLIOption
    {
        public override string Name => "export";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Export = true;
            return true;
        }
    }

    public sealed class OutputOption : CLIOption
    {
        public override string Name => "output";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Output = true;
            return true;
        }
    }

    public sealed class StarRailPassOption : CLIOption
    {
        public override string Name => "star-rail-pass";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.StarRailPass = source.NextInt32(0);
            return true;
        }
    }

    public sealed class StarRailSpecialPassOption : CLIOption
    {
        public override string Name => "star-rail-special-pass";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.StarRailSpecialPass = source.NextInt32(0);
            return true;
        }
    }

    public sealed class UndyingStarlightOption : CLIOption
    {
        public override string Name => "undying-starlight";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.UndyingStarlight = source.NextInt32(0);
            return true;
        }
    }

    public sealed class StellarJadeOption : CLIOption
    {
        public override string Name => "stellar-jade";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.StellarJade = source.NextInt32(0);
            return true;
        }
    }

    public sealed class OneiricShardOption : CLIOption
    {
        public override string Name => "oneiric-shard";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.OneiricShard = source.NextInt32(0);
            return true;
        }
    }

    public sealed class EidolonOption : CLIOption
    {
        public override string Name => "eidolon";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            string name = source.Next();
            int count = source.NextInt32(-1, 6);
            var character = SRCharacters.GetItemByName(name);
            if (character is null) return false;
            args.Eidolons[character] = count;
            return true;
        }
    }

    public sealed class UnlimitedResourcesOption : CLIOption
    {
        public override string Name => "unlimited-resources";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.UnlimitedResources = true;
            return true;
        }
    }


    public sealed class Counter5Option : CLIOption
    {
        public override string Name => "counter5";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Counter5 = source.NextInt32(0);
            return true;
        }
    }

    public sealed class Guarantee5Option : CLIOption
    {
        public override string Name => "guarantee5";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Guarantee5 = true;
            return true;
        }
    }

    public sealed class Counter5CharacterOption : CLIOption
    {
        public override string Name => "counter5character";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Counter5Character = source.NextInt32(0);
            return true;
        }
    }

    public sealed class Counter5LightConeOption : CLIOption
    {
        public override string Name => "counter5lightcone";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Counter5LightCone = source.NextInt32(0);
            return true;
        }
    }

    public sealed class Counter4Option : CLIOption
    {
        public override string Name => "counter4";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Counter4 = source.NextInt32(0);
            return true;
        }
    }

    public sealed class Guarantee4Option : CLIOption
    {
        public override string Name => "guarantee4";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Guarantee4 = true;
            return true;
        }
    }

    public sealed class Counter4CharacterOption : CLIOption
    {
        public override string Name => "counter4character";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Counter4Character = source.NextInt32(0);
            return true;
        }
    }

    public sealed class Counter4LightConeOption : CLIOption
    {
        public override string Name => "counter4lightcone";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Counter4LightCone = source.NextInt32(0);
            return true;
        }
    }

    public sealed class WarpNameOption : CLIOption
    {
        public override string Name => "warp-name";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.WarpName = source.Next();
            return true;
        }
    }

    public sealed class WarpVersionOption : CLIOption
    {
        public override string Name => "warp-version";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.WarpVersionMajor = source.NextInt32(1, 3);
            args.WarpVersionMinor = source.NextInt32(0, 7);
            return true;
        }
    }

    public sealed class CharacterEventWarpOption : CLIOption
    {
        public override string Name => "character-event-warp";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.WarpType = SRWarpType.CharacterEventWarp;
            return true;
        }
    }

    public sealed class LightConeEventWarpOption : CLIOption
    {
        public override string Name => "light-cone-event-warp";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.WarpType = SRWarpType.LightConeEventWarp;
            return true;
        }
    }
    public sealed class StellarWarpOption : CLIOption
    {
        public override string Name => "stellar-warp";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.WarpType = SRWarpType.StellarWarp;
            return true;
        }
    }

    public sealed class DepartureWarpOption : CLIOption
    {
        public override string Name => "departure-warp";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.WarpType = SRWarpType.DepartureWarp;
            return true;
        }
    }

    public sealed class TargetOption : CLIOption
    {
        public override string Name => "target";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            string name = source.Next();
            int count = source.NextInt32(0);
            var item = ISRWarpResultItem.GetItemByName(name);
            if (item is null) return false;
            args.Target[item] = count;
            return true;
        }
    }

    public sealed class AttemptsOption : CLIOption
    {
        public override string Name => "attempts";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Attempts = source.NextInt32(1);
            return true;
        }
    }

    public sealed class DaysOption : CLIOption
    {
        public override string Name => "days";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Days = source.NextInt32(0);
            return true;
        }
    }

    public sealed class ExpressSupplyPassOption : CLIOption
    {
        public override string Name => "express-supply-pass";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.ExpressSupplyPass = true;
            return true;
        }
    }

    public sealed class HelpOption : CLIOption
    {
        public override string Name => "help";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Help = true;
            return true;
        }
    }

    public sealed class LanguageOption : CLIOption
    {
        public override string Name => "language";

        public override bool TryApplyToCLIArgs(CLIArgs args, CLIArgsSource source)
        {
            args.Language = source.Next();
            return true;
        }
    }
}
