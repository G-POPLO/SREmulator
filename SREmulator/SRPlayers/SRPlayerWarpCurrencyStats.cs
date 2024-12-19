using SREmulator.SRItems;
using System.Diagnostics;

namespace SREmulator.SRPlayers
{
    public sealed class SRPlayerWarpCurrencyStats : ISRPlayerStats<SRPlayerWarpCurrencyStats>
    {
        public bool NoWarpRewards;
        public bool UnlimitedResources;
        public int StarRailPass;
        public int StarRailSpecialPass;
        public int UndyingEmbers;
        public int UndyingStarlight;
        public int StellarJade;
        public int OneiricShard;

        // TODO: 无限抽卡资源
        public bool TryConsumeOneStarRailPassIndirectly()
        {
            if (UnlimitedResources)
            {
                return true;
            }

            if (StellarJade >= 160)
            {
                StellarJade -= 160;
                return true;
            }
            else if (OneiricShard > 0)
            {
                int need = 160 - StellarJade;
                if (OneiricShard >= need)
                {
                    OneiricShard -= need;
                    StellarJade = 0;
                    return true;
                }
            }

            if (UndyingStarlight >= 20)
            {
                UndyingStarlight -= 20;
                return true;
            }

            return false;
        }
        public bool TryConsumeOneStarRailPass()
        {
            if (StarRailPass > 0)
            {
                StarRailPass--;
                return true;
            }

            return TryConsumeOneStarRailPassIndirectly();
        }
        public bool TryConsumeOneStarRailSpecialPass()
        {
            if (StarRailSpecialPass > 0)
            {
                StarRailSpecialPass--;
                return true;
            }

            // TODO: 通票 -> 星芒 —> 专票

            return TryConsumeOneStarRailPassIndirectly();
        }
        public bool TryConsumeStarRailPassIndirectly(int count)
        {
            if (UnlimitedResources)
            {
                return true;
            }

            int total = (StellarJade + OneiricShard) / 160 + UndyingStarlight / 20;
            if (total >= count)
            {
                for (int i = 0; i < count; i++)
                {
                    bool result = TryConsumeOneStarRailPassIndirectly();
                    Debug.Assert(result);
                }
                return true;
            }

            return false;
        }
        public bool TryConsumeStarRailPass(int count)
        {
            if (StarRailPass >= count)
            {
                StarRailPass -= count;
                return true;
            }

            if (TryConsumeStarRailPassIndirectly(count - StarRailPass))
            {
                StarRailPass = 0;
                return true;
            }

            return false;
        }
        public bool TryConsumeStarRailSpecialPass(int count)
        {
            if (StarRailSpecialPass >= count)
            {
                StarRailSpecialPass -= count;
                return true;
            }

            if (TryConsumeStarRailPassIndirectly(count - StarRailSpecialPass))
            {
                StarRailSpecialPass = 0;
                return true;
            }

            return false;
        }

        public void GetWarpRewards(ISRWarpResultItem item, SRPlayerEidolonsStats characterStats)
        {
            const int DuplicateStar5CharacterEidolonsMaxed = 100;
            const int DuplicateStar5Character = 40;
            const int DuplicateStar4CharacterEidolonsMaxed = 20;
            const int DuplicateStar4Character = 8;
            const int Star5LightCone = 40;
            const int Star4LightCone = 8;
            const int Star3LightCone = 20;

            if (NoWarpRewards) return;

            if (item is SRLightCone)
            {
                if (item is SRStar5LightCone) UndyingStarlight += Star5LightCone;
                else if (item is SRStar4LightCone) UndyingStarlight += Star4LightCone;
                else UndyingEmbers += Star3LightCone;
            }
            else if (item is SRCharacter character)
            {
                // TODO: 新角色 -> 三张通票

                characterStats.TryAdd(character, out int eidolons);
                bool maxed = eidolons >= 6;
                if (eidolons is 0) return;
                else if (character is SRStar5Character) UndyingStarlight += maxed ? DuplicateStar5CharacterEidolonsMaxed : DuplicateStar5Character;
                else if (character is SRStar4Character) UndyingStarlight += maxed ? DuplicateStar4CharacterEidolonsMaxed : DuplicateStar4Character;
            }
        }
        public void GetSimulatedUniverseMaxPointRewards(SRPlayerLevelStats levelStats)
        {
            StarRailPass += 1;
            StellarJade += levelStats.EquilibriumLevel switch
            {
                0 or 1 => 40 + 35,
                2 => 55 + 50,
                3 => 70 + 65,
                4 => 85 + 80,
                5 => 100 + 95,
                6 => 115 + 110,

                _ => throw new InvalidOperationException(nameof(levelStats.EquilibriumLevel))
            };
        }
        public void GetDailyTrainingRewards() // 每日训练
        {
            StellarJade += 10 + 10 + 10 + 15 + 15;
        }
        public void GetExpressSupplyPassRewards() // 小月卡
        {
            StellarJade += 90 + 300 / 30;
        }
        public void GetTreasuresLightwardRewards() // 深渊
        {
            StellarJade += 800;
        }
        public void GetStoreEmbersExchangeRewards(bool starRailPassFirst = false) // 商店
        {
            // TODO
            //if (starRailPassFirst)
            //{
            //    int count = UndyingEmbers / 90;
            //    StarRailPass += Math.Min(5, count);
            //    count = Math.Max(0, count - 5);
            //    StarRailSpecialPass += Math.Min(5, count);
            //}
            //else
            //{
            //    int count = UndyingEmbers / 90;
            //    StarRailSpecialPass += Math.Min(5, count);
            //    count = Math.Max(0, count - 5);
            //    StarRailPass += Math.Min(5, count);
            //}

            StarRailPass += 5;
            StarRailSpecialPass += 5;
        }
        public void DaysLater(int days, bool expressSupplyPass, SRPlayerLevelStats levelStats)
        {
            DateTime _2024_12_16 = new(2024, 12, 16);

            DateTime now = DateTime.Now;
            while (days-- > 0)
            {
                now = now.AddDays(1);
                if (now.Day is 1) GetStoreEmbersExchangeRewards();
                if (now.DayOfWeek is DayOfWeek.Monday)
                {
                    if ((now - _2024_12_16).Days / 7 % 2 is 1)
                    {
                        GetTreasuresLightwardRewards();
                    }

                    GetSimulatedUniverseMaxPointRewards(levelStats);
                }

                GetDailyTrainingRewards();
                if (expressSupplyPass) GetExpressSupplyPassRewards();
            }
        }

        public SRPlayerWarpCurrencyStats Clone()
        {
            return (SRPlayerWarpCurrencyStats)MemberwiseClone();
        }
    }
}
