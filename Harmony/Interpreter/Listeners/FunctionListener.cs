using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Harmony.Antlr.Extensions;
using Harmony.Extensions;
using Harmony.Interpreter.AST;
using Harmony.Interpreter.AST.Functions;
using Harmony.Interpreter.AST.Statements;
using Harmony.Interpreter.Errors;
using Harmony.Notes;
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
        private IEntity Parent
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
        public FunctionListener(IEntity parent, CompilerErrors errors)
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
            this.Result = new TransposeFunction(Parent,context, value);
        }
        public override void EnterPropagateFunction([NotNull] HarmonyParser.PropagateFunctionContext context)
        {
            int amount = context.amount.Get<int>();
            this.Result = new PropagateFunction(Parent, context, amount);
        }
        public override void EnterArpeggioFunction([NotNull] HarmonyParser.ArpeggioFunctionContext context)
        {
            if (context.IDENTIFIER() == null)
            {
                return;
            }
            string strumTypeText = context.IDENTIFIER().GetText();

            StrumTypeEnum strumType = StrumTypeEnum.unknown;

            if (Enum.TryParse(strumTypeText, out strumType) && strumType != StrumTypeEnum.unknown)
            {
                this.Result = new ArpeggioFunction(Parent, context, strumType);
            }
            else
            {
                ErrorsHandler.SemanticError(context, "Unknown strum type : " + strumTypeText);
            }
        }
        public override void EnterStrumFunction([NotNull] HarmonyParser.StrumFunctionContext context)
        {
            float offset = context.offset.Get<float>();
            this.Result = new StrumFunction(Parent, context, offset);
        }
        public override void EnterBlockFunction([NotNull] HarmonyParser.BlockFunctionContext context)
        {
            context.current.EnterRule(this);

            if (context.next != null)
            {
                FunctionListener listener = new FunctionListener(this.Result, ErrorsHandler);
                context.next.EnterRule(listener);

                if (listener.Result != null && Result != null)
                {
                    Result.TargetFunction = listener.Result;
                }
            }
        }
        public override void EnterAddFunction([NotNull] HarmonyParser.AddFunctionContext context)
        {
            if (context.noteLiteral() == null)
            {
                return;
            }

            Note note = NotesManager.GetNote(context.noteLiteral().GetText());

            if (note == null)
            {
                return;
            }
            Result = new AddFunction(Parent, context, note);

            base.EnterAddFunction(context);
        }
        public override void EnterTimesFunction([NotNull] HarmonyParser.TimesFunctionContext context)
        {
            int amount = context.amount.Get<int>();
            this.Result = new TimesFunction(Parent, context, amount);
        }
        public override void EnterBassFunction([NotNull] HarmonyParser.BassFunctionContext context)
        {
            this.Result = new BassFunction(Parent, context);
        }
    }
}
