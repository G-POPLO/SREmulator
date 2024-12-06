namespace SREmulator
{
    // +------------+------------+---------------------+---+
    // | 1  1  1  1 | 1  1  1  1 | 0  0  0  0  0  0  0 | 1 |
    // +------------+------------+---------------------+---+
    //     Major        Minor           Reserved      Specified
    [Flags]
    public enum SRVersion : ushort
    {
        Unspecified = 0x0000,
        Specified = 0x0001,

        MajorMask = 0xF000,
        MinorMask = 0x0F00,
        VersionForWarps = MajorMask | MinorMask | Specified,

        Major1 = 0x1000 | Specified,
        Major2 = 0x2000 | Specified,
        Major3 = 0x3000 | Specified,

        Minor0 = 0x0000 | Specified,
        Minor1 = 0x0100 | Specified,
        Minor2 = 0x0200 | Specified,
        Minor3 = 0x0300 | Specified,
        Minor4 = 0x0400 | Specified,
        Minor5 = 0x0500 | Specified,
        Minor6 = 0x0600 | Specified,
        Minor7 = 0x0700 | Specified,

        Phase1 = 0x0010 | Specified,
        Phase2 = 0x0020 | Specified,

        Ver1p0 = Major1 | Minor0,
        Ver1p1 = Major1 | Minor1,
        Ver1p2 = Major1 | Minor2,
        Ver1p3 = Major1 | Minor3,
        Ver1p4 = Major1 | Minor4,
        Ver1p5 = Major1 | Minor5,
        Ver1p6 = Major1 | Minor6,

        Ver2p0 = Major2 | Minor0,
        Ver2p1 = Major2 | Minor1,
        Ver2p2 = Major2 | Minor2,
        Ver2p3 = Major2 | Minor3,
        Ver2p4 = Major2 | Minor4,
        Ver2p5 = Major2 | Minor5,
        Ver2p6 = Major2 | Minor6,
        Ver2p7 = Major2 | Minor7,

        Ver3p0 = Major3 | Minor0,
    }
}
