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
    public abstract class Statement : IEntity
    {
        public Unit Parent
        {
            get;
            private set;
        }
        public Function TargetFunction
        {
            get;
            set;
        }

        protected ParserRuleContext RuleContext
        {
            get;
            private set;
        }
        public Statement(Unit parent, ParserRuleContext ruleContext)
        {
            this.Parent = parent;
            this.RuleContext = ruleContext;
        }


        public float GetTimeSeconds(float value)
        {
            return 60f / Parent.Script.Tempo * value;
        }


        protected abstract List<SheetNote> Execute(ref float time);

        public List<SheetNote> Apply(ref float time)
        {
            var result = Execute(ref time);

            TargetFunction?.Apply(ref time, result);

            return result;
        }

        public virtual void Prepare()
        {
            TargetFunction?.Prepare();
        }

        public abstract float GetDuration();

        public float GetRightDuration()
        {
            var result = GetDuration();

            if (TargetFunction != null)
            {
                result += TargetFunction.GetRightDuration();
            }

            return result;
        }

        public float GetLeftDuration()
        {
            return GetDuration();
           
        }
    }
}
