namespace SREmulator.SRPlayers
{
    internal static class SRPlayerDatabase
    {
        private static int _uid = 100000000;

        //private static readonly SRPlayerDatabaseTable<int, int> _starRailPass = new();          // 星轨通票
        //private static readonly SRPlayerDatabaseTable<int, int> _starRailSpecialPass = new();   // 星轨专票
        //private static readonly SRPlayerDatabaseTable<int, int> _stellarJade = new();           // 星琼
        //private static readonly SRPlayerDatabaseTable<int, int> _oneiricShard = new();          // 古老梦华
        //private static readonly SRPlayerDatabaseTable<int, int> _undyingEmbers = new();         // 未熄的余烬
        //private static readonly SRPlayerDatabaseTable<int, int> _undyingStarlight = new();      // 未熄的星芒

        //private static readonly SRPlayerDatabaseTable<int, SRPlayerDatabaseTable<SRCharacter, int>> _characters = new(static () => new());

        ////private static readonly SRPlayerDatabaseTable<(int, SRWarpType), bool> _guarantee5 = new();
        ////private static readonly SRPlayerDatabaseTable<(int, SRWarpType), bool> _guarantee4 = new();
        ////private static readonly SRPlayerDatabaseTable<(int, SRWarpType), int> _counter5 = new();
        ////private static readonly SRPlayerDatabaseTable<(int, SRWarpType), int> _counter4 = new();
        ////private static readonly SRPlayerDatabaseTable<(int, SRWarpType), int> _balance4Character = new();
        ////private static readonly SRPlayerDatabaseTable<(int, SRWarpType), int> _balance4LightCone = new();
        //private static readonly SRPlayerDatabaseTable<(int, SRWarpType), List<ISRWarpResultItem>> _records = new(static () => []);
        //private static readonly SRPlayerDatabaseTable<(int, SRWarpType), SRPlayerWarpStats> _playerStats = new(static () => new());

        //public static SRPlayerDatabaseTable<int, int> StarRailPass => _starRailPass;
        //public static SRPlayerDatabaseTable<int, int> StarRailSpecialPass => _starRailSpecialPass;
        //public static SRPlayerDatabaseTable<int, int> StellarJade => _stellarJade;
        //public static SRPlayerDatabaseTable<int, int> OneiricShard => _oneiricShard;
        //public static SRPlayerDatabaseTable<int, int> UndyingEmbers => _undyingEmbers;
        //public static SRPlayerDatabaseTable<int, int> UndyingStarlight => _undyingStarlight;

        ////public static SRPlayerDatabaseTable<(int, SRWarpType), bool> Guarantee5 => _guarantee5;
        ////public static SRPlayerDatabaseTable<(int, SRWarpType), bool> Guarantee4 => _guarantee4;
        ////public static SRPlayerDatabaseTable<(int, SRWarpType), int> Counter5 => _counter5;
        ////public static SRPlayerDatabaseTable<(int, SRWarpType), int> Counter4 => _counter4;
        ////public static SRPlayerDatabaseTable<(int, SRWarpType), int> Balance4Character => _balance4Character;
        ////public static SRPlayerDatabaseTable<(int, SRWarpType), int> Balance4LightCone => _balance4LightCone;
        //public static SRPlayerDatabaseTable<(int, SRWarpType), List<ISRWarpResultItem>> Records => _records;
        //public static SRPlayerDatabaseTable<(int, SRWarpType), SRPlayerWarpStats> PlayerStats => _playerStats;

        //public static bool TryConsumeOneStarRailPass(int uid, bool special)
        //{
        //    if (special && _starRailSpecialPass[uid] > 0)
        //    {
        //        _starRailSpecialPass[uid]--;
        //        return true;
        //    }

        //    if (!special && _starRailPass[uid] > 0)
        //    {
        //        _starRailPass[uid]--;
        //        return true;
        //    }

