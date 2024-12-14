using SREmulator.SRItems;
using SREmulator.SRPlayers;
using SREmulator.SRWarps.CommonWarps;
using SREmulator.SRWarps.EventWarps;
using System.Diagnostics.CodeAnalysis;

namespace SREmulator.SRWarps
{
    public enum SRWarpType
    {
        None,

        /// <summary>
        /// 始发跃迁
        /// </summary>
        DepartureWarp,

        /// <summary>
        /// 群星跃迁
        /// </summary>
        StellarWarp,

        /// <summary>
        /// 角色活动跃迁
        /// </summary>
        CharacterEventWarp,

        /// <summary>
        /// 光锥活动跃迁
        /// </summary>
        LightConeEventWarp
    }

    public abstract class SRWarp
    {
        public abstract SRWarpType WarpType { get; }
        public virtual SRVersion Version => SRVersion.Unspecified;

        public abstract ISRWarpResultItem Up5 { get; }
        public abstract ISRWarpResultItem[] Common5Characters { get; }
        public abstract ISRWarpResultItem[] Common5LightCones { get; }
        public abstract ISRWarpResultItem[] Up4 { get; }
        public abstract ISRWarpResultItem[] Common4Characters { get; }
        public abstract ISRWarpResultItem[] Common4LightCones { get; }
        public abstract ISRWarpResultItem[] Common3 { get; }

        private SRWarpStats? _warpStats = null;
        private protected SRWarpStats WarpStats
        {
            get
            {
                return _warpStats ??= new(
                    WarpType,
                    Up5,
                    Common5Characters,
                    Common5LightCones,
                    Up4,
                    Common4Characters,
                    Common4LightCones,
                    Common3
                    );
            }
        }
        protected void ResetWarpStats()
        {
            _warpStats = null;
        }

        public bool TryWarp(SRPlayer player, [NotNullWhen(true)] out ISRWarpResultItem? result)
        {
            if (!PreWarp(player, 1))
            {
                result = null;
                return false;
            }

            result = OnWarp(player);
            PostWarp(player, result);
            return true;
        }
        public bool Try10Warp(SRPlayer player, [NotNullWhen(true)] out ISRWarpResultItem[]? result)
        {
            if (!PreWarp(player, 10))
            {
                result = null;
                return false;
            }

            result = On10Warp(player);
            Post10Warp(player, result);
            return true;
        }

        public abstract bool PreWarp(SRPlayer player, int count);
        public abstract ISRWarpResultItem OnWarp(SRPlayer player);
        public abstract void PostWarp(SRPlayer player, ISRWarpResultItem item);

        public virtual ISRWarpResultItem[] On10Warp(SRPlayer player)
        {
            ISRWarpResultItem[] result = new ISRWarpResultItem[10];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = OnWarp(player);
            }
            return result;
        }
        public virtual void Post10Warp(SRPlayer player, ISRWarpResultItem[] items)
        {
            foreach (ISRWarpResultItem item in items)
            {
                PostWarp(player, item);
            }
        }

        public static SRWarp? GetWarp(string name, SRWarpType type, SRVersion version)
        {
            if (type is SRWarpType.DepartureWarp || name.ToLower() is "departure" or "departure-warp")
            {
                return SRDepartureWarp.DepartureWarp;
            }

            if (type is SRWarpType.StellarWarp || name.ToLower() is "stellar" or "stellar-warp")
            {
                return SRStellarWarps.GetStellarWarpByVersion(version);
            }

            if (type is SRWarpType.CharacterEventWarp)
            {
                return SRCharacterEventWarps.GetWarpByNameAndVersion(name, version);
            }

            if (type is SRWarpType.LightConeEventWarp)
            {
                return SRLightConeEventWarps.GetWarpByNameAndVersion(name, version);
            }

            return null;
        }
    }
}
