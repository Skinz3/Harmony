using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HarmonyParser;

namespace Harmony.Scripts
{
    public class ScriptListener : HarmonyParserBaseListener
    {
        private HarmonyScript File
        {
            get;
            set;
        }

        public ScriptListener(HarmonyScript file)
        {
            this.File = file;
        }
        public override void EnterCompilationUnit([NotNull] HarmonyParser.CompilationUnitContext context)
        {
            EnterAttributes(context.attributes());

            foreach (var unit in context.unitDeclaration())
            {
                EnterUnitDeclaration(unit);
            }
        }

        public override void EnterUnitDeclaration([NotNull] UnitDeclarationContext context)
        {
            EnterBlock(context.block());
        }
        public override void EnterBlock([NotNull] BlockContext context)
        {
            foreach (var statement in context.blockStatement())
            {
                StatementListener statementListener = new StatementListener();
                statement.EnterRule(statementListener);

                foreach (FunctionContext function in statement.function())
                {
                    FunctionListener functionListener = new FunctionListener(statementListener.Notes);
                    function.EnterRule(functionListener);
                }

                File.Sheet.Notes.AddRange(statementListener.Notes);
            }
        }
        public override void EnterAttributes([NotNull] AttributesContext context)
        {
            File.Sheet.TotalDuration = context.duration.Get<float>();
            File.Sheet.Name = context.name.Text + " (script)";

            base.EnterAttributes(context);
        }
    }
}
