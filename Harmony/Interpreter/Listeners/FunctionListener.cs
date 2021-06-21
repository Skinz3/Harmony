using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Harmony.Antlr.Extensions;
using Harmony.Interpreter.AST.Functions;
using Harmony.Interpreter.AST.Statements;
using Harmony.Interpreter.Errors;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter
{
    public class FunctionListener : HarmonyParserBaseListener
    {
        private Statement Parent
        {
            get;
            set;
        }
        public Function Result
        {
            get;
            set;
        }
        private CompilerErrors ErrorsHandler
        {
            get;
            set;
        }
        public FunctionListener(Statement parent, CompilerErrors errors)
        {
            this.Parent = parent;
            this.ErrorsHandler = errors;
        }
        public override void EnterFunction([NotNull] HarmonyParser.FunctionContext context)
        {
            foreach (var rule in context.GetRuleContexts<ParserRuleContext>())
            {
                rule.EnterRule(this);
            }
        }

        public override void EnterTransposeFunction([NotNull] HarmonyParser.TransposeFunctionContext context)
        {
            int value = context.value.Get<int>();
            this.Result = new TransposeFunction(Parent, value);
        }
        public override void EnterPropagateFunction([NotNull] HarmonyParser.PropagateFunctionContext context)
        {
            int amount = context.amount.Get<int>();
            this.Result = new PropagateFunction(Parent, amount);
        }
        public override void EnterStrumFunction([NotNull] HarmonyParser.StrumFunctionContext context)
        {
            float shift = context.offset.Get<float>();
            this.Result = new StrumFunction(Parent, shift);
        }
        public override void EnterTimesFunction([NotNull] HarmonyParser.TimesFunctionContext context)
        {
            int amount = context.amount.Get<int>();
            this.Result = new TimesFunction(Parent, amount);
        }
        public override void EnterBassFunction([NotNull] HarmonyParser.BassFunctionContext context)
        {
            this.Result = new BassFunction(Parent);
        }
    }
}
