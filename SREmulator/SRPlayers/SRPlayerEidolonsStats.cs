using SREmulator.SRItems;

namespace SREmulator.SRPlayers
{
    internal sealed class SRPlayerEidolonsStats
    {
        internal Dictionary<SRCharacter, int> CharacterEidolons { get; set; } = [];

        public bool TryAdd(SRCharacter character, out int eidolons)
        {
            if (!CharacterEidolons.TryGetValue(character, out eidolons)) eidolons = -1;
            if (eidolons >= 6) return false;
            CharacterEidolons[character] = eidolons += 1;
            return true;
        }
    }
}
