namespace SREmulator.SourceGeneration.Receivers
{
    public class SRCharacterEventWarpKeysClassReceiver : SRKeysClassReceiver
    {
        protected override string AttributeName => "SRCharacterEventWarpAttribute";
        protected override string ClassName => "SREventWarpKeys";
    }
}