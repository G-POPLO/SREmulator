namespace SREmulator.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class SRLightConeAttribute : Attribute
    {
        public string Key { get; }
        public int Rarity { get; }
        public bool Limited { get; }

        public SRLightConeAttribute(string key, int rarity, bool limited = false)
        {
            Key = key;
            Rarity = rarity;
            Limited = limited;
        }
    }
}
