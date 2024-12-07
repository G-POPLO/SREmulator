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
        public static void Deconstruct<T0, T1, T2>(this AttributeData attributeData, out T0 arg0, out T1 arg1, out T2 arg2)
        {
            arg0 = (T0)attributeData.ConstructorArguments[0].Value;
            arg1 = (T1)attributeData.ConstructorArguments[1].Value;
            arg2 = (T2)attributeData.ConstructorArguments[2].Value;
        }
        public static void Deconstruct<T0, T1, T2, T3, T4, T5, T6, T7>(this AttributeData attributeData, out T0 arg0, out T1 arg1, out T2 arg2, out T3 arg3, out T4 arg4, out T5 arg5, out T6 arg6, out T7 arg7)
        {
            arg0 = (T0)attributeData.ConstructorArguments[0].Value;
            arg1 = (T1)attributeData.ConstructorArguments[1].Value;
            arg2 = (T2)attributeData.ConstructorArguments[2].Value;
            arg3 = (T3)attributeData.ConstructorArguments[3].Value;
            arg4 = (T4)attributeData.ConstructorArguments[4].Value;
            arg5 = (T5)attributeData.ConstructorArguments[5].Value;
            arg6 = (T6)attributeData.ConstructorArguments[6].Value;
            arg7 = (T7)attributeData.ConstructorArguments[7].Value;
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
