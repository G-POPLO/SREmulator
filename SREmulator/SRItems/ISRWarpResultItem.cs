namespace SREmulator.SRItems
{
    public interface ISRWarpResultItem
    {
        public SRItemRarity Rarity { get; }
        public string Name { get; }
        public bool Limited { get; }

        public static bool Equals(ISRWarpResultItem item1, ISRWarpResultItem item2)
        {
            //Console.WriteLine(item1);
            //Console.WriteLine(item2);
            //Console.WriteLine(item1.Name == item2.Name);
            return item1.Name == item2.Name;
        }
        public static bool Contains(ReadOnlySpan<ISRWarpResultItem> items, ISRWarpResultItem item)
        {
            foreach (var item2 in items)
            {
                if (Equals(item, item2)) return true;
            }
            return false;
        }
    }


}
