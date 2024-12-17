using SREmulator.SRItems;
using System.Collections.ObjectModel;

namespace SREmulator.CLI
{
    public class CLIWarpTarget
    {
        private Dictionary<ISRWarpResultItem, int>? _targetCount = null;

        public int this[ISRWarpResultItem item]
        {
            get
            {
                _targetCount ??= [];
                _targetCount.TryGetValue(item, out var count);
                return count;
            }
            set
            {
                _targetCount ??= [];
                _targetCount[item] = value;
            }
        }

        public ReadOnlyDictionary<ISRWarpResultItem, int> Target => new(_targetCount ?? []);

        public void Check(ISRWarpResultItem item)
        {
            if (_targetCount is null) return;
            if (!_targetCount.TryGetValue(item, out var count)) return;
            if (count <= 0) return;
            _targetCount[item] = count - 1;
        }

        public bool IsAchieved()
        {
            return _targetCount?.All(pair => pair.Value <= 0) ?? true;
        }

        public CLIWarpTarget Clone()
        {
            var target = new CLIWarpTarget();
            if (_targetCount is not null) target._targetCount = new Dictionary<ISRWarpResultItem, int>(_targetCount);
            return target;
        }
    }
}
