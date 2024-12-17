namespace SREmulator.CLI
{
    public sealed class CLIArgsSource
    {
        private readonly string[] _args;
        private int _current = -1;

        public CLIArgsSource(string[] args)
        {
            _args = args;
        }

        public string Next()
        {
            if (_current + 1 >= _args.Length) return string.Empty;
            return _args[++_current];
        }

        public int NextInt32(int minValue, int maxValue = int.MaxValue)
        {
            string s = Next();
            if (int.TryParse(s, out int value)) return Math.Clamp(value, minValue, maxValue);
            return Math.Clamp(0, minValue, maxValue);
        }
    }
}
