using SREmulator.Attributes;
using static SREmulator.Localizations.SRCharacterKeys;
using static SREmulator.Localizations.SRLightConeKeys;

namespace SREmulator.Localizations
{
    public static class SREventWarpKeys
    {
        [SRCharacterEventWarp(ButterflyOnSwordtip, 1, 1, 0, Seele, Natasha, Hook, Pela)]
        [SRLightConeEventWarp(ButterflyOnSwordtip, 1, 1, 0, InTheNight, PostOpConversation, GoodNightAndSleepWell, TheMolesWelcomeYou)]
        [SRCharacterEventWarp(ButterflyOnSwordtip, 2, 1, 4, Seele, Guinaifen, Luka, Sushang)]
        [SRLightConeEventWarp(ButterflyOnSwordtip, 2, 1, 4, InTheNight, TheMolesWelcomeYou, ResolutionShinesAsPearlsOfSweat, OnlySilenceRemains)]
        public const string ButterflyOnSwordtip = nameof(ButterflyOnSwordtip);

        [SRCharacterEventWarp(SwirlOfHeavenlySpear, 1, 1, 0, JingYuan, March7th, Tingyun, Sushang)]
        [SRLightConeEventWarp(SwirlOfHeavenlySpear, 1, 1, 0, BeforeDawn, DayOneOfMyNewLife, OnlySilenceRemains, PlanetaryRendezvous)]
        [SRCharacterEventWarp(SwirlOfHeavenlySpear, 2, 2, 0, JingYuan, Sampo, Hanya, Qingque)]
        [SRLightConeEventWarp(SwirlOfHeavenlySpear, 2, 2, 0, BeforeDawn, PlanetaryRendezvous, GeniusesRepose, UnderTheBlueSky)]
        [SRCharacterEventWarp(SwirlOfHeavenlySpear, 3, 2, 7, JingYuan, Qingque, Arlan, Tingyun)]
        [SRLightConeEventWarp(SwirlOfHeavenlySpear, 3, 2, 7, BeforeDawn, PoisedToBloom, TheBirthOfTheSelf, Swordplay)]
        public const string SwirlOfHeavenlySpear = nameof(SwirlOfHeavenlySpear);

        [SRCharacterEventWarp(ContractZero, 1, 1, 1, SilverWolf, DanHeng, Asta, Serval)]
        [SRLightConeEventWarp(ContractZero, 1, 1, 1, IncessantRain, SubscribeForMore, MemoriesOfThePast, MakeTheWorldClamor)]
        [SRCharacterEventWarp(ContractZero, 2, 1, 5, SilverWolf, Asta, Lynx, Hanya)]
        [SRLightConeEventWarp(ContractZero, 2, 1, 5, IncessantRain, UnderTheBlueSky, PostOpConversation, TheBirthOfTheSelf)]
        public const string ContractZero = nameof(ContractZero);

        [SRCharacterEventWarp(LaicPursuit, 1, 1, 1, Luocha, Pela, Qingque, Yukong)]
        [SRLightConeEventWarp(LaicPursuit, 1, 1, 1, EchoesOfTheCoffin, GoodNightAndSleepWell, DanceDanceDance, GeniusesRepose)]
        [SRCharacterEventWarp(LaicPursuit, 2, 2, 1, Luocha, Gallagher, Pela, DanHeng)]
        [SRLightConeEventWarp(LaicPursuit, 2, 2, 1, EchoesOfTheCoffin, GoodNightAndSleepWell, PostOpConversation, SubscribeForMore)]
        public const string LaicPursuit = nameof(LaicPursuit);

        [SRCharacterEventWarp(ALostSoul, 1, 1, 2, Blade, Arlan, Sushang, Natasha)]
        [SRLightConeEventWarp(ALostSoul, 1, 1, 2, TheUnreachableSide, SharedFeeling, Swordplay, ASecretVow)]
        [SRCharacterEventWarp(ALostSoul, 2, 1, 6, Blade, Xueyi, March7th, Tingyun)]
        [SRLightConeEventWarp(ALostSoul, 2, 1, 6, TheUnreachableSide, ASecretVow, DayOneOfMyNewLife, PlanetaryRendezvous)]
        public const string ALostSoul = nameof(ALostSoul);

