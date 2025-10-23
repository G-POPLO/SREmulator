using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SREmulator.GUI.Model
{
    /// <summary>
    /// 卡池版本信息类
    /// </summary>
    public class WarpVersionInfo
    {
        /// <summary>
        /// 版本显示名称
        /// </summary>
        public string VersionName { get; set; }

        /// <summary>
        /// 版本键值
        /// </summary>
        public int VersionKey { get; set; }

        /// <summary>
        /// 主版本号
        /// </summary>
        public int MajorVersion { get; set; }

        /// <summary>
        /// 次版本号
        /// </summary>
        public int MinorVersion { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="versionName">版本显示名称</param>
        /// <param name="versionKey">版本键值</param>
        /// <param name="majorVersion">主版本号</param>
        /// <param name="minorVersion">次版本号</param>
        public WarpVersionInfo(string versionName, int versionKey, int majorVersion, int minorVersion)
        {
            VersionName = versionName;
            VersionKey = versionKey;
            MajorVersion = majorVersion;
            MinorVersion = minorVersion;
        }

        /// <summary>
        /// 重写ToString方法，返回版本显示名称
        /// </summary>
        /// <returns>版本显示名称</returns>
        public override string ToString()
        {
            return VersionName;
        }
    }
}