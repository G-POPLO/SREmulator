namespace SREmulator.SRRelics
{
    public class SRRelic
    {
        private byte _level;
        private byte[] _points;

        public byte[] Points => _points;
        public byte Level => _level;
        public static byte MaxLevel => 15;

        public void Upgrade()
        {
            if (_level >= MaxLevel) throw new InvalidOperationException();

            _level++;
            if (_level % 3 is 0)
            {

            }
        }
    }
}
