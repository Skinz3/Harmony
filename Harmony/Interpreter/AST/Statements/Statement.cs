using Antlr4.Runtime;
using Harmony.Interpreter.AST.Functions;
using Harmony.Notes;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST.Statements
{
    public abstract class Statement : IExecutable
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

        public abstract float GetDuration();

        public abstract List<SheetNote> Execute(ref float time);

        public virtual void Prepare(HarmonyScript script)
        {
            foreach (var function in Functions)
            {
                function.Prepare(script);
            }
        }
    }
}
