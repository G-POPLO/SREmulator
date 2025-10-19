using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SREmulator.SourceGeneration
{
    internal static class Utils
    {
        public static AttributeData GetAttribute(this ISymbol symbol, string name)
        {
            return GetAttributes(symbol, name).First();
        }
        public static IEnumerable<AttributeData> GetAttributes(this ISymbol symbol, string name)
        {
            return symbol
                .GetAttributes()
                .Where(attr => attr.AttributeClass.Name == name);
        }
        public static bool ContainsAttribute(this ISymbol symbol, string name)
        {
            return symbol
                .GetAttributes()
                .Any(attr => attr.AttributeClass.Name == name);
        }

        public static void Deconstruct<T>(this AttributeData attributeData, int index, out T arg)
        {
            arg = (T)attributeData.ConstructorArguments[index].Value;
        }
        public static void Deconstruct<T>(this AttributeData attributeData, int index, out T[] arg)
        {
            arg = attributeData.ConstructorArguments[index].Values.Select(item => (T)item.Value).ToArray();
        }

        public static StringBuilder AppendLine(this StringBuilder builder, int indentDepth, string value)
        {
            for (int i = 0; i < indentDepth; i++)
            {
                builder.Append("    ");
            }
            return builder.AppendLine(value);
        }
    }
}
