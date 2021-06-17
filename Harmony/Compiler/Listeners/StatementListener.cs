using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Harmony.Chords;
using Harmony.Notes;
using Harmony.Compiler.AST.Statements;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony.Compiler.Errors;
using Harmony.Antlr.Extensions;
using static HarmonyParser;

namespace Harmony.Compiler
{
    public class StatementListener : HarmonyParserBaseListener
    {
        public Statement Result
        {
            get;
            set;
        }
        private CompilerErrors ErrorsHandler
        {
            get;
            set;
        }
        public StatementListener(CompilerErrors errorsHandler)
        {
            this.ErrorsHandler = errorsHandler;
        }
         
        public override void EnterStatement([NotNull] HarmonyParser.StatementContext context)
        {
            foreach (var statement in context.GetRuleContexts<ParserRuleContext>())
            {
                statement.EnterRule(this);
            }
        }
        public override void EnterBlockStatement([NotNull] HarmonyParser.BlockStatementContext context)
        {
            foreach (var statement in context.GetRuleContexts<ParserRuleContext>())
            { 
                statement.EnterRule(this);
            }

            foreach (FunctionContext function in context.function())
            {
                FunctionListener functionListener = new FunctionListener(ErrorsHandler);
                function.EnterRule(functionListener);
                Result.Functions.Add(functionListener.Result);
            }
        }
        public override void EnterNoteStatement([NotNull] HarmonyParser.NoteStatementContext context)
        {
            if (context.exception != null)
            {
                return;
            }
            string noteName = context.noteLiteral().GetText();

            Note note = NotesManager.GetNote(noteName);

            if (note == null)
            {
                ErrorsHandler.SemanticError(context, "Invalid note : " + noteName);
                return;
            }
            float start = context.startTime.Get<float>();
            float duration = context.duration.Get<float>();
            float velocity = context.velocity.Get<float>();

            this.Result = new NoteStatement(context,note, start, duration, velocity);
        }
        public override void EnterUnitStatement([NotNull] HarmonyParser.UnitStatementContext context)
        {
            string unitName = context.name.Text;

            this.Result = new UnitStatement(context,unitName);

        }
        public override void EnterChordStatement([NotNull] HarmonyParser.ChordStatementContext context)
        {
            if (context.exception != null)
            {
                return;
            }
            string chordName = context.chordLiteral().GetText();
            int octave = context.octave.Get<int>();
            float start = context.startTime.Get<float>();
            float duration = context.duration.Get<float>();
            float velocity = context.velocity.Get<float>();

            Chord chord = ChordsManager.BuildChord(chordName, octave);

            if (chord == null)
            {
                ErrorsHandler.SemanticError(context, "Invalid chord : " + chordName);
                return;
            }

            this.Result = new ChordStatement(context,chord, start, duration, velocity, octave);

        }

    }
}
