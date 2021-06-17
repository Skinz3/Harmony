using Antlr4.Runtime;
using Harmony.Compiler.AST.Functions;
using Harmony.Notes;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Compiler.AST.Statements
{
    public abstract class Statement : ICompilable
    {
        public List<Function> Functions
        {
            get;
            private set;
        }

        protected ParserRuleContext RuleContext
        {
            get;
            private set;
        }
        public Statement(ParserRuleContext ruleContext)
        {
            this.RuleContext = ruleContext;
            this.Functions = new List<Function>();
        }

        public abstract IEnumerable<SheetNote> GetNotes();

        public virtual void Prepare(HarmonyScript script)
        {
            foreach (var function in Functions)
            {
                function.Prepare(script);
            }
        }
    }
}