        [SRCharacterEventWarp(NessunDorma, 1, 1, 2, Kafka, Luka, Sampo, Serval)]
        [SRLightConeEventWarp(NessunDorma, 1, 1, 2, PatienceIsAllYouNeed, ResolutionShinesAsPearlsOfSweat, EyesOfThePrey, TheBirthOfTheSelf)]
        [SRCharacterEventWarp(NessunDorma, 2, 1, 6, Kafka, Sushang, Natasha, Hook)]
        [SRLightConeEventWarp(NessunDorma, 2, 1, 6, PatienceIsAllYouNeed, PerfectTiming, OnlySilenceRemains, LandausChoice)]
        public const string NessunDorma = nameof(NessunDorma);

        [SRCharacterEventWarp(IndelibleCoterieKafka, 1, 2, 5, Kafka, Moze, Asta, Luka)]
        [SRLightConeEventWarp(IndelibleCoterieKafka, 1, 2, 5, PatienceIsAllYouNeed, Swordplay, ResolutionShinesAsPearlsOfSweat, TheBirthOfTheSelf)]
        public const string IndelibleCoterieKafka = nameof(IndelibleCoterieKafka);

        [SRCharacterEventWarp(EpochalSpectrum, 1, 1, 3, DanHengImbibitorLunae, Yukong, Asta, March7th)]
        [SRLightConeEventWarp(EpochalSpectrum, 1, 1, 3, BrighterThanTheSun, DanceDanceDance, PlanetaryRendezvous, LandausChoice)]
        [SRCharacterEventWarp(EpochalSpectrum, 2, 2, 0, DanHengImbibitorLunae, Misha, Guinaifen, Tingyun)]
        [SRLightConeEventWarp(EpochalSpectrum, 2, 2, 0, BrighterThanTheSun, IndeliblePromise, ResolutionShinesAsPearlsOfSweat, DanceDanceDance)]
        [SRCharacterEventWarp(EpochalSpectrum, 3, 2, 6, DanHengImbibitorLunae, Yukong, Lynx, Xueyi)]
        [SRLightConeEventWarp(EpochalSpectrum, 3, 2, 6, BrighterThanTheSun, DreamsMontage, AfterTheCharmonyFall, UnderTheBlueSky)]
        public const string EpochalSpectrum = nameof(EpochalSpectrum);

        [SRCharacterEventWarp(ForeseenForeknownForetold, 1, 1, 3, FuXuan, Lynx, Hook, Pela)]
        [SRLightConeEventWarp(ForeseenForeknownForetold, 1, 1, 3, SheAlreadyShutHerEyes, TrendOfTheUniversalMarket, PerfectTiming, UnderTheBlueSky)]
        [SRCharacterEventWarp(ForeseenForeknownForetold, 2, 2, 2, FuXuan, Pela, Luka, Hook)]
        [SRLightConeEventWarp(ForeseenForeknownForetold, 2, 2, 2, SheAlreadyShutHerEyes, GeniusesRepose, ASecretVow, LandausChoice)]
        public const string ForeseenForeknownForetold = nameof(ForeseenForeknownForetold);

        [SRCharacterEventWarp(GentleEclipseOfTheMoon, 1, 1, 4, Jingliu, Tingyun, Sampo, Qingque)]
        [SRLightConeEventWarp(GentleEclipseOfTheMoon, 1, 1, 4, IShallBeMyOwnSword, MakeTheWorldClamor, MemoriesOfThePast, EyesOfThePrey)]
        [SRCharacterEventWarp(GentleEclipseOfTheMoon, 2, 2, 1, Jingliu, Serval, Luka, Lynx)]
        [SRLightConeEventWarp(GentleEclipseOfTheMoon, 2, 2, 1, IShallBeMyOwnSword, ConcertForTwo, MakeTheWorldClamor, SharedFeeling)]
        public const string GentleEclipseOfTheMoon = nameof(GentleEclipseOfTheMoon);

