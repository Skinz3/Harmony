using Antlr4.Runtime;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Scripts
{
    public class HarmonyScript
    {
        public const string Extension = ".hm";

        public string Filepath
        {
            get;
            private set;
        }

        public Sheet Sheet
        {
            get;
            private set;
        }

        public Dictionary<string, string> Attributes
        {
            get;
            private set;
        }
        public HarmonyScript(string path)
        {
            this.Filepath = path;
            this.Attributes = new Dictionary<string, string>();
        }


        public bool Read()
        {
            if (!File.Exists(Filepath))
            {
                return false;
            }

            string text = File.ReadAllText(Filepath);

            var inputStream = new AntlrInputStream(text);
            var lexer = new HarmonyLexer(inputStream);

            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new HarmonyParser(commonTokenStream);

            this.Sheet = new Sheet();

            HarmonyParser.CompilationUnitContext ectx = parser.compilationUnit();

            ScriptListener listener = new ScriptListener(this);

            ectx.EnterRule(listener);

            return true;
        }



    }
}
