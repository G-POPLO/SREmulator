using SREmulator.SRItems;

namespace SREmulator.SRWarps.LightConeEventWarps
{
    public static class SRLightConeEventWarps
    {
        public static readonly SRLightConeEventWarp ButterflyOnSwordtip1 = new ButterflyOnSwordtip1();
        public static readonly SRLightConeEventWarp ButterflyOnSwordtip2 = new ButterflyOnSwordtip2();

        public static readonly SRLightConeEventWarp SwirlOfHeavenlySpear1 = new SwirlOfHeavenlySpear1();
        public static readonly SRLightConeEventWarp SwirlOfHeavenlySpear2 = new SwirlOfHeavenlySpear2();
        public static readonly SRLightConeEventWarp SwirlOfHeavenlySpear3 = new SwirlOfHeavenlySpear3();

        public static readonly SRLightConeEventWarp ContractZero1 = new ContractZero1();
        public static readonly SRLightConeEventWarp ContractZero2 = new ContractZero2();

        public static readonly SRLightConeEventWarp LaicPursuit1 = new LaicPursuit1();
        public static readonly SRLightConeEventWarp LaicPursuit2 = new LaicPursuit2();

        public static readonly SRLightConeEventWarp ALostSoul1 = new ALostSoul1();
        public static readonly SRLightConeEventWarp ALostSoul2 = new ALostSoul2();

        public static readonly SRLightConeEventWarp NessunDorma1 = new NessunDorma1();
        public static readonly SRLightConeEventWarp NessunDorma2 = new NessunDorma2();
        public static readonly SRLightConeEventWarp IndelibleCoterieKafka1 = new IndelibleCoterieKafka1();

        public static readonly SRLightConeEventWarp EpochalSpectrum1 = new EpochalSpectrum1();
        public static readonly SRLightConeEventWarp EpochalSpectrum2 = new EpochalSpectrum2();
        public static readonly SRLightConeEventWarp EpochalSpectrum3 = new EpochalSpectrum3();

        public static readonly SRLightConeEventWarp ForeseenForeknownForetold1 = new ForeseenForeknownForetold1();
        public static readonly SRLightConeEventWarp ForeseenForeknownForetold2 = new ForeseenForeknownForetold2();

        public static readonly SRLightConeEventWarp GentleEclipseOfTheMoon1 = new GentleEclipseOfTheMoon1();
        public static readonly SRLightConeEventWarp GentleEclipseOfTheMoon2 = new GentleEclipseOfTheMoon2();

        public static readonly SRLightConeEventWarp SunsetClause1 = new SunsetClause1();
        public static readonly SRLightConeEventWarp SunsetClause2 = new SunsetClause2();
        public static readonly SRLightConeEventWarp SunsetClause3 = new SunsetClause3();

        public static readonly SRLightConeEventWarp BloomInGloom1 = new BloomInGloom1();
        public static readonly SRLightConeEventWarp BloomInGloom2 = new BloomInGloom2();

        public static readonly SRLightConeEventWarp ThornsOfScentedCrown1 = new ThornsOfScentedCrown1();
        public static readonly SRLightConeEventWarp ThornsOfScentedCrown2 = new ThornsOfScentedCrown2();

        public static readonly SRLightConeEventWarp FloralTriptych1 = new FloralTriptych1();
        public static readonly SRLightConeEventWarp FloralTriptych2 = new FloralTriptych2();

        public static readonly SRLightConeEventWarp PantaRhei1 = new PantaRhei1();

        public static readonly SRLightConeEventWarp RipplesInReflection1 = new RipplesInReflection1();
        public static readonly SRLightConeEventWarp IndelibleCoterieBlackSwan1 = new IndelibleCoterieBlackSwan1();

        public static readonly SRLightConeEventWarp SparklingSplendor1 = new SparklingSplendor1();
        public static readonly SRLightConeEventWarp SparklingSplendor2 = new SparklingSplendor2();