        [SRCharacterEventWarp(SunsetClause, 1, 1, 4, TopazNumby, Guinaifen, Luka, Sushang)]
        [SRLightConeEventWarp(SunsetClause, 1, 1, 4, WorrisomeBlissful, TheMolesWelcomeYou, ResolutionShinesAsPearlsOfSweat, OnlySilenceRemains)]
        [SRCharacterEventWarp(SunsetClause, 2, 2, 2, TopazNumby, Xueyi, Hanya, March7th)]
        [SRLightConeEventWarp(SunsetClause, 2, 2, 2, WorrisomeBlissful, Swordplay, BoundlessChoreo, PerfectTiming)]
        [SRCharacterEventWarp(SunsetClause, 3, 2, 5, TopazNumby, Natasha, Guinaifen, Misha)]
        [SRLightConeEventWarp(SunsetClause, 3, 2, 5, WorrisomeBlissful, ShadowedByNight, SharedFeeling, PlanetaryRendezvous)]
        public const string SunsetClause = nameof(SunsetClause);

        [SRCharacterEventWarp(BloomInGloom, 1, 1, 5, Huohuo, DanHeng, Arlan, Serval)]
        [SRLightConeEventWarp(BloomInGloom, 1, 1, 5, NightOfFright, SharedFeeling, SubscribeForMore, TrendOfTheUniversalMarket)]
        [SRCharacterEventWarp(BloomInGloom, 2, 2, 4, Huohuo, Hanya, Yukong, Lynx)]
        [SRLightConeEventWarp(BloomInGloom, 2, 2, 4, NightOfFright, TheMolesWelcomeYou, PerfectTiming, TheBirthOfTheSelf)]
        public const string BloomInGloom = nameof(BloomInGloom);

        [SRCharacterEventWarp(ThornsOfScentedCrown, 1, 1, 5, Argenti, Asta, Lynx, Hanya)]
        [SRLightConeEventWarp(ThornsOfScentedCrown, 1, 1, 5, AnInstantBeforeAGaze, UnderTheBlueSky, PostOpConversation, TheBirthOfTheSelf)]
        [SRCharacterEventWarp(ThornsOfScentedCrown, 2, 2, 3, Argenti, Serval, Natasha, Asta)]
        [SRLightConeEventWarp(ThornsOfScentedCrown, 2, 2, 3, AnInstantBeforeAGaze, SharedFeeling, TrendOfTheUniversalMarket, AfterTheCharmonyFall)]
        public const string ThornsOfScentedCrown = nameof(ThornsOfScentedCrown);

        [SRCharacterEventWarp(FloralTriptych, 1, 1, 6, RuanMei, Xueyi, March7th, Tingyun)]
        [SRLightConeEventWarp(FloralTriptych, 1, 1, 6, PastSelfInMirror, ASecretVow, DayOneOfMyNewLife, PlanetaryRendezvous)]
        [SRCharacterEventWarp(FloralTriptych, 2, 2, 3, RuanMei, Xueyi, Misha, Gallagher)]
        [SRLightConeEventWarp(FloralTriptych, 2, 2, 3, PastSelfInMirror, MemoriesOfThePast, DayOneOfMyNewLife, EyesOfThePrey)]
        public const string FloralTriptych = nameof(FloralTriptych);

        [SRCharacterEventWarp(PantaRhei, 1, 1, 6, DrRatio, Sushang, Natasha, Hook)]
        [SRLightConeEventWarp(PantaRhei, 1, 1, 6, BaptismOfPureThought, PerfectTiming, OnlySilenceRemains, LandausChoice)]
        public const string PantaRhei = nameof(PantaRhei);

        [SRCharacterEventWarp(RipplesInReflection, 1, 2, 0, BlackSwan, Misha, Guinaifen, Tingyun)]
        [SRLightConeEventWarp(RipplesInReflection, 1, 2, 0, ReforgedRemembrance, IndeliblePromise, ResolutionShinesAsPearlsOfSweat, DanceDanceDance)]
        public const string RipplesInReflection = nameof(RipplesInReflection);

