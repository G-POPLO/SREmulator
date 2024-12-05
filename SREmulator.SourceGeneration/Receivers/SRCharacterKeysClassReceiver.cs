namespace SREmulator.SourceGeneration.Receivers
{
    public class SRCharacterKeysClassReceiver : SRKeysClassReceiver
    {
        protected override string AttributeName => "SRCharacterAttribute";
        protected override string ClassName => "SRCharacterKeys";
    }
}