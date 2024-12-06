using SREmulator.SRItems;
using SREmulator.SRPlayers;

namespace SREmulator.SRWarps.EventWarps
{
    public abstract class SRLightConeEventWarp : SRWarp
    {
        public sealed override SRWarpType WarpType => SRWarpType.LightConeEventWarp;
        public override ISRWarpResultItem Up5 => UpStar5LightCone;
        public override ISRWarpResultItem[] Common5Characters => null!;
        public override ISRWarpResultItem[] Common5LightCones => [UpStar5LightCone, .. SRWarpItemPoolFactory.CreateStar5LightCones(Version)];
        public override ISRWarpResultItem[] Up4 => UpStar4LightCones;
        public override ISRWarpResultItem[] Common4Characters => SRWarpItemPoolFactory.CreateStar4Characters(Version);
        public override ISRWarpResultItem[] Common4LightCones => SRWarpItemPoolFactory.CreateStar4LightCones(Version).Except(UpStar4LightCones).ToArray();
        public override ISRWarpResultItem[] Common3 => SRWarpItemPoolFactory.CreateStar3LightCones(Version);

        public abstract SRStar5LightCone UpStar5LightCone { get; }
        public abstract SRStar4LightCone UpStar4LightCone1 { get; }
        public abstract SRStar4LightCone UpStar4LightCone2 { get; }
        public abstract SRStar4LightCone UpStar4LightCone3 { get; }

        public SRStar4LightCone[] UpStar4LightCones => [UpStar4LightCone1, UpStar4LightCone2, UpStar4LightCone3];

        public sealed override bool PreWarp(SRPlayer player, int count)
        {
            return count is 1 or 10 && player.WarpCurrencyStats.TryConsumeStarRailSpecialPass(count);
        }

        public sealed override ISRWarpResultItem OnWarp(SRPlayer player)
        {
            return SRWarpCore.LightConeEventWarp(WarpStats, player.LightConeEventStats);
        }

        public sealed override void PostWarp(SRPlayer player, ISRWarpResultItem item)
        {
            player.WarpCurrencyStats.GetWarpReward(item, player.CharacterStats);
        }
    }
}
