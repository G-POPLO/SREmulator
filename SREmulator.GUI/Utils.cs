using SREmulator.Attributes;
using SREmulator.GUI.Model;
using SREmulator.Localizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SREmulator.GUI
{
    internal static class Utils
    {
        public static StringValuePair[] CreateStringValuePairFromSRKeys(Type keysType)
        {
            var list = new List<StringValuePair>();

            var constFields = keysType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string));

            foreach (var field in constFields)
            {
                var aliasesAttr = field.GetCustomAttribute<SRAliasesAttribute>();
                if (aliasesAttr != null)
                    list.Add(new StringValuePair(aliasesAttr.Aliases[0], LocalizationManager.GetLocalized(field.Name)));
            }

            return [.. list];
        }
    }
}
