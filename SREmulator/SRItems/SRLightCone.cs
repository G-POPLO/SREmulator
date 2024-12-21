namespace SREmulator.SRItems
{
    public static partial class SRLightCones
    {
        public static partial SRLightCone? GetItemByName(string? name);
    }

    public abstract class SRLightCone : SRItem, ISRWarpResultItem
    {
        public abstract bool Limited { get; }
    }

    public abstract class SRStar5LightCone : SRLightCone
    {
        public sealed override SRItemRarity Rarity => SRItemRarity.Star5;
    }

    public abstract class SRLimitedStar5LightCone : SRStar5LightCone
    {
        public static SRLimitedStar5LightCone Case { get; } = new SRLimitedStar5LightConeCase();

        public sealed override bool Limited => true;

        private sealed class SRLimitedStar5LightConeCase : SRLimitedStar5LightCone
        {
            public override string Name => nameof(SRLimitedStar5LightCone);
        }
    }

    public abstract class SRNonLimitedStar5LightCone : SRStar5LightCone
    {
        public static SRNonLimitedStar5LightCone Case { get; } = new SRLimitedStar5LightConeCase();

        public sealed override bool Limited => false;

        private sealed class SRLimitedStar5LightConeCase : SRNonLimitedStar5LightCone
        {
            public override string Name => nameof(SRNonLimitedStar5LightCone);
        }
    }

    public abstract class SRStar4LightCone : SRLightCone
    {
        public static SRStar4LightCone Case { get; } = new SRStar4LightConeCase();

        public sealed override SRItemRarity Rarity => SRItemRarity.Star4;
        public sealed override bool Limited => false;

        private sealed class SRStar4LightConeCase : SRStar4LightCone
        {
            public override string Name => nameof(SRStar4LightCone);
        }
    }

    public abstract class SRStar3LightCone : SRLightCone
    {
        public static SRStar3LightCone Case { get; } = new SRStar3LightConeCase();

        public sealed override SRItemRarity Rarity => SRItemRarity.Star3;
        public sealed override bool Limited => false;

        private sealed class SRStar3LightConeCase : SRStar3LightCone
        {
            public override string Name => nameof(SRStar3LightCone);
        }
    }
}
