namespace SREmulator.Localizations
{
    public static class LocalizationManager
    {
        public static void SetCulture(string name)
        {
            Localization.Culture = new System.Globalization.CultureInfo(name);
        }
    }
}
