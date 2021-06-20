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
        public UnitStatement(ParserRuleContext context, string name) : base(context)
        {
            this.Name = name;
        }

        public override List<SheetNote> Execute(ref float time)
        {
            var result = TargetUnit.Execute(ref time);
            time += GetDuration();
            return result;
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

        public override float GetDuration()
        {
            return TargetUnit.GetDuration();
        }
    }
}
