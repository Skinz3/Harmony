using Antlr4.Runtime;
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

        private string Filepath
        {
            get;
            set;
        }

        public List<Unit> Units
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
            this.Units = new List<Unit>();
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

            HarmonyParser.CompilationUnitContext ectx = parser.compilationUnit();

            UnitListener listener = new UnitListener(this);

            ectx.EnterRule(listener);

            return true;
        }
      
    }
}
