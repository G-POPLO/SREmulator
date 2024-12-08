namespace SREmulator.SRPlayers
{
    public sealed class SRPlayer
    {
        internal SRPlayerWarpCurrencyStats WarpCurrencyStats { get; set; } = new();
        internal SRPlayerWarpStats CharacterEventStats { get; set; } = new();
        internal SRPlayerWarpStats LightConeEventStats { get; set; } = new();
        internal SRPlayerWarpStats StellarStats { get; set; } = new();
        internal SRPlayerWarpStats DepartureStats { get; set; } = new();
        internal SRPlayerEidolonsStats EidolonsStats { get; set; } = new();

        internal SRPlayer() { }
    }
}
