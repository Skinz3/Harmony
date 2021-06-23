using Antlr4.Runtime;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST.Statements
{
    public class StepStatement : Statement
    {
        private float Duration
        {
            get;
            set;
        }
        private Statement Target
        {
            get;
            set;
        }
        private bool TargetPrepared
        {
            get;
            set;
        }
        public StepStatement(Unit parent, ParserRuleContext ruleContext, float duration) : base(parent, ruleContext)
        {
            this.Duration = GetTimeSeconds(duration);
        }
        public StepStatement(Unit parent, ParserRuleContext ruleContext, Statement target) : base(parent, ruleContext)
        {
            this.Target = target;
        }

        public override void Prepare()
        {
            PrepareTarget();

            base.Prepare();
        }

        private void PrepareTarget()
        {
            if (Target != null && !TargetPrepared)
            {
                Target.Prepare();
                this.Duration = Target.GetDuration();
                TargetPrepared = true;
            }
        }
        protected override List<SheetNote> Execute(ref float time)
        {
            List<SheetNote> result = new List<SheetNote>();

            if (Target != null)
            {
                result = Target.Apply(ref time);
            }

            time += Duration;

            return result;
        }

        public override float GetDuration()
        {
            PrepareTarget();

            return Duration;
        }
    }
}
