namespace SREmulator.SourceGeneration.Receivers
{
    public class SRLightConeKeysClassReceiver : SRKeysClassReceiver
    {
        protected override string AttributeName => "SRLightConeAttribute";
        protected override string ClassName => "SRLightConeKeys";
    }
}