        [SRCharacterEventWarp(IndelibleCoterieBlackSwan, 1, 2, 5, BlackSwan, Moze, Asta, Luka)]
        [SRLightConeEventWarp(IndelibleCoterieBlackSwan, 1, 2, 5, ReforgedRemembrance, Swordplay, ResolutionShinesAsPearlsOfSweat, TheBirthOfTheSelf)]
        public const string IndelibleCoterieBlackSwan = nameof(IndelibleCoterieBlackSwan);

        [SRCharacterEventWarp(SparklingSplendor, 1, 2, 0, Sparkle, Sampo, Hanya, Qingque)]
        [SRLightConeEventWarp(SparklingSplendor, 1, 2, 0, EarthlyEscapade, PlanetaryRendezvous, GeniusesRepose, UnderTheBlueSky)]
        [SRCharacterEventWarp(SparklingSplendor, 2, 2, 4, Sparkle, Hook, Guinaifen, Arlan)]
        [SRLightConeEventWarp(SparklingSplendor, 2, 2, 4, EarthlyEscapade, PoisedToBloom, EyesOfThePrey, ASecretVow)]
        public const string SparklingSplendor = nameof(SparklingSplendor);

        [SRCharacterEventWarp(WordsOfYore, 1, 2, 1, Acheron, Gallagher, Pela, DanHeng)]
        [SRLightConeEventWarp(WordsOfYore, 1, 2, 1, AlongThePassingShore, GoodNightAndSleepWell, PostOpConversation, SubscribeForMore)]
        [SRCharacterEventWarp(WordsOfYore, 2, 2, 6, Acheron, Sampo, Pela, March7th)]
        [SRLightConeEventWarp(WordsOfYore, 2, 2, 6, AlongThePassingShore, BoundlessChoreo, DayOneOfMyNewLife, MakeTheWorldClamor)]
        public const string WordsOfYore = nameof(WordsOfYore);

        [SRCharacterEventWarp(GildedImprisonment, 1, 2, 1, Aventurine, Serval, Luka, Lynx)]
        [SRLightConeEventWarp(GildedImprisonment, 1, 2, 1, InherentlyUnjustDestiny, ConcertForTwo, MakeTheWorldClamor, SharedFeeling)]
        [SRCharacterEventWarp(GildedImprisonment, 2, 2, 6, Aventurine, Sampo, Pela, March7th)]
        [SRLightConeEventWarp(GildedImprisonment, 2, 2, 6, InherentlyUnjustDestiny, BoundlessChoreo, DayOneOfMyNewLife, MakeTheWorldClamor)]
        public const string GildedImprisonment = nameof(GildedImprisonment);

        [SRCharacterEventWarp(JustIntonation, 1, 2, 2, Robin, Xueyi, Hanya, March7th)]
        [SRLightConeEventWarp(JustIntonation, 1, 2, 2, FlowingNightglow, Swordplay, BoundlessChoreo, PerfectTiming)]
        public const string JustIntonation = nameof(JustIntonation);

        [SRCharacterEventWarp(IndelibleCoterieRobin, 1, 2, 5, Robin, Moze, Asta, Luka)]
        [SRLightConeEventWarp(IndelibleCoterieRobin, 1, 2, 5, FlowingNightglow, Swordplay, ResolutionShinesAsPearlsOfSweat, TheBirthOfTheSelf)]
        public const string IndelibleCoterieRobin = nameof(IndelibleCoterieRobin);

        [SRCharacterEventWarp(DustyTrailsLoneStar, 1, 2, 2, Boothill, Pela, Luka, Hook)]
        [SRLightConeEventWarp(DustyTrailsLoneStar, 1, 2, 2, SailingTowardsASecondLife, GeniusesRepose, ASecretVow, LandausChoice)]
        public const string DustyTrailsLoneStar = nameof(DustyTrailsLoneStar);

