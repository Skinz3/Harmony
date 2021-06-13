using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Antlr
{
    class Program
    {
        private const string AntlrPath = "antlr4-csharp-4.6.6-complete.jar";

        private const string LexerPath = @"C:\Users\Skinz\Desktop\Harmony\Harmony.Antlr\HarmonyLexer.g4";
        private const string ParserPath = @"C:\Users\Skinz\Desktop\Harmony\Harmony.Antlr\HarmonyParser.g4";

        private const string OutputPath = @"C:\Users\Skinz\Desktop\Harmony\Harmony\Antlr";

        static void Main(string[] args)
        {
            AntlrTool tool = new AntlrTool(AntlrPath);

            bool lexer = tool.Generate(LexerPath, OutputPath);
            bool parser = tool.Generate(ParserPath, OutputPath);

            if (lexer && parser)
            {
                Console.WriteLine("Antlr files generated.");
            }
            else
            {
                Console.WriteLine("Antlr generation ended with errors...");
            }
            Console.Read();
        }
    }
}
