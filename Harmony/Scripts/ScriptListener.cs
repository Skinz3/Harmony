using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override void EnterUnitDeclaration([NotNull] HarmonyParser.UnitDeclarationContext context)
        {
            EnterBlock(context.block());
        }
        public override void EnterBlock([NotNull] HarmonyParser.BlockContext context)
        {
            foreach (var statement in context.statement())
            {
                StatementListener statementListener = new StatementListener(File);
                statement.EnterRule(statementListener);
            }
        }
        public override void EnterAttributes([NotNull] HarmonyParser.AttributesContext context)
        {
            File.Sheet.TotalDuration = context.duration.Get<float>();
           
            base.EnterAttributes(context);
        }
    }
}
