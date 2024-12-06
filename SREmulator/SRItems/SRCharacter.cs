namespace SREmulator.SRItems
{
    public static partial class SRCharacters
    {

    }

    public abstract record class SRCharacter : SRItem, ISRWarpResultItem
    {
        public abstract bool Limited { get; }
    }

    public abstract record class SRStar5Character : SRCharacter
    {
        public sealed override SRItemRarity Rarity => SRItemRarity.Star5;
    }

    public abstract record class SRLimitedStar5Character : SRStar5Character
    {
        public static SRLimitedStar5Character Case { get; } = new SRLimitedStar5CharacterCase();

        public sealed override bool Limited => true;

        private sealed record class SRLimitedStar5CharacterCase : SRLimitedStar5Character
        {
            public override string Name => nameof(SRLimitedStar5Character);
        }
    }

    public abstract record class SRNonLimitedStar5Character : SRStar5Character
    {
        public static SRNonLimitedStar5Character Case { get; } = new SRNonLimitedStar5CharacterCase();

        public sealed override bool Limited => false;

        private sealed record class SRNonLimitedStar5CharacterCase : SRNonLimitedStar5Character
        {
            public override string Name => nameof(SRNonLimitedStar5Character);
        }
    }

    public abstract record class SRStar4Character : SRCharacter
    {
        public static SRStar4Character Case { get; } = new SRStar4CharacterCase();

        public sealed override SRItemRarity Rarity => SRItemRarity.Star4;
        public sealed override bool Limited => false;

        private sealed record class SRStar4CharacterCase : SRStar4Character
        {
            public override string Name => nameof(SRStar4Character);
        }
    }
}