        public static readonly SRLightConeEventWarp WordsOfYore1 = new WordsOfYore1();
        public static readonly SRLightConeEventWarp WordsOfYore2 = new WordsOfYore2();

        public static readonly SRLightConeEventWarp GildedImprisonment1 = new GildedImprisonment1();
        public static readonly SRLightConeEventWarp GildedImprisonment2 = new GildedImprisonment2();

        public static readonly SRLightConeEventWarp JustIntonation1 = new JustIntonation1();
        public static readonly SRLightConeEventWarp IndelibleCoterieRobin1 = new IndelibleCoterieRobin1();

        public static readonly SRLightConeEventWarp DustyTrailsLoneStar1 = new DustyTrailsLoneStar1();

        public static readonly SRLightConeEventWarp FirefullFlyshine1 = new FirefullFlyshine1();
        public static readonly SRLightConeEventWarp FirefullFlyshine2 = new FirefullFlyshine2();

        public static readonly SRLightConeEventWarp LienOnLifeLeaseOnFate1 = new LienOnLifeLeaseOnFate1();

        public static readonly SRLightConeEventWarp EarthHurledEtherCurled1 = new EarthHurledEtherCurled1();

        public static readonly SRLightConeEventWarp CauldronContrivance1 = new CauldronContrivance1();

        public static readonly SRLightConeEventWarp StormridersBolt1 = new StormridersBolt1();

        public static readonly SRLightConeEventWarp LetScentSinkIn1 = new LetScentSinkIn1();

        public static readonly SRLightConeEventWarp EyesOfANinja1 = new EyesOfANinja1();

        public static readonly SRLightConeEventWarp EyesToTheStars1 = new EyesToTheStars1();

        public static readonly SRLightConeEventWarp TheLongVoyageHome1 = new TheLongVoyageHome1();

    }

