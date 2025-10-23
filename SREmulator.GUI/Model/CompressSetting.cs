using SevenZip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SREmulator.GUI.Model
{
    class CompressSetting
    {
        public static void ConfigureSevenZip()
        {
            // 加载dll
            SevenZipBase.SetLibraryPath(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory,"7zxa.dll"));
        }
    }
}
