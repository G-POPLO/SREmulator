using SREmulator.SRItems;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace SREmulator.SRWarps.CharacterEventWarps
{
    public static class SRCharacterEventWarps
    {
        public static readonly SRCharacterEventWarp ButterflyOnSwordtip1 = new ButterflyOnSwordtip1();
        public static readonly SRCharacterEventWarp ButterflyOnSwordtip2 = new ButterflyOnSwordtip2();

        public static readonly SRCharacterEventWarp SwirlOfHeavenlySpear1 = new SwirlOfHeavenlySpear1();
        public static readonly SRCharacterEventWarp SwirlOfHeavenlySpear2 = new SwirlOfHeavenlySpear2();

        public static readonly SRCharacterEventWarp ContractZero1 = new ContractZero1();
        public static readonly SRCharacterEventWarp ContractZero2 = new ContractZero2();

        public static readonly SRCharacterEventWarp LaicPursuit1 = new LaicPursuit1();
        public static readonly SRCharacterEventWarp LaicPursuit2 = new LaicPursuit2();

        public static readonly SRCharacterEventWarp ALostSoul1 = new ALostSoul1();
        public static readonly SRCharacterEventWarp ALostSoul2 = new ALostSoul2();

        public static readonly SRCharacterEventWarp NessunDorma1 = new NessunDorma1();
        public static readonly SRCharacterEventWarp NessunDorma2 = new NessunDorma2();
        public static readonly SRCharacterEventWarp IndelibleCoterieKafka1 = new IndelibleCoterieKafka1();

        public static readonly SRCharacterEventWarp EpochalSpectrum1 = new EpochalSpectrum1();
        public static readonly SRCharacterEventWarp EpochalSpectrum2 = new EpochalSpectrum2();
        public static readonly SRCharacterEventWarp EpochalSpectrum3 = new EpochalSpectrum3();

        public static readonly SRCharacterEventWarp ForeseenForeknownForetold1 = new ForeseenForeknownForetold1();
        public static readonly SRCharacterEventWarp ForeseenForeknownForetold2 = new ForeseenForeknownForetold2();

        public static readonly SRCharacterEventWarp GentleEclipseOfTheMoon1 = new GentleEclipseOfTheMoon1();
        public static readonly SRCharacterEventWarp GentleEclipseOfTheMoon2 = new GentleEclipseOfTheMoon2();

        public static readonly SRCharacterEventWarp SunsetClause1 = new SunsetClause1();
        public static readonly SRCharacterEventWarp SunsetClause2 = new SunsetClause2();
        public static readonly SRCharacterEventWarp SunsetClause3 = new SunsetClause3();

        public static readonly SRCharacterEventWarp BloomInGloom1 = new BloomInGloom1();
        public static readonly SRCharacterEventWarp BloomInGloom2 = new BloomInGloom2();

        public static readonly SRCharacterEventWarp ThornsOfScentedCrown1 = new ThornsOfScentedCrown1();
        public static readonly SRCharacterEventWarp ThornsOfScentedCrown2 = new ThornsOfScentedCrown2();

        public static readonly SRCharacterEventWarp FloralTriptych1 = new FloralTriptych1();
        public static readonly SRCharacterEventWarp FloralTriptych2 = new FloralTriptych2();

        public static readonly SRCharacterEventWarp PantaRhei1 = new PantaRhei1();

        public static readonly SRCharacterEventWarp RipplesInReflection1 = new RipplesInReflection1();
        public static readonly SRCharacterEventWarp IndelibleCoterieBlackSwan1 = new IndelibleCoterieBlackSwan1();

        public static readonly SRCharacterEventWarp SparklingSplendor1 = new SparklingSplendor1();
        public static readonly SRCharacterEventWarp SparklingSplendor2 = new SparklingSplendor2();

        public static readonly SRCharacterEventWarp WordsOfYore1 = new WordsOfYore1();
        public static readonly SRCharacterEventWarp WordsOfYore2 = new WordsOfYore2();

        public static readonly SRCharacterEventWarp GildedImprisonment1 = new GildedImprisonment1();
        public static readonly SRCharacterEventWarp GildedImprisonment2 = new GildedImprisonment2();

        public static readonly SRCharacterEventWarp JustIntonation1 = new JustIntonation1();
        public static readonly SRCharacterEventWarp IndelibleCoterieRobin1 = new IndelibleCoterieRobin1();

        public static readonly SRCharacterEventWarp DustyTrailsLoneStar1 = new DustyTrailsLoneStar1();

        public static readonly SRCharacterEventWarp FirefullFlyshine1 = new FirefullFlyshine1();

        public static readonly SRCharacterEventWarp LienOnLifeLeaseOnFate1 = new LienOnLifeLeaseOnFate1();

        public static readonly SRCharacterEventWarp EarthHurledEtherCurled1 = new EarthHurledEtherCurled1();

        public static readonly SRCharacterEventWarp CauldronContrivance1 = new CauldronContrivance1();

        public static readonly SRCharacterEventWarp StormridersBolt1 = new StormridersBolt1();

        public static readonly SRCharacterEventWarp LetScentSinkIn1 = new LetScentSinkIn1();

        public static readonly SRCharacterEventWarp EyesOfANinja1 = new EyesOfANinja1();
    }

    public sealed class ButterflyOnSwordtip1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p0;

        public override SRStar5Character UpStar5Character => SRCharacters.Seele;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Natasha;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Hook;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Pela;
    }
    public sealed class ButterflyOnSwordtip2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p4;

        public override SRStar5Character UpStar5Character => SRCharacters.Seele;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Guinaifen;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Luka;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Sushang;
    }

    public sealed class SwirlOfHeavenlySpear1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p0;

        public override SRStar5Character UpStar5Character => SRCharacters.JingYuan;
        public override SRStar4Character UpStar4Character1 => SRCharacters.March7th;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Tingyun;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Sushang;
    }
    public sealed class SwirlOfHeavenlySpear2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p0;

        public override SRStar5Character UpStar5Character => SRCharacters.JingYuan;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Sampo;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Hanya;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Qingque;
    }

    public sealed class ContractZero1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p1;

        public override SRStar5Character UpStar5Character => SRCharacters.SilverWolf;
        public override SRStar4Character UpStar4Character1 => SRCharacters.DanHeng;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Asta;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Serval;
    }
    public sealed class ContractZero2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p5;

        public override SRStar5Character UpStar5Character => SRCharacters.SilverWolf;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Asta;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Lynx;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Hanya;
    }

    public sealed class LaicPursuit1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p1;

        public override SRStar5Character UpStar5Character => SRCharacters.Luocha;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Pela;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Qingque;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Yukong;
    }
    public sealed class LaicPursuit2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p1;

        public override SRStar5Character UpStar5Character => SRCharacters.Luocha;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Gallagher;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Pela;
        public override SRStar4Character UpStar4Character3 => SRCharacters.DanHeng;
    }

    public sealed class ALostSoul1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p2;

        public override SRStar5Character UpStar5Character => SRCharacters.Blade;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Arlan;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Sushang;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Natasha;
    }
    public sealed class ALostSoul2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p6;

        public override SRStar5Character UpStar5Character => SRCharacters.Blade;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Xueyi;
        public override SRStar4Character UpStar4Character2 => SRCharacters.March7th;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Tingyun;
    }

    public sealed class NessunDorma1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p2;

        public override SRStar5Character UpStar5Character => SRCharacters.Kafka;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Luka;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Sampo;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Serval;
    }
    public sealed class NessunDorma2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p6;

        public override SRStar5Character UpStar5Character => SRCharacters.Kafka;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Sushang;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Natasha;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Hook;
    }
    public sealed class IndelibleCoterieKafka1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p5;

        public override SRStar5Character UpStar5Character => SRCharacters.Kafka;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Moze;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Asta;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Luka;
    }

    public sealed class EpochalSpectrum1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p3;

        public override SRStar5Character UpStar5Character => SRCharacters.DanHengImbibitorLunae;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Yukong;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Asta;
        public override SRStar4Character UpStar4Character3 => SRCharacters.March7th;
    }
    public sealed class EpochalSpectrum2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p0;

        public override SRStar5Character UpStar5Character => SRCharacters.DanHengImbibitorLunae;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Misha;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Guinaifen;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Tingyun;
    }
    public sealed class EpochalSpectrum3 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p6;

        public override SRStar5Character UpStar5Character => SRCharacters.DanHengImbibitorLunae;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Yukong;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Lynx;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Xueyi;
    }

    public sealed class ForeseenForeknownForetold1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p3;

        public override SRStar5Character UpStar5Character => SRCharacters.FuXuan;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Lynx;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Hook;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Pela;
    }
    public sealed class ForeseenForeknownForetold2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p2;

        public override SRStar5Character UpStar5Character => SRCharacters.FuXuan;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Pela;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Luka;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Hook;
    }

    public sealed class GentleEclipseOfTheMoon1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p4;

        public override SRStar5Character UpStar5Character => SRCharacters.Jingliu;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Tingyun;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Sampo;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Qingque;
    }
    public sealed class GentleEclipseOfTheMoon2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p1;

        public override SRStar5Character UpStar5Character => SRCharacters.Jingliu;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Serval;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Luka;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Lynx;
    }

    public sealed class SunsetClause1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p4;

        public override SRStar5Character UpStar5Character => SRCharacters.TopazNumby;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Guinaifen;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Luka;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Sushang;
    }
    public sealed class SunsetClause2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p2;

        public override SRStar5Character UpStar5Character => SRCharacters.TopazNumby;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Xueyi;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Hanya;
        public override SRStar4Character UpStar4Character3 => SRCharacters.March7th;
    }
    public sealed class SunsetClause3 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p5;

        public override SRStar5Character UpStar5Character => SRCharacters.TopazNumby;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Natasha;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Guinaifen;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Misha;
    }

    public sealed class BloomInGloom1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p5;

        public override SRStar5Character UpStar5Character => SRCharacters.Huohuo;
        public override SRStar4Character UpStar4Character1 => SRCharacters.DanHeng;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Arlan;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Serval;
    }
    public sealed class BloomInGloom2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p4;

        public override SRStar5Character UpStar5Character => SRCharacters.Huohuo;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Hanya;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Yukong;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Lynx;
    }

    public sealed class ThornsOfScentedCrown1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p5;

        public override SRStar5Character UpStar5Character => SRCharacters.Argenti;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Asta;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Lynx;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Hanya;
    }
    public sealed class ThornsOfScentedCrown2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p3;

        public override SRStar5Character UpStar5Character => SRCharacters.Argenti;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Serval;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Natasha;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Asta;
    }

    public sealed class FloralTriptych1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p6;

        public override SRStar5Character UpStar5Character => SRCharacters.RuanMei;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Xueyi;
        public override SRStar4Character UpStar4Character2 => SRCharacters.March7th;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Tingyun;
    }
    public sealed class FloralTriptych2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p3;

        public override SRStar5Character UpStar5Character => SRCharacters.RuanMei;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Xueyi;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Misha;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Gallagher;
    }

    public sealed class PantaRhei1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver1p6;

        public override SRStar5Character UpStar5Character => SRCharacters.DrRatio;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Sushang;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Natasha;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Hook;
    }

    public sealed class RipplesInReflection1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p0;

        public override SRStar5Character UpStar5Character => SRCharacters.BlackSwan;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Misha;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Guinaifen;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Tingyun;
    }
    public sealed class IndelibleCoterieBlackSwan1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p5;

        public override SRStar5Character UpStar5Character => SRCharacters.BlackSwan;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Moze;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Asta;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Luka;
    }

    public sealed class SparklingSplendor1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p0;

        public override SRStar5Character UpStar5Character => SRCharacters.Sparkle;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Sampo;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Hanya;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Qingque;
    }
    public sealed class SparklingSplendor2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p4;

        public override SRStar5Character UpStar5Character => SRCharacters.Sparkle;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Hook;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Guinaifen;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Arlan;
    }

    public sealed class WordsOfYore1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p1;

        public override SRStar5Character UpStar5Character => SRCharacters.Acheron;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Gallagher;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Pela;
        public override SRStar4Character UpStar4Character3 => SRCharacters.DanHeng;
    }
    public sealed class WordsOfYore2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p6;

        public override SRStar5Character UpStar5Character => SRCharacters.Acheron;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Sampo;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Pela;
        public override SRStar4Character UpStar4Character3 => SRCharacters.March7th;
    }

    public sealed class GildedImprisonment1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p1;

        public override SRStar5Character UpStar5Character => SRCharacters.Aventurine;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Serval;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Luka;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Lynx;
    }
    public sealed class GildedImprisonment2 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p6;

        public override SRStar5Character UpStar5Character => SRCharacters.Aventurine;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Sampo;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Pela;
        public override SRStar4Character UpStar4Character3 => SRCharacters.March7th;
    }

    public sealed class JustIntonation1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p2;

        public override SRStar5Character UpStar5Character => SRCharacters.Robin;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Xueyi;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Hanya;
        public override SRStar4Character UpStar4Character3 => SRCharacters.March7th;
    }
    public sealed class IndelibleCoterieRobin1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p5;

        public override SRStar5Character UpStar5Character => SRCharacters.Robin;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Moze;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Asta;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Luka;
    }
    
    public sealed class DustyTrailsLoneStar1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p2;

        public override SRStar5Character UpStar5Character => SRCharacters.Boothill;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Pela;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Luka;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Hook;
    }

    public sealed class FirefullFlyshine1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p3;

        public override SRStar5Character UpStar5Character => SRCharacters.Firefly;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Xueyi;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Misha;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Gallagher;
    }

    public sealed class LienOnLifeLeaseOnFate1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p3;

        public override SRStar5Character UpStar5Character => SRCharacters.Jade;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Serval;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Natasha;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Asta;
    }

    public sealed class EarthHurledEtherCurled1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p4;

        public override SRStar5Character UpStar5Character => SRCharacters.Yunli;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Hanya;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Yukong;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Lynx;
    }

    public sealed class CauldronContrivance1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p4;

        public override SRStar5Character UpStar5Character => SRCharacters.Jiaoqiu;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Hook;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Guinaifen;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Arlan;
    }

    public sealed class StormridersBolt1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p5;

        public override SRStar5Character UpStar5Character => SRCharacters.Feixiao;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Moze;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Asta;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Luka;
    }

    public sealed class LetScentSinkIn1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p5;

        public override SRStar5Character UpStar5Character => SRCharacters.Lingsha;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Natasha;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Guinaifen;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Misha;
    }

    public sealed class EyesOfANinja1 : SRCharacterEventWarp
    {
        public override SRVersion Version => SRVersion.Ver2p6;

        public override SRStar5Character UpStar5Character => SRCharacters.Rappa;
        public override SRStar4Character UpStar4Character1 => SRCharacters.Yukong;
        public override SRStar4Character UpStar4Character2 => SRCharacters.Lynx;
        public override SRStar4Character UpStar4Character3 => SRCharacters.Xueyi;
    }
}
