using SREmulator.SRItems;
using System.Diagnostics;

namespace SREmulator.SRPlayers
{
    internal sealed class SRPlayerWarpCurrencyStats
    {
        // TODO
        //public bool NoReward;
        public int StarRailPass;
        public int StarRailSpecialPass;
        public int UndyingEmbers;
        public int UndyingStarlight;
        public int StellarJade;
        public int OneiricShard;

        public bool TryConsumeOneStarRailPassIndirectly()
        {
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

            return TryConsumeOneStarRailPassIndirectly();
        }
        public bool TryConsumeStarRailPassIndirectly(int count)
        {
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
        public void GetWarpReward(ISRWarpResultItem item, SRPlayerCharacterStats characterStats)
        {
            // TODO: const number

            if (item is SRLightCone)
            {
                if (item is SRStar5LightCone) UndyingStarlight += 40;
                else if (item is SRStar5LightCone) UndyingStarlight += 8;
                else UndyingEmbers += 20;
            }
            else if (item is SRCharacter character)
            {
                characterStats.TryAdd(character, out int eidolons);
                bool maxed = eidolons >= 6;
                if (eidolons is 0) return;
                else if (character is SRStar5Character) UndyingStarlight += maxed ? 100 : 40;
                else if (character is SRStar4Character) UndyingStarlight += maxed ? 20 : 8;
            }
        }
    }
}
