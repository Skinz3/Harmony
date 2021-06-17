using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Harmony.Antlr.Extensions;
using Harmony.Compiler.AST.Functions;
using Harmony.Compiler.AST.Statements;
using Harmony.Compiler.Errors;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Compiler
{
    public class FunctionListener : HarmonyParserBaseListener
    {
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
        public FunctionListener(CompilerErrors errors)
        {
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
            this.Result = new TransposeFunction(value);
        }
        public override void EnterPropagateFunction([NotNull] HarmonyParser.PropagateFunctionContext context)
        {
            int amount = context.amount.Get<int>();
            this.Result = new PropagateFunction(amount);
        }
        public override void EnterArpeggiateFunction([NotNull] HarmonyParser.ArpeggiateFunctionContext context)
        {
            float shift = context.offset.Get<float>();
            this.Result = new ArpeggiateFunction(shift);
        }
        public override void EnterPlayWithFunction([NotNull] HarmonyParser.PlayWithFunctionContext context)
        {
            base.EnterPlayWithFunction(context);

            StatementListener listener = new StatementListener(ErrorsHandler);
            context.blockStatement().EnterRule(listener);

            this.Result = new PlayWithFunction(listener.Result);
        }
    }
}