    public sealed class ButterflyOnSwordtip1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p0;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.InTheNight;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.PostOpConversation;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.GoodNightAndSleepWell;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.TheMolesWelcomeYou;
    }
    public sealed class ButterflyOnSwordtip2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p4;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.InTheNight;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.TheMolesWelcomeYou;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.ResolutionShinesAsPearlsOfSweat;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.OnlySilenceRemains;
    }

    public sealed class SwirlOfHeavenlySpear1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p0;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.BeforeDawn;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.DayOneOfMyNewLife;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.OnlySilenceRemains;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.PlanetaryRendezvous;
    }
    public sealed class SwirlOfHeavenlySpear2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p0;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.BeforeDawn;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.PlanetaryRendezvous;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.GeniusesRepose;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.UnderTheBlueSky;
    }
    public sealed class SwirlOfHeavenlySpear3 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p7;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.BeforeDawn;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.PoisedToBloom;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.TheBirthOfTheSelf;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.Swordplay;
    }


    public sealed class ContractZero1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p1;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.IncessantRain;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.SubscribeForMore;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.MemoriesOfThePast;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.MakeTheWorldClamor;
    }
    public sealed class ContractZero2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p5;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.IncessantRain;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.UnderTheBlueSky;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.PostOpConversation;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.TheBirthOfTheSelf;
    }

    public sealed class LaicPursuit1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p1;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.EchoesOfTheCoffin;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.GoodNightAndSleepWell;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.DanceDanceDance;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.GeniusesRepose;
    }
    public sealed class LaicPursuit2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p1;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.EchoesOfTheCoffin;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.GoodNightAndSleepWell;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.PostOpConversation;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.SubscribeForMore;
    }

    public sealed class ALostSoul1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p2;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.TheUnreachableSide;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.SharedFeeling;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.Swordplay;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.ASecretVow;
    }
    public sealed class ALostSoul2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p6;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.TheUnreachableSide;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.ASecretVow;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.DayOneOfMyNewLife;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.PlanetaryRendezvous;
    }

    public sealed class NessunDorma1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p2;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.PatienceIsAllYouNeed;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.ResolutionShinesAsPearlsOfSweat;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.EyesOfThePrey;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.TheBirthOfTheSelf;
    }
    public sealed class NessunDorma2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p6;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.PatienceIsAllYouNeed;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.PerfectTiming;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.OnlySilenceRemains;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.LandausChoice;
    }
    public sealed class IndelibleCoterieKafka1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p5;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.PatienceIsAllYouNeed;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.Swordplay;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.ResolutionShinesAsPearlsOfSweat;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.TheBirthOfTheSelf;
    }

    public sealed class EpochalSpectrum1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p3;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.BrighterThanTheSun;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.DanceDanceDance;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.PlanetaryRendezvous;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.LandausChoice;
    }
    public sealed class EpochalSpectrum2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p0;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.BrighterThanTheSun;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.IndeliblePromise;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.ResolutionShinesAsPearlsOfSweat;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.DanceDanceDance;
    }
    public sealed class EpochalSpectrum3 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p6;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.BrighterThanTheSun;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.DreamsMontage;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.AfterTheCharmonyFall;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.UnderTheBlueSky;
    }

    public sealed class ForeseenForeknownForetold1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p3;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.SheAlreadyShutHerEyes;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.TrendOfTheUniversalMarket;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.PerfectTiming;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.UnderTheBlueSky;
    }
    public sealed class ForeseenForeknownForetold2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p2;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.SheAlreadyShutHerEyes;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.GeniusesRepose;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.ASecretVow;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.LandausChoice;
    }

    public sealed class GentleEclipseOfTheMoon1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p4;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.IShallBeMyOwnSword;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.MakeTheWorldClamor;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.MemoriesOfThePast;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.EyesOfThePrey;
    }
    public sealed class GentleEclipseOfTheMoon2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p1;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.IShallBeMyOwnSword;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.ConcertForTwo;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.MakeTheWorldClamor;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.SharedFeeling;
    }

    public sealed class SunsetClause1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p4;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.WorrisomeBlissful;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.TheMolesWelcomeYou;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.ResolutionShinesAsPearlsOfSweat;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.OnlySilenceRemains;
    }
    public sealed class SunsetClause2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p2;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.WorrisomeBlissful;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.Swordplay;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.BoundlessChoreo;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.PerfectTiming;
    }
    public sealed class SunsetClause3 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p5;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.WorrisomeBlissful;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.ShadowedByNight;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.SharedFeeling;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.PlanetaryRendezvous;
    }

    public sealed class BloomInGloom1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p5;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.NightOfFright;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.SharedFeeling;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.SubscribeForMore;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.TrendOfTheUniversalMarket;
    }
    public sealed class BloomInGloom2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p4;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.NightOfFright;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.TheMolesWelcomeYou;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.PerfectTiming;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.TheBirthOfTheSelf;
    }

    public sealed class ThornsOfScentedCrown1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p5;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.AnInstantBeforeAGaze;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.UnderTheBlueSky;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.PostOpConversation;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.TheBirthOfTheSelf;
    }
    public sealed class ThornsOfScentedCrown2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p3;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.AnInstantBeforeAGaze;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.SharedFeeling;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.TrendOfTheUniversalMarket;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.AfterTheCharmonyFall;
    }

    public sealed class FloralTriptych1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p6;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.PastSelfInMirror;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.ASecretVow;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.DayOneOfMyNewLife;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.PlanetaryRendezvous;
    }
    public sealed class FloralTriptych2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p3;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.PastSelfInMirror;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.MemoriesOfThePast;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.DayOneOfMyNewLife;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.EyesOfThePrey;
    }

    public sealed class PantaRhei1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p6;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.BaptismOfPureThought;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.PerfectTiming;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.OnlySilenceRemains;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.LandausChoice;
    }

    public sealed class RipplesInReflection1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p0;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.ReforgedRemembrance;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.IndeliblePromise;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.ResolutionShinesAsPearlsOfSweat;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.DanceDanceDance;
    }
    public sealed class IndelibleCoterieBlackSwan1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p5;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.ReforgedRemembrance;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.Swordplay;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.ResolutionShinesAsPearlsOfSweat;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.TheBirthOfTheSelf;
    }

    public sealed class SparklingSplendor1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p0;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.EarthlyEscapade;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.PlanetaryRendezvous;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.GeniusesRepose;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.UnderTheBlueSky;
    }
    public sealed class SparklingSplendor2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p4;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.EarthlyEscapade;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.PoisedToBloom;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.EyesOfThePrey;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.ASecretVow;
    }

    public sealed class WordsOfYore1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p1;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.AlongThePassingShore;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.GoodNightAndSleepWell;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.PostOpConversation;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.SubscribeForMore;
    }
    public sealed class WordsOfYore2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p6;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.AlongThePassingShore;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.BoundlessChoreo;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.DayOneOfMyNewLife;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.MakeTheWorldClamor;
    }

    public sealed class GildedImprisonment1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p1;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.InherentlyUnjustDestiny;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.ConcertForTwo;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.MakeTheWorldClamor;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.SharedFeeling;
    }
    public sealed class GildedImprisonment2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p6;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.InherentlyUnjustDestiny;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.BoundlessChoreo;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.DayOneOfMyNewLife;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.MakeTheWorldClamor;
    }

    public sealed class JustIntonation1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p2;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.FlowingNightglow;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.Swordplay;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.BoundlessChoreo;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.PerfectTiming;
    }
    public sealed class IndelibleCoterieRobin1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p5;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.FlowingNightglow;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.Swordplay;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.ResolutionShinesAsPearlsOfSweat;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.TheBirthOfTheSelf;
    }

    public sealed class DustyTrailsLoneStar1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p2;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.SailingTowardsASecondLife;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.GeniusesRepose;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.ASecretVow;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.LandausChoice;
    }

    public sealed class FirefullFlyshine1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p3;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.WhereaboutsShouldDreamsRest;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.MemoriesOfThePast;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.DayOneOfMyNewLife;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.EyesOfThePrey;
    }
    public sealed class FirefullFlyshine2 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p7;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.WhereaboutsShouldDreamsRest;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.IndeliblePromise;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.ResolutionShinesAsPearlsOfSweat;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.ConcertForTwo;
    }

    public sealed class LienOnLifeLeaseOnFate1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p3;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.YetHopeIsPriceless;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.SharedFeeling;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.TrendOfTheUniversalMarket;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.AfterTheCharmonyFall;
    }

    public sealed class EarthHurledEtherCurled1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p4;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.DanceAtSunset;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.TheMolesWelcomeYou;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.PerfectTiming;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.TheBirthOfTheSelf;
    }

    public sealed class CauldronContrivance1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p4;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.ThoseManySprings;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.PoisedToBloom;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.EyesOfThePrey;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.ASecretVow;
    }

    public sealed class StormridersBolt1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p5;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.IVentureForthToHunt;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.Swordplay;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.ResolutionShinesAsPearlsOfSweat;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.TheBirthOfTheSelf;
    }

    public sealed class LetScentSinkIn1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p5;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.ScentAloneStaysTrue;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.ShadowedByNight;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.SharedFeeling;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.PlanetaryRendezvous;
    }

    public sealed class EyesOfANinja1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p6;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.NinjutsuInscriptionDazzlingEvilbreaker;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.DreamsMontage;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.AfterTheCharmonyFall;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.UnderTheBlueSky;
    }

    public sealed class EyesToTheStars1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p7;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.AGroundedAscent;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.PoisedToBloom;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.TheBirthOfTheSelf;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.Swordplay;
    }

    public sealed class TheLongVoyageHome1 : SRLightConeEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p7;

        public override SRStar5LightCone UpStar5LightCone => SRLightCones.LongRoadLeadsHome;
        public override SRStar4LightCone UpStar4LightCone1 => SRLightCones.IndeliblePromise;
        public override SRStar4LightCone UpStar4LightCone2 => SRLightCones.ResolutionShinesAsPearlsOfSweat;
        public override SRStar4LightCone UpStar4LightCone3 => SRLightCones.ConcertForTwo;
    }
}
