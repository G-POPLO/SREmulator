using SREmulator.SRItems;
using SREmulator.SRWarps;
using System.Collections.ObjectModel;

namespace SREmulator.CLI
{
    public interface ICLIWarpTarget
    {
        public bool Achieved { get; }
        public void Check(ISRWarpResultItem item);
        public ICLIWarpTarget Clone();
        public bool CanChangeWarp(SRWarp warp, bool checkOnly = true);
    }

    public sealed class CLIWarpTargetFactory
    {
        private readonly Dictionary<ISRWarpResultItem, int> _targets = [];
        private readonly List<ISRWarpResultItem> _invalidTargets = [];
        private readonly CLIArgs _args;
        private CLIMultipleWarpTarget? _target;

        public ReadOnlyDictionary<ISRWarpResultItem, int> Target => new(_targets);
        public List<ISRWarpResultItem> InvalidTargets => _invalidTargets;

        public CLIWarpTargetFactory(CLIArgs args)
        {
            _args = args;
        }

        public void AppendTarget(ISRWarpResultItem item, int count)
        {
            if (_target is not null) throw new InvalidOperationException();
            if (count <= 0) return;
            _targets[item] = count;
        }

        private IEnumerable<(SRWarp Warp, int Weight)> GetWarpWithWeight(ISRWarpResultItem item)
        {
            return _args.Warps.Select(warp =>
            {
                int weight;
                if (warp.AvailableUpItems.Contains(item))
                {
                    weight = 100;
                }
                else if (warp.AvailableItems.Contains(item))
                {
                    if (item.Rarity is SRItemRarity.Star3)
                    {
                        weight = 1;
                    }
                    else if (warp.WarpType is SRWarpType.StellarWarp or SRWarpType.DepartureWarp)
                    {
                        weight = 60;
                    }
                    else if (item is SRCharacter && warp.WarpType is SRWarpType.LightConeEventWarp)
                    {
                        weight = 50 - warp.Common4Characters.Length;
                    }
                    else if (item is SRLightCone && warp.WarpType is SRWarpType.CharacterEventWarp)
                    {
                        weight = 50 - warp.Common4LightCones.Length;
                    }
                    else
                    {
                        weight = 10;
                    }
                }
                else
                {
                    weight = 0;
                }
                return (warp, weight);
            });
        }

        private Dictionary<ISRWarpResultItem, HashSet<SRWarp>> BuildBestWarps()
        {
            Dictionary<ISRWarpResultItem, HashSet<SRWarp>> bestWarps = [];
            foreach (var item in _targets.Keys)
            {
                var best = GetWarpWithWeight(item)
                    .ToLookup(warpWithWeight => warpWithWeight.Weight)
                    .OrderByDescending(group => group.Key)
                    .FirstOrDefault(group => group.Key > 0)?
                    .Select(tuple => tuple.Warp)
                    .ToHashSet();
                if (best is null)
                {
                    _invalidTargets.Add(item);
                    _targets.Remove(item);
                    continue;
                }
                bestWarps[item] = best;
            }
            return bestWarps;
        }

        public ICLIWarpTarget Create()
        {
            _target ??= new CLIMultipleWarpTarget(_targets, BuildBestWarps());
            return _target.Clone();
        }
    }

    public sealed class CLIMultipleWarpTarget : ICLIWarpTarget
    {
        private readonly Dictionary<ISRWarpResultItem, int> _targetCounter;
        private readonly Dictionary<ISRWarpResultItem, HashSet<SRWarp>> _bestWarp;
        private readonly bool _noStar3;
        private readonly bool _noStar4;
        private bool _achieved;

        public bool Achieved => _achieved;

        public CLIMultipleWarpTarget(Dictionary<ISRWarpResultItem, int> targetCounter, Dictionary<ISRWarpResultItem, HashSet<SRWarp>> bestWarp)
        {
            _targetCounter = new(targetCounter);
            _bestWarp = new(bestWarp);
            _noStar3 = _targetCounter.Keys.All(item => item.Rarity is not SRItemRarity.Star3);
            _noStar4 = _targetCounter.Keys.All(item => item.Rarity is not SRItemRarity.Star4);
            _achieved = targetCounter.Count is 0;
        }

        public void Check(ISRWarpResultItem item)
        {
            if (_achieved) return;
            if (_noStar3 && item.Rarity is SRItemRarity.Star3) return;
            if (_noStar4 && item.Rarity is SRItemRarity.Star4) return;
            if (!_targetCounter.TryGetValue(item, out var count)) return;
            if (--count <= 0)
            {
                _targetCounter.Remove(item);
                _bestWarp.Remove(item);
                if (_targetCounter.Count is 0) _achieved = true;
                return;
            }
            _targetCounter[item] = count;
        }

        public ICLIWarpTarget Clone()
        {
            return new CLIMultipleWarpTarget(_targetCounter, _bestWarp);
        }

        public bool CanChangeWarp(SRWarp warp, bool checkOnly = true)
        {
            bool ret = _bestWarp.Values.All(warps => warps.Count > 1 || !warps.Contains(warp));
            if (ret && checkOnly)
            {
                foreach (var warps in _bestWarp.Values)
                {
                    warps.Remove(warp);
                }
            }
            return ret;
        }
    }
}
