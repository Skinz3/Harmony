using Antlr4.Runtime.Misc;
using Harmony.Antlr.Extensions;
using Harmony.Interpreter.AST;
using Harmony.Interpreter.Errors;
using Harmony.Interpreter.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HarmonyParser;

namespace Harmony.Interpreter
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
        public string Author
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

            if (context.name == null)
            {
                ErrorsHandler.SyntaxError(context, "Missing 'name' attribute.");
            }

            if (context.tempo == null)
            {
                ErrorsHandler.SyntaxError(context, "Missing 'tempo' attribute.");
            }

            if (context.author == null)
            {
                ErrorsHandler.SyntaxError(context, "Missing 'author' attribute.");
            }
           
            if (context.name == null || context.tempo == null || context.author == null)
            {
                return;
            }

            this.Name = context.name.Text + " (script)";
            this.Tempo = context.tempo.Get<int>();
            this.Author = context.author.Text;
            base.EnterAttributes(context);
        }
    }
}
