using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SREmulator.SourceGeneration.Receivers
{
    public abstract class SRKeysClassReceiver : ISyntaxContextReceiver
    {
        private INamedTypeSymbol _attribute;
        private TypeDeclarationSyntax _keys;

        protected string AttributeFullName => $"SREmulator.Attributes.{AttributeName}";
        protected abstract string AttributeName { get; }
        protected abstract string ClassName { get; }

        public INamedTypeSymbol Attribute => _attribute;
        public TypeDeclarationSyntax Keys => _keys;

        void ISyntaxContextReceiver.OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if (_attribute is null)
            {
                _attribute = context.GetAttribute(AttributeFullName);
            }

            if (_keys is null &&
                context.Node is TypeDeclarationSyntax typeDeclaration &&
                context.SemanticModel.GetDeclaredSymbol(typeDeclaration).Name == ClassName)
            {
                _keys = typeDeclaration;
            }
        }

    }
}
