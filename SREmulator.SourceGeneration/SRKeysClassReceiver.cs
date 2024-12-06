using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SREmulator.SourceGeneration
{
    public class SRKeysClassReceiver : ISyntaxContextReceiver
    {
        private TypeDeclarationSyntax _keys;
        private readonly string _className;
        public TypeDeclarationSyntax Keys => _keys;
        public string ClassName => _className;

        public SRKeysClassReceiver(string className)
        {
            _className = className;
        }

        void ISyntaxContextReceiver.OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if (_keys is null &&
                context.Node is TypeDeclarationSyntax typeDeclaration &&
                context.SemanticModel.GetDeclaredSymbol(typeDeclaration).Name == ClassName)
            {
                _keys = typeDeclaration;
            }
        }

        public static SyntaxContextReceiverCreator Creator(string className)
        {
            return () => new SRKeysClassReceiver(className);
        }
    }
}
