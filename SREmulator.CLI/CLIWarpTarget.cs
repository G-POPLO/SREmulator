using SREmulator.SRItems;
using System.Collections.ObjectModel;

namespace SREmulator.CLI
{
    public class CLIWarpTarget
    {
        private Dictionary<ISRWarpResultItem, int>? _targetCounter = null;
        private bool _noStar3 = true;
        private bool _noStar4 = true;

        public ReadOnlyDictionary<ISRWarpResultItem, int> Target => new(_targetCounter ?? []);

        public void AppendTarget(ISRWarpResultItem target, int count)
        {
            if (count <= 0) return;
            _targetCounter ??= [];
            _targetCounter[target] = count;
            if (target.Rarity is SRItemRarity.Star3) _noStar3 = true;
            else if (target.Rarity is SRItemRarity.Star4) _noStar4 = true;
        }

        public void Check(ISRWarpResultItem item)
        {
            if (_targetCounter is null) return;
            if (_noStar3 && item.Rarity is SRItemRarity.Star3) return;
            if (_noStar4 && item.Rarity is SRItemRarity.Star4) return;
            if (!_targetCounter.TryGetValue(item, out var count)) return;
            if (--count <= 0)
            {
                _targetCounter.Remove(item);
                if (_targetCounter.Count is 0) _targetCounter = null;
                return;
            }
            _targetCounter[item] = count;
        }

        public bool IsAchieved()
        {
            return _targetCounter is null;
            //return _targetCounter?.All(pair => pair.Value <= 0) ?? true;
        }

        public CLIWarpTarget Clone()
        {
            var target = new CLIWarpTarget();
            if (_targetCounter is not null) target._targetCounter = new Dictionary<ISRWarpResultItem, int>(_targetCounter);
            return target;
        }
    }
}
