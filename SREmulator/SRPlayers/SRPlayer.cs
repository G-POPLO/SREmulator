namespace SREmulator.SRPlayers
{
    public sealed class SRPlayer
    {
        public SRPlayerWarpCurrencyStats WarpCurrencyStats { get; set; } = new();
        public SRPlayerWarpStats CharacterEventStats { get; set; } = new();
        public SRPlayerWarpStats LightConeEventStats { get; set; } = new();
        public SRPlayerWarpStats StellarStats { get; set; } = new();
        public SRPlayerWarpStats DepartureStats { get; set; } = new();
        public SRPlayerEidolonsStats EidolonsStats { get; set; } = new();

        public SRPlayer() { }
    }
}
