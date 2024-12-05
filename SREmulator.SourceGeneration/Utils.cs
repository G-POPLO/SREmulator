using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace SREmulator.SourceGeneration
{
    internal static class Utils
    {
        public static INamedTypeSymbol GetAttribute(this GeneratorSyntaxContext context, string fullyQualifiedMetadataName)
        {
            return context.SemanticModel.Compilation.GetTypeByMetadataName(fullyQualifiedMetadataName);
        }

        //public static bool ContainsAttribute(this MemberDeclarationSyntax syntax, GeneratorSyntaxContext context, INamedTypeSymbol attribute)
        //{
        //    return syntax.AttributeLists
        //        .SelectMany(list => list.Attributes)
        //        .Select(attr => context.SemanticModel.GetSymbolInfo(attr))
        //        .Any(symbolInfo => SymbolEqualityComparer.Default.Equals(symbolInfo.Symbol?.ContainingType, attribute));
        //}

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
    }
}
