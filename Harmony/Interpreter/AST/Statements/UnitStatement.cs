using Antlr4.Runtime;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST.Statements
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
        public UnitStatement(Unit parent, ParserRuleContext context, string name) : base(parent, context)
        {
            this.Name = name;
        }

        public override List<SheetNote> Execute(ref float time)
        {
            float oldTime = time;

            var result = TargetUnit.Execute(ref time);

            time = oldTime;

            return result;
        }
        public override void Prepare()
        {
            TargetUnit = Parent.Script.GetUnit(Name);

            if (TargetUnit == null)
            {
                Parent.Script.Errors.SemanticError(RuleContext, "Unknown unit : " + Name);
            }

            base.Prepare();
        }

        protected override float GetDuration()
        {
            if (TargetUnit == null)
            {
                return 0f;
            }
            return TargetUnit.GetDuration();
        }
    }
}
