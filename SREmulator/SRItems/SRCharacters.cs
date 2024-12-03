using SREmulator.Localizations;

namespace SREmulator.SRItems
{
    public static partial class SRCharacters
    {
        public static readonly SRNonLimitedStar5Character[] AllNonLimitedStar5Characters = [Bailu, Bronya, Clara, Gepard, Himeko, Welt, Yanqing];
        public static SRNonLimitedStar5Character Bailu => new Bailu();
        public static SRNonLimitedStar5Character Bronya => new Bronya();
        public static SRNonLimitedStar5Character Clara => new Clara();
        public static SRNonLimitedStar5Character Gepard => new Gepard();
        public static SRNonLimitedStar5Character Himeko => new Himeko();
        public static SRNonLimitedStar5Character Welt => new Welt();
        public static SRNonLimitedStar5Character Yanqing => new Yanqing();

        public static SRLimitedStar5Character Acheron => new Acheron();
        public static SRLimitedStar5Character Argenti => new Argenti();
        public static SRLimitedStar5Character Aventurine => new Aventurine();
        public static SRLimitedStar5Character BlackSwan => new BlackSwan();
        public static SRLimitedStar5Character Blade => new Blade();
        public static SRLimitedStar5Character Boothill => new Boothill();
        public static SRLimitedStar5Character DanHengImbibitorLunae => new DanHengImbibitorLunae();
        public static SRLimitedStar5Character DrRatio => new DrRatio();
        public static SRLimitedStar5Character Feixiao => new Feixiao();
        public static SRLimitedStar5Character Firefly => new Firefly();
        public static SRLimitedStar5Character FuXuan => new FuXuan();
        public static SRLimitedStar5Character Huohuo => new Huohuo();
        public static SRLimitedStar5Character Jade => new Jade();
        public static SRLimitedStar5Character Jiaoqiu => new Jiaoqiu();
        public static SRLimitedStar5Character JingYuan => new JingYuan();
        public static SRLimitedStar5Character Jingliu => new Jingliu();
        public static SRLimitedStar5Character Kafka => new Kafka();
        public static SRLimitedStar5Character Lingsha => new Lingsha();
        public static SRLimitedStar5Character Luocha => new Luocha();
        public static SRLimitedStar5Character Rappa => new Rappa();
        public static SRLimitedStar5Character Robin => new Robin();
        public static SRLimitedStar5Character RuanMei => new RuanMei();
        public static SRLimitedStar5Character Seele => new Seele();
        public static SRLimitedStar5Character SilverWolf => new SilverWolf();
        public static SRLimitedStar5Character Sparkle => new Sparkle();
        public static SRLimitedStar5Character TopazNumby => new TopazNumby();
        public static SRLimitedStar5Character Yunli => new Yunli();
        public static SRLimitedStar5Character Sunday => new Sunday();
        public static SRLimitedStar5Character Fugue => new Fugue();

        public static SRStar4Character Arlan => new Arlan();
        public static SRStar4Character Asta => new Asta();
        public static SRStar4Character DanHeng => new DanHeng();
        public static SRStar4Character Gallagher => new Gallagher();
        public static SRStar4Character Guinaifen => new Guinaifen();
        public static SRStar4Character Hanya => new Hanya();
        public static SRStar4Character Herta => new Herta();
        public static SRStar4Character Hook => new Hook();
        public static SRStar4Character Luka => new Luka();
        public static SRStar4Character Lynx => new Lynx();
        public static SRStar4Character March7th => new March7th();
        public static SRStar4Character Misha => new Misha();
        public static SRStar4Character Moze => new Moze();
        public static SRStar4Character Natasha => new Natasha();
        public static SRStar4Character Pela => new Pela();
        public static SRStar4Character Qingque => new Qingque();
        public static SRStar4Character Sampo => new Sampo();
        public static SRStar4Character Serval => new Serval();
        public static SRStar4Character Sushang => new Sushang();
        public static SRStar4Character Tingyun => new Tingyun();
        public static SRStar4Character Xueyi => new Xueyi();
        public static SRStar4Character Yukong => new Yukong();
    }

    #region Star 5 Non Limited

    public sealed record class Bailu : SRNonLimitedStar5Character
    {
        public override string Name => Localization.Bailu;
    }

    public sealed record class Bronya : SRNonLimitedStar5Character
    {
        public override string Name => Localization.Bronya;
    }

    public sealed record class Clara : SRNonLimitedStar5Character
    {
        public override string Name => Localization.Clara;
    }

    public sealed record class Gepard : SRNonLimitedStar5Character
    {
        public override string Name => Localization.Gepard;
    }

    public sealed record class Himeko : SRNonLimitedStar5Character
    {
        public override string Name => Localization.Himeko;
    }

    public sealed record class Welt : SRNonLimitedStar5Character
    {
        public override string Name => Localization.Welt;
    }

    public sealed record class Yanqing : SRNonLimitedStar5Character
    {
        public override string Name => Localization.Yanqing;
    }

    #endregion

    #region Star 5 Limited

    public sealed record class Acheron : SRLimitedStar5Character
    {
        public override string Name => Localization.Acheron;
    }

    public sealed record class Argenti : SRLimitedStar5Character
    {
        public override string Name => Localization.Argenti;
    }

    public sealed record class Aventurine : SRLimitedStar5Character
    {
        public override string Name => Localization.Aventurine;
    }

    public sealed record class BlackSwan : SRLimitedStar5Character
    {
        public override string Name => Localization.BlackSwan;
    }

