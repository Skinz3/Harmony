using Antlr4.Runtime.Misc;
using Harmony.Interpreter.AST;
using Harmony.Interpreter.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HarmonyParser;

namespace Harmony.Interpreter.Listeners
{
    public class UnitListener : HarmonyParserBaseListener
    {
        public Unit Result
        {
            get;
            set;
        }

        private CompilerErrors ErrorsHandler
        {
            get;
            set;
        }

        public UnitListener(HarmonyScript script, CompilerErrors errorsHandler)
        {
            this.ErrorsHandler = errorsHandler;
            this.Result = new Unit(script);
        }

        public override void EnterUnitDeclaration([NotNull] UnitDeclarationContext context)
        {
            Result.Name = context.name.Text;
            EnterBlock(context.block());
        }
        public override void EnterBlock([NotNull] BlockContext context)
        {
            StatementListener statementListener = new StatementListener(Result, ErrorsHandler);

            foreach (var statement in context.blockStatement())
            {
                statement.EnterRule(statementListener);

                if (statementListener.Result != null)
                {
                    Result.Statements.Add(statementListener.Result);
                }
            }
        }
    }
}