        [SRCharacterEventWarp(FirefullFlyshine, 1, 2, 3, Firefly, Xueyi, Misha, Gallagher)]
        [SRLightConeEventWarp(FirefullFlyshine, 1, 2, 3, WhereaboutsShouldDreamsRest, MemoriesOfThePast, DayOneOfMyNewLife, EyesOfThePrey)]
        [SRCharacterEventWarp(FirefullFlyshine, 2, 2, 7, Firefly, Gallagher, Yukong, Misha)]
        [SRLightConeEventWarp(FirefullFlyshine, 2, 2, 7, WhereaboutsShouldDreamsRest, IndeliblePromise, ResolutionShinesAsPearlsOfSweat, ConcertForTwo)]
        public const string FirefullFlyshine = nameof(FirefullFlyshine);

        [SRCharacterEventWarp(LienOnLifeLeaseOnFate, 1, 2, 3, Jade, Serval, Natasha, Asta)]
        [SRLightConeEventWarp(LienOnLifeLeaseOnFate, 1, 2, 3, YetHopeIsPriceless, SharedFeeling, TrendOfTheUniversalMarket, AfterTheCharmonyFall)]
        public const string LienOnLifeLeaseOnFate = nameof(LienOnLifeLeaseOnFate);

        [SRCharacterEventWarp(EarthHurledEtherCurled, 1, 2, 4, Yunli, Hanya, Yukong, Lynx)]
        [SRLightConeEventWarp(EarthHurledEtherCurled, 1, 2, 4, DanceAtSunset, TheMolesWelcomeYou, PerfectTiming, TheBirthOfTheSelf)]
        public const string EarthHurledEtherCurled = nameof(EarthHurledEtherCurled);

        [SRCharacterEventWarp(CauldronContrivance, 1, 2, 4, Jiaoqiu, Hook, Guinaifen, Arlan)]
        [SRLightConeEventWarp(CauldronContrivance, 1, 2, 4, ThoseManySprings, PoisedToBloom, EyesOfThePrey, ASecretVow)]
        public const string CauldronContrivance = nameof(CauldronContrivance);

        [SRCharacterEventWarp(StormridersBolt, 1, 2, 5, Feixiao, Moze, Asta, Luka)]
        [SRLightConeEventWarp(StormridersBolt, 1, 2, 5, IVentureForthToHunt, Swordplay, ResolutionShinesAsPearlsOfSweat, TheBirthOfTheSelf)]
        public const string StormridersBolt = nameof(StormridersBolt);

        [SRCharacterEventWarp(LetScentSinkIn, 1, 2, 5, Lingsha, Natasha, Guinaifen, Misha)]
        [SRLightConeEventWarp(LetScentSinkIn, 1, 2, 5, ScentAloneStaysTrue, ShadowedByNight, SharedFeeling, PlanetaryRendezvous)]
        public const string LetScentSinkIn = nameof(LetScentSinkIn);

        [SRCharacterEventWarp(EyesOfANinja, 1, 2, 6, Rappa, Yukong, Lynx, Xueyi)]
        [SRLightConeEventWarp(EyesOfANinja, 1, 2, 6, NinjutsuInscriptionDazzlingEvilbreaker, DreamsMontage, AfterTheCharmonyFall, UnderTheBlueSky)]
        public const string EyesOfANinja = nameof(EyesOfANinja);

        [SRCharacterEventWarp(EyesToTheStars, 1, 2, 7, Sunday, Qingque, Arlan, Tingyun)]
        [SRLightConeEventWarp(EyesToTheStars, 1, 2, 7, AGroundedAscent, PoisedToBloom, TheBirthOfTheSelf, Swordplay)]
        public const string EyesToTheStars = nameof(EyesToTheStars);

        [SRCharacterEventWarp(TheLongVoyageHome, 1, 2, 7, Fugue, Gallagher, Yukong, Misha)]
        [SRLightConeEventWarp(TheLongVoyageHome, 1, 2, 7, LongRoadLeadsHome, IndeliblePromise, ResolutionShinesAsPearlsOfSweat, ConcertForTwo)]
        public const string TheLongVoyageHome = nameof(TheLongVoyageHome);
    }
}
