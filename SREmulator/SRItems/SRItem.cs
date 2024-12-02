namespace SREmulator.SRItems
{
    public enum SRItemRarity
    {
        None = 0,
        Star1 = 1,
        Star2 = 2,
        Star3 = 3,
        Star4 = 4,
        Star5 = 5
    }

    public abstract record class SRItem
    {
        public abstract SRItemRarity Rarity { get; }
        public abstract string Name { get; }

        private string? _rarityStarsText = null;
        public string RarityStarsText => _rarityStarsText ??= new string('✦', (int)Rarity);
    }
}
