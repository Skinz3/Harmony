using Antlr4.Runtime;
using Harmony.Interpreter.AST.Meta;
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

        protected override List<SheetNote> Execute(ref float time, NoteMetaProvider metaProvider)
        {
            var oldTime = time;

            var result = TargetUnit.Apply(ref time, metaProvider);

            time = oldTime;

            return result;
        }
        public override void Prepare()
        {
            TargetUnit = Parent.Script.GetUnit(Name);

            if (TargetUnit == null)
            {
                Parent.Script.Errors.SemanticError(Context, "Unknown unit : " + Name);
            }

            base.Prepare();
        }

        public override float GetDuration()
        {
            if (TargetUnit == null)
            {
                return 0f;
            }

            return TargetUnit.GetSteppedDuration();
        }
    }
}
