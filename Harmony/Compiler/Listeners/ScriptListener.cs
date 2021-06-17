using Antlr4.Runtime.Misc;
using Harmony.Antlr.Extensions;
using Harmony.Compiler.AST;
using Harmony.Compiler.Errors;
using Harmony.Compiler.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HarmonyParser;

namespace Harmony.Compiler
{
    public class ScriptListener : HarmonyParserBaseListener
    {
        public List<Unit> Units
        {
            get;
            set;
        }
        public float TotalDuration
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public int Tempo
        {
            get;
            set;
        }
        public CompilerErrors ErrorsHandler
        {
            get;
            set;
        }
        public ScriptListener(CompilerErrors errorsHandler)
        {
            this.ErrorsHandler = errorsHandler;
            this.Units = new List<Unit>();
        }
        public override void EnterCompilationUnit([NotNull] HarmonyParser.CompilationUnitContext context)
        {
            EnterAttributes(context.attributes());

            foreach (var unit in context.unitDeclaration())
            {
                UnitListener listener = new UnitListener(ErrorsHandler);
                unit.EnterRule(listener);
                Units.Add(listener.Result);
            }
        }

        public override void EnterAttributes([NotNull] AttributesContext context)
        {
            this.TotalDuration = context.duration.Get<float>();
            this.Name = context.name.Text + " (script)";
            this.Tempo = context.tempo.Get<int>();
            base.EnterAttributes(context);
        }
    }
}
