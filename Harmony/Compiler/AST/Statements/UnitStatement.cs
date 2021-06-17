using Antlr4.Runtime;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Compiler.AST.Statements
{
    public class UnitStatement : Statement
    {
        private string Name
        {
            get;
            set;
        }
        private Unit TargetUnit
        {
            get;
            set;
        }
        public UnitStatement(ParserRuleContext context, string name) : base(context)
        {
            this.Name = name;
        }

        public override IEnumerable<SheetNote> GetNotes()
        {
            return TargetUnit.GetNotes();
        }
        public override void Prepare(HarmonyScript script)
        {   
            TargetUnit = script.GetUnit(Name);

            if (TargetUnit == null)
            {
                script.Errors.SemanticError(RuleContext, "Unknown unit : " + Name);
            }

            base.Prepare(script);
        }

    }
}