    public sealed record class Blade : SRLimitedStar5Character
    {
        public override string Name => Localization.Blade;
    }

    public sealed record class Boothill : SRLimitedStar5Character
    {
        public override string Name => Localization.Boothill;
    }

    public sealed record class DanHengImbibitorLunae : SRLimitedStar5Character
    {
        public override string Name => Localization.DanHengImbibitorLunae;
    }

    public sealed record class DrRatio : SRLimitedStar5Character
    {
        public override string Name => Localization.DrRatio;
    }

    public sealed record class Feixiao : SRLimitedStar5Character
    {
        public override string Name => Localization.Feixiao;
    }

    public sealed record class Firefly : SRLimitedStar5Character
    {
        public override string Name => Localization.Firefly;
    }

    public sealed record class FuXuan : SRLimitedStar5Character
    {
        public override string Name => Localization.FuXuan;
    }

    public sealed record class Huohuo : SRLimitedStar5Character
    {
        public override string Name => Localization.Huohuo;
    }

    public sealed record class Jade : SRLimitedStar5Character
    {
        public override string Name => Localization.Jade;
    }

    public sealed record class Jiaoqiu : SRLimitedStar5Character
    {
        public override string Name => Localization.Jiaoqiu;
    }

    public sealed record class JingYuan : SRLimitedStar5Character
    {
        public override string Name => Localization.JingYuan;
    }

    public sealed record class Jingliu : SRLimitedStar5Character
    {
        public override string Name => Localization.Jingliu;
    }

    public sealed record class Kafka : SRLimitedStar5Character
    {
        public override string Name => Localization.Kafka;
    }

    public sealed record class Lingsha : SRLimitedStar5Character
    {
        public override string Name => Localization.Lingsha;
    }

    public sealed record class Luocha : SRLimitedStar5Character
    {
        public override string Name => Localization.Luocha;
    }

    public sealed record class Rappa : SRLimitedStar5Character
    {
        public override string Name => Localization.Rappa;
    }

    public sealed record class Robin : SRLimitedStar5Character
    {
        public override string Name => Localization.Robin;
    }

    public sealed record class RuanMei : SRLimitedStar5Character
    {
        public override string Name => Localization.RuanMei;
    }

    public sealed record class Seele : SRLimitedStar5Character
    {
        public override string Name => Localization.Seele;
    }

    public sealed record class SilverWolf : SRLimitedStar5Character
    {
        public override string Name => Localization.SilverWolf;
    }

    public sealed record class Sparkle : SRLimitedStar5Character
    {
        public override string Name => Localization.Sparkle;
    }

    public sealed record class TopazNumby : SRLimitedStar5Character
    {
        public override string Name => Localization.TopazNumby;
    }

    public sealed record class Yunli : SRLimitedStar5Character
    {
        public override string Name => Localization.Yunli;
    }

    public sealed record class Sunday : SRLimitedStar5Character
    {
        public override string Name => Localization.Sunday;
    }

    public sealed record class Fugue : SRLimitedStar5Character
    {
        public override string Name => Localization.Fugue;
    }

    #endregion

    #region Star 4

    public sealed record class Arlan : SRStar4Character
    {
        public override string Name => Localization.Arlan;
    }

    public sealed record class Asta : SRStar4Character
    {
        public override string Name => Localization.Asta;
    }

    public sealed record class DanHeng : SRStar4Character
    {
        public override string Name => Localization.DanHeng;
    }

    public sealed record class Gallagher : SRStar4Character
    {
        public override string Name => Localization.Gallagher;
    }

    public sealed record class Guinaifen : SRStar4Character
    {
        public override string Name => Localization.Guinaifen;
    }

    public sealed record class Hanya : SRStar4Character
    {
        public override string Name => Localization.Hanya;
    }

    public sealed record class Herta : SRStar4Character
    {
        public override string Name => Localization.Herta;
    }

    public sealed record class Hook : SRStar4Character
    {
        public override string Name => Localization.Hook;
    }

    public sealed record class Luka : SRStar4Character
    {
        public override string Name => Localization.Luka;
    }

    public sealed record class Lynx : SRStar4Character
    {
        public override string Name => Localization.Lynx;
    }

    public sealed record class March7th : SRStar4Character
    {
        public override string Name => Localization.March7th;
    }

    public sealed record class Misha : SRStar4Character
    {
        public override string Name => Localization.Misha;
    }

    public sealed record class Moze : SRStar4Character
    {
        public override string Name => Localization.Moze;
    }

    public sealed record class Natasha : SRStar4Character
    {
        public override string Name => Localization.Natasha;
    }

    public sealed record class Pela : SRStar4Character
    {
        public override string Name => Localization.Pela;
    }

    public sealed record class Qingque : SRStar4Character
    {
        public override string Name => Localization.Qingque;
    }

    public sealed record class Sampo : SRStar4Character
    {
        public override string Name => Localization.Sampo;
    }

    public sealed record class Serval : SRStar4Character
    {
        public override string Name => Localization.Serval;
    }

    public sealed record class Sushang : SRStar4Character
    {
        public override string Name => Localization.Sushang;
    }

    public sealed record class Tingyun : SRStar4Character
    {
        public override string Name => Localization.Tingyun;
    }

    public sealed record class Xueyi : SRStar4Character
    {
        public override string Name => Localization.Xueyi;
    }

    public sealed record class Yukong : SRStar4Character
    {
        public override string Name => Localization.Yukong;
    }

    #endregion
}
