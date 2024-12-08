namespace SREmulator.SRItems
{
    public static partial class SRCharacters
    {
        public static partial SRCharacter? GetItemByName(string name);
    }

    public abstract class SRCharacter : SRItem, ISRWarpResultItem
    {
        public abstract bool Limited { get; }
    }

    public abstract class SRStar5Character : SRCharacter
    {
        public sealed override SRItemRarity Rarity => SRItemRarity.Star5;
    }

    public abstract class SRLimitedStar5Character : SRStar5Character
    {
        public static SRLimitedStar5Character Case { get; } = new SRLimitedStar5CharacterCase();

        public sealed override bool Limited => true;

        private sealed class SRLimitedStar5CharacterCase : SRLimitedStar5Character
        {
            public override string Name => nameof(SRLimitedStar5Character);
        }
    }

    public abstract class SRNonLimitedStar5Character : SRStar5Character
    {
        public static SRNonLimitedStar5Character Case { get; } = new SRNonLimitedStar5CharacterCase();

        public sealed override bool Limited => false;

        private sealed class SRNonLimitedStar5CharacterCase : SRNonLimitedStar5Character
        {
            public override string Name => nameof(SRNonLimitedStar5Character);
        }
    }

    public abstract class SRStar4Character : SRCharacter
    {
        public static SRStar4Character Case { get; } = new SRStar4CharacterCase();

        public sealed override SRItemRarity Rarity => SRItemRarity.Star4;
        public sealed override bool Limited => false;

        private sealed class SRStar4CharacterCase : SRStar4Character
        {
            public override string Name => nameof(SRStar4Character);
        }
    }
}
