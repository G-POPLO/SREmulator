namespace SREmulator.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public sealed class SRCharacterAttribute : Attribute
    {
        public string Key { get; }
        public int Rarity { get; }
        public bool Limited { get; }

        public SRCharacterAttribute(string key, int rarity, bool limited = false)
        {
            Key = key;
            Rarity = rarity;
            Limited = limited;
        }
    }
}
