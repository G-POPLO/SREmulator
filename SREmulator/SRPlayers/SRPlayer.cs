namespace SREmulator.SRPlayers
{
    public sealed class SRPlayer
    {
        internal SRPlayerWarpCurrencyStats WarpCurrencyStats { get; set; } = new();
        internal SRPlayerWarpStats CharacterEventStats { get; set; } = new();
        internal SRPlayerWarpStats LightConeEventStats { get; set; } = new();
        internal SRPlayerWarpStats StellarStats { get; set; } = new();
        internal SRPlayerWarpStats DepartureStats { get; set; } = new();
        internal SRPlayerCharacterStats CharacterStats { get; set; } = new();
        //public int StarRailPass => SRPlayerDatabase.StarRailPass[UID];
        //public int StarRailSpecialPass => SRPlayerDatabase.StarRailSpecialPass[UID];
        //public int UndyingEmbers => SRPlayerDatabase.UndyingEmbers[UID];
        //public int UndyingStarlight => SRPlayerDatabase.UndyingStarlight[UID];
        //public int StellarJade => SRPlayerDatabase.StellarJade[UID];
        //public int OneiricShard => SRPlayerDatabase.OneiricShard[UID];

        internal SRPlayer() { }
        internal SRPlayer(int uid) {  }

        //public SRPlayer Clone()
        //{
        //    return new SRPlayer()
        //    {
        //        CharacterEventStats = CharacterEventStats.Clone(),
        //        LightConeEventStats = LightConeEventStats.Clone(),
        //        StellarStats = StellarStats.Clone(),
        //        DepartureStats = DepartureStats.Clone(),

        //    };
        //}

        //internal bool TryConsumeOneStarRailPass(bool special)
        //{
        //    return SRPlayerDatabase.TryConsumeOneStarRailPass(_uid, special);
        //}
        //internal void GetWarpReward(SRItem item)
        //{

        //}
    }
}
