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
        public bool CanChangeWarp(SRWarp warp);
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

        private Dictionary<ISRWarpResultItem, SRWarp> BuildBestWarp()
        {
            Dictionary<ISRWarpResultItem, SRWarp> bestWarp = [];
            foreach (var item in _targets.Keys)
            {
                var best = _args.Warps.FirstOrDefault(warp => warp.AvailableUpItems.Contains(item));
                best ??= _args.Warps.FirstOrDefault(warp => warp.AvailableItems.Contains(item));
                if (best is null)
                {
                    _invalidTargets.Add(item);
                    _targets.Remove(item);
                    continue;
                }
                bestWarp[item] = best;
            }
            return bestWarp;
        }

        public ICLIWarpTarget Create()
        {
            _target ??= new CLIMultipleWarpTarget(_targets, BuildBestWarp());
            return _target.Clone();
        }
    }

    public sealed class CLIMultipleWarpTarget : ICLIWarpTarget
    {
        private readonly Dictionary<ISRWarpResultItem, int> _targetCounter;
        private readonly Dictionary<ISRWarpResultItem, SRWarp> _bestWarp;
        private readonly bool _noStar3;
        private readonly bool _noStar4;
        private bool _achieved;

        public bool Achieved => _achieved;

        public CLIMultipleWarpTarget(Dictionary<ISRWarpResultItem, int> targetCounter, Dictionary<ISRWarpResultItem, SRWarp> bestWarp)
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

        public bool CanChangeWarp(SRWarp warp)
        {
            return !_bestWarp.ContainsValue(warp);
        }
    }
}
