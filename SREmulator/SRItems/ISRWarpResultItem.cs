namespace SREmulator.SRItems
{
    public interface ISRWarpResultItem : IEquatable<ISRWarpResultItem>
    {
        public SRItemRarity Rarity { get; }
        public string Name { get; }
        public bool Limited { get; }
        public int Id { get; }

        bool IEquatable<ISRWarpResultItem>.Equals(ISRWarpResultItem? other)
        {
            return Id == other?.Id;
        }
    }
}
