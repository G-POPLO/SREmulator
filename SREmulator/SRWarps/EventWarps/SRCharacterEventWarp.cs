using SREmulator.SRItems;
using SREmulator.SRPlayers;

namespace SREmulator.SRWarps.EventWarps
{
    public abstract class SRCharacterEventWarp : SRWarp
    {
        public sealed override SRWarpType WarpType => SRWarpType.CharacterEventWarp;
        public override ISRWarpResultItem Up5 => UpStar5Character;
        public override ISRWarpResultItem[] Common5Characters => [UpStar5Character, .. SRWarpItemPoolFactory.CreateStar5Characters(Version)];
        public override ISRWarpResultItem[] Common5LightCones => null!;
        public override ISRWarpResultItem[] Up4 => UpStar4Characters;
        public override ISRWarpResultItem[] Common4Characters => SRWarpItemPoolFactory.CreateStar4Characters(Version).Except(UpStar4Characters).ToArray();
        public override ISRWarpResultItem[] Common4LightCones => SRWarpItemPoolFactory.CreateStar4LightCones(Version);
        public override ISRWarpResultItem[] Common3 => SRWarpItemPoolFactory.CreateStar3LightCones(Version);

        public abstract SRStar5Character UpStar5Character { get; }
        public abstract SRStar4Character UpStar4Character1 { get; }
        public abstract SRStar4Character UpStar4Character2 { get; }
        public abstract SRStar4Character UpStar4Character3 { get; }

        public SRStar4Character[] UpStar4Characters => [UpStar4Character1, UpStar4Character2, UpStar4Character3];

        public sealed override bool PreWarp(SRPlayer player, int count)
        {
            return count is 1 or 10 && player.WarpCurrencyStats.TryConsumeStarRailSpecialPass(count);
        }

        public sealed override ISRWarpResultItem OnWarp(SRPlayer player)
        {
            return SRWarpCore.CharacterEventWarp(WarpStats, player.CharacterEventStats);
        }

        public sealed override void PostWarp(SRPlayer player, ISRWarpResultItem item)
        {
            player.WarpCurrencyStats.GetWarpReward(item, player.CharacterStats);
        }
    }
}