        //    if (_stellarJade[uid] >= 160)
        //    {
        //        _stellarJade[uid] -= 160;
        //        return true;
        //    }
        //    else if (_oneiricShard[uid] > 0)
        //    {
        //        int need = 160 - _stellarJade[uid];
        //        if (_oneiricShard[uid] >= need)
        //        {
        //            _oneiricShard[uid] -= need;
        //            _stellarJade[uid] = 0;
        //            return true;
        //        }
        //    }

        //    if (_undyingStarlight[uid] >= 20)
        //    {
        //        _undyingStarlight[uid] -= 20;
        //        return true;
        //    }

        //    return false;
        //}
        //public static void GetWarpReward(int uid, ISRWarpResultItem item)
        //{
        //    if (item is SRLightCone)
        //    {
        //        if (item is SRStar5LightCone) _undyingStarlight[uid] += 40;
        //        else if (item is SRStar5LightCone) _undyingStarlight[uid] += 8;
        //        else _undyingEmbers[uid] += 20;
        //    }
        //    else if (item is SRCharacter character)
        //    {
        //        //_characters[uid].TryGetValue(character, out var count);
        //        //_characters[uid][character]++;
        //        if (_characters[uid][character]++ is 0) return;
        //        bool maxed = _characters[uid][character] >= 7;
        //        if (character is SRStar5Character) _undyingStarlight[uid] += maxed ? 100 : 40;
        //        else if (character is SRStar4Character) _undyingStarlight[uid] += maxed ? 20 : 8;
        //    }
        //}

        public static SRPlayer Signup()
        {
            //InternalSetItems(_uid);
            //InternalSetWarps(_uid, SRWarpType.CharacterEventWarp);
            //InternalSetCharacters(_uid);
            return new SRPlayer(_uid++);
        }
        public static SRPlayer Login(int uid)
        {
            return new SRPlayer(uid);
        }

        //internal static void InternalSetItems(int uid,
        //    int starRailPass = 0,
        //    int starRailSpecialPass = 0,
        //    int stellarJade = 0,
        //    int oneiricShard = 0,
        //    int undyingEmbers = 0,
        //    int undyingStarlight = 0
        //    )
        //{
        //    _starRailPass[uid] = starRailPass;
        //    _starRailSpecialPass[uid] = starRailSpecialPass;
        //    _stellarJade[uid] = stellarJade;
        //    _oneiricShard[uid] = oneiricShard;
        //    _undyingEmbers[uid] = undyingEmbers;
        //    _undyingStarlight[uid] = undyingStarlight;
        //}

        ////internal static void InternalSetWarps(int uid,
        ////    SRWarpType type,
        ////    bool guarantee5 = false,
        ////    bool guarantee4 = false,
        ////    int counter5 = 0,
        ////    int counter4 = 0
        ////    )
        ////{
        ////    var key = (uid, type);
        ////    _guarantee5[key] = guarantee5;
        ////    _guarantee4[key] = guarantee4;
        ////    _counter5[key] = counter5;
        ////    _counter4[key] = counter4;
        ////}

        //internal static void InternalSetCharacters(int uid, params (SRCharacter Character, int Count)[] characters)
        //{
        //    _characters[uid] = new();
        //    foreach (var (character, count) in characters)
        //    {
        //        _characters[uid][character] = count;
        //    }
        //}

        //public class SRPlayerDatabaseTable<TKey, TValue>(Func<TValue>? defaultValueFunc = null) where TKey : notnull
        //{
        //    private readonly Dictionary<TKey, TValue> _dict = [];
        //    private readonly Func<TValue>? _defaultValueFunc = defaultValueFunc;

        //    public TValue this[TKey key]
        //    {
        //        get
        //        {
        //            if (_dict.TryGetValue(key, out TValue? value)) return value;
        //            if (_defaultValueFunc is null) value = default!;
        //            else value = _defaultValueFunc();
        //            _dict[key] = value;
        //            return value;
        //        }
        //        set
        //        {
        //            _dict[key] = value;
        //        }
        //    }
        //}
    }
}
