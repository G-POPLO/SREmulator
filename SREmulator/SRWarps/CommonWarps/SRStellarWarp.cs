using SREmulator.SRItems;
using SREmulator.SRPlayers;

namespace SREmulator.SRWarps.CommonWarps
{
    public sealed class SRStellarWarp(SRVersion version) : SRWarp
    {
        public override SRWarpType WarpType => SRWarpType.StellarWarp;
        public override SRVersion Version => version;
        public override ISRWarpResultItem Up5 => null!;
        public override ISRWarpResultItem[] Common5Characters => SRCharacters.AllNonLimitedStar5Characters;
        public override ISRWarpResultItem[] Common5LightCones => SRLightCones.AllNonLimitedStar5LightCones;
        public override ISRWarpResultItem[] Up4 => null!;
        public override ISRWarpResultItem[] Common4Characters => SRWarpItemPoolFactory.CreateStar4Characters(Version);
        public override ISRWarpResultItem[] Common4LightCones => SRWarpItemPoolFactory.CreateStar4LightCones(Version);
        public override ISRWarpResultItem[] Common3 => SRLightCones.AllStar3LightCones;

        public override bool PreWarp(SRPlayer player, int count)
        {
            return count is 1 or 10 && player.WarpCurrencyStats.TryConsumeStarRailPass(count);
        }

        public override ISRWarpResultItem OnWarp(SRPlayer player)
        {
            return SRWarpCore.CommonWarp(WarpStats, player.StellarStats);
        }

        public override void PostWarp(SRPlayer player, ISRWarpResultItem item)
        {
            player.WarpCurrencyStats.GetWarpReward(item, player.CharacterStats);
        }
    }
}
