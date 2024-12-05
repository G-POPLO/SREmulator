namespace SREmulator.SourceGeneration.Receivers
{
    public class SRLightConeEventWarpKeysClassReceiver : SRKeysClassReceiver
    {
        protected override string AttributeName => "SRLightConeEventWarpAttribute";
        protected override string ClassName => "SREventWarpKeys";
    }
}