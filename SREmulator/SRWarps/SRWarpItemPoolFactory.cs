using SREmulator.SRItems;

namespace SREmulator.SRWarps
{
    public static class SRWarpItemPoolFactory
    {
        internal static int VersionToStar4CharacterCount(SRVersion version)
        {
            // 1.1及之后版本新增的4星角色在当时版本只会以Up形式出现
            // 在后一个版本开始才会加入池中
            // 例：雪衣在1.6上半Up，在下半抽不到，在2.0及以后才可被歪出来
            // 光锥同理
            return (version & SRVersion.VersionForWarps) switch
            {
                SRVersion.Ver1p0 => 13,
                SRVersion.Ver1p1 => 13,
                SRVersion.Ver1p2 => 14,
                SRVersion.Ver1p3 => 15,
                SRVersion.Ver1p4 => 16,
                SRVersion.Ver1p5 => 17,
                SRVersion.Ver1p6 => 18,
                SRVersion.Ver2p0 => 19,
                SRVersion.Ver2p1 => 20,
                SRVersion.Ver2p2 or
                SRVersion.Ver2p3 or
                SRVersion.Ver2p4 or
                SRVersion.Ver2p5 => 21,
                SRVersion.Ver2p6 or
                SRVersion.Ver2p7 => 22,

                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }
        internal static readonly SRStar4Character[] Star4CharactersOrderedByVersion = [
            // 1.0 1
            SRCharacters.Arlan,
            SRCharacters.Asta,
            SRCharacters.DanHeng,
            SRCharacters.Herta,
            SRCharacters.Hook,
            SRCharacters.March7th,
            SRCharacters.Natasha,
            SRCharacters.Pela,
            SRCharacters.Qingque,
            SRCharacters.Sampo,
            SRCharacters.Serval,
            SRCharacters.Sushang,
            SRCharacters.Tingyun,

            // 1.1 2
            SRCharacters.Yukong,

            // 1.2 2
            SRCharacters.Luka,

            // 1.3 2
            SRCharacters.Lynx,

            // 1.4 2
            SRCharacters.Guinaifen,

            // 1.5 2
            SRCharacters.Hanya,

            // 1.6 1
            SRCharacters.Xueyi,

            // 2.0 1
            SRCharacters.Misha,

            // 2.1 1
            SRCharacters.Gallagher, 
            
            // 2.5 1
            SRCharacters.Moze,
            ];
        public static SRStar4Character[] CreateStar4Characters(SRVersion version)
        {
            return Star4CharactersOrderedByVersion.Take(VersionToStar4CharacterCount(version)).ToArray();
        }

        internal static int VersionToStar4LightConeCount(SRVersion version)
        {
            return (version & SRVersion.VersionForWarps) switch
            {
                SRVersion.Ver1p0 or
                SRVersion.Ver1p1 or
                SRVersion.Ver1p2 or
                SRVersion.Ver1p3 or
                SRVersion.Ver1p4 or
                SRVersion.Ver1p5 or
                SRVersion.Ver1p6 or
                SRVersion.Ver2p0 => 21,
                SRVersion.Ver2p1 => 22,
                SRVersion.Ver2p2 => 23,
                SRVersion.Ver2p3 => 24,
                SRVersion.Ver2p4 => 25,
                SRVersion.Ver2p5 => 26,
                SRVersion.Ver2p6 => 27,
                SRVersion.Ver2p7 => 28,

                _ => throw new ArgumentOutOfRangeException(nameof(version)),
            };
        }
        internal static readonly SRStar4LightCone[] Star4LightConesOrderedByVersion = [
            // 1.0
            SRLightCones.DayOneOfMyNewLife,
            SRLightCones.MakeTheWorldClamor,
            SRLightCones.Swordplay,
            SRLightCones.MemoriesOfThePast,
            SRLightCones.OnlySilenceRemains,
            SRLightCones.TheMolesWelcomeYou,
            SRLightCones.PostOpConversation,
            SRLightCones.ASecretVow,
            SRLightCones.DanceDanceDance,
            SRLightCones.ConcertForTwo,
            SRLightCones.SharedFeeling,
            SRLightCones.EyesOfThePrey,
            SRLightCones.TrendOfTheUniversalMarket,
            SRLightCones.TheBirthOfTheSelf,
            SRLightCones.LandausChoice,
            SRLightCones.PerfectTiming,
            SRLightCones.UnderTheBlueSky,
            SRLightCones.GoodNightAndSleepWell,
            SRLightCones.PlanetaryRendezvous,
            SRLightCones.SubscribeForMore,
            SRLightCones.PoisedToBloom,

            // 2.0
            SRLightCones.IndeliblePromise,
            
            // 2.1
            SRLightCones.ResolutionShinesAsPearlsOfSweat,
            
            // 2.2
            SRLightCones.BoundlessChoreo,

            // 2.3
            SRLightCones.AfterTheCharmonyFall,

            // 2.4
            SRLightCones.GeniusesRepose,

            // 2.5
            SRLightCones.ShadowedByNight,

            // 2.6
            SRLightCones.DreamsMontage
            ];
        public static SRStar4LightCone[] CreateStar4LightCones(SRVersion version)
        {
            return Star4LightConesOrderedByVersion.Take(VersionToStar4LightConeCount(version)).ToArray();
        }
    }
}
