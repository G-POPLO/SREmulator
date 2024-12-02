using SREmulator.SRItems;
using SREmulator.SRPlayers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SREmulator.SRWarps.CommonWarps
{
    public sealed class SRDepartureWarp : SRWarp
    {
        public static readonly SRDepartureWarp DepartureWarp = new();

        public override SRWarpType WarpType => SRWarpType.StellarWarp;

        public override ISRWarpResultItem Up5 => null!;
        public override ISRWarpResultItem[] Common5Characters => SRCharacters.AllNonLimitedStar5Characters;
        public override ISRWarpResultItem[] Common5LightCones => SRLightCones.AllNonLimitedStar5LightCones;
        public override ISRWarpResultItem[] Up4 => null!;
        public override ISRWarpResultItem[] Common4Characters => SRWarpItemPoolFactory.CreateStar4Characters(SRVersion.Ver1p0);
        public override ISRWarpResultItem[] Common4LightCones => SRWarpItemPoolFactory.CreateStar4LightCones(SRVersion.Ver1p0);
        public override ISRWarpResultItem[] Common3 => SRLightCones.AllStar3LightCones;

        public override bool PreWarp(SRPlayer player, int count)
        {
            
            int total = (int?)player.DepartureStats.ExtraInfo ?? 0;
            player.DepartureStats.ExtraInfo = total;
            return count is 10 && total < 50 && player.WarpCurrencyStats.TryConsumeStarRailPass(8);
        }

        public override ISRWarpResultItem OnWarp(SRPlayer player)
        {
            return SRWarpCore.CommonWarp(WarpStats, player.StellarStats);
        }

        public override void PostWarp(SRPlayer player, ISRWarpResultItem item)
        {
            player.WarpCurrencyStats.GetWarpReward(item, player.CharacterStats);
            int total = (int?)player.DepartureStats.ExtraInfo ?? 0;
            player.DepartureStats.ExtraInfo = total + 10;
        }

        //public bool Try10Warp(SRPlayer player, [NotNullWhen(true)] out ISRWarpResultItem[]? result)
        //{
        //    if (!PreWarp(player))
        //    {
        //        result = null;
        //        return false;
        //    }

        //    result = new ISRWarpResultItem[10];
        //    for (int i = 0; i < 10; i++)
        //    {
        //        result[i] = OnWarp(player);
        //        PostWarp(player, result[i]);
        //    }
            
        //    return true;
        //}
    }
}
