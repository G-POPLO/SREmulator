using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SREmulator.SourceGeneration
{
    internal static class Utils
    {
        public static INamedTypeSymbol GetAttribute(this GeneratorSyntaxContext context, string fullyQualifiedMetadataName)
        {
            return context.SemanticModel.Compilation.GetTypeByMetadataName(fullyQualifiedMetadataName);
        }
        public static INamedTypeSymbol GetAttribute(this GeneratorExecutionContext context, string fullyQualifiedMetadataName)
        {
            return context.Compilation.GetTypeByMetadataName(fullyQualifiedMetadataName);
        }
        public static INamedTypeSymbol GetAttribute(this SemanticModel semanticModel, string fullyQualifiedMetadataName)
        {
            return semanticModel.Compilation.GetTypeByMetadataName(fullyQualifiedMetadataName);
        }

        public static AttributeData GetAttribute(this ISymbol symbol, INamedTypeSymbol attributeClass)
        {
            return GetAttributes(symbol, attributeClass).First();
        }
        public static IEnumerable<AttributeData> GetAttributes(this ISymbol symbol, INamedTypeSymbol attributeClass)
        {
            return symbol
                .GetAttributes()
                .Where(attr => SymbolEqualityComparer.Default.Equals(attr.AttributeClass, attributeClass));
        }
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
