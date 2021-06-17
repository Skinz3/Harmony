using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Compiler.Errors
{
    public class CompilerErrors : List<Error>, IAntlrErrorListener<IToken>
    {
        public void SemanticError(ParserRuleContext context, string message)
        {
            this.Add(new SourceError(ErrorType.Semantic, context.start.Line, context.start.StartIndex, message));
        }
        public void SyntaxError([NotNull] IRecognizer recognizer, [Nullable] IToken offendingSymbol, int line, int charPositionInLine, [NotNull] string msg, [Nullable] RecognitionException e)
        {
            this.Add(new SourceError(ErrorType.Syntaxic, line, charPositionInLine, msg));
        }
        public void Error(ErrorType type,string message)
        {
            this.Add(new Error(type, message));
        }

    }
    
    
}
