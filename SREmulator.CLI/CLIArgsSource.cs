namespace SREmulator.CLI
{
    public sealed class CLIArgsSource
    {
        private readonly string[] _args;
        private List<string>? _warnings;
        private int _current = -1;

        public List<string> Warnings => _warnings ??= [];

        public CLIArgsSource(string[] args)
        {
            _args = args;
        }

        public void Warning(string? message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;
            Warnings.Add(message);
        }

        public string Next()
        {
            if (_current + 1 >= _args.Length) return string.Empty;
            return _args[++_current];
        }

        public int NextInt32(int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            string s = Next();
            if (!int.TryParse(s, out int value))
            {
                Warning($"参数错误 '{s}' （参数应为整数）");
                value = default;
            }
            int ret = Math.Clamp(value, minValue, maxValue);
            if (ret != value) Warning($"参数错误 '{s}'（参数范围为 [{minValue}, {maxValue}]）");
            return ret;
            //if () return Math.Clamp(value, minValue, maxValue);
            //return Math.Clamp(0, minValue, maxValue);
        }
    }
}
