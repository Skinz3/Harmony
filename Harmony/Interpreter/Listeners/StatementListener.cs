using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Harmony.Chords;
using Harmony.Notes;
using Harmony.Interpreter.AST.Statements;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony.Interpreter.Errors;
using Harmony.Antlr.Extensions;
using static HarmonyParser;
using Harmony.Interpreter.AST;

namespace Harmony.Interpreter
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
        private Unit Parent
        {
            get;
            set;
        }
        public StatementListener(Unit parent, CompilerErrors errorsHandler)
        {
            this.Parent = parent;
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
            context.statement().EnterRule(this);

            if (Result == null)
            {
                return;
            }
            var functionContext = context.blockFunction();

            if (functionContext != null)
            {
                FunctionListener functionListener = new FunctionListener(Result, ErrorsHandler);
                functionContext.EnterRule(functionListener);

                Result.TargetFunction = functionListener.Result;
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

            float duration = context.duration.Get<float>();
            float velocity = context.velocity.Get<float>();

            this.Result = new NoteStatement(Parent, context, note, duration, velocity);
        }
        public override void EnterUnitStatement([NotNull] HarmonyParser.UnitStatementContext context)
        {
            string unitName = context.name.Text;
            this.Result = new UnitStatement(Parent, context, unitName);

        }
        public override void EnterStepStatement([NotNull] StepStatementContext context)
        {
            if (context.duration != null)
            {
                StepStatement statement = new StepStatement(Parent, context, context.duration.Get<float>());
                Result = statement;
            }
            else
            {
                BlockStatementContext statementContext = context.blockStatement();

                if (statementContext != null)
                {
                    StatementListener listener = new StatementListener(Parent, ErrorsHandler);
                    statementContext.EnterRule(listener);

                    StepStatement statement = new StepStatement(Parent, context, listener.Result);
                    Result = statement;
                }
            }
        }
        public override void EnterChordStatement([NotNull] HarmonyParser.ChordStatementContext context)
        {
            if (context.exception != null)
            {
                return;
            }
            string chordName = context.chordLiteral().GetText();
            int octave = context.octave.Get<int>();
            float duration = context.duration.Get<float>();
            float velocity = context.velocity.Get<float>();

            Chord chord = ChordsManager.BuildChord(chordName, octave);

            if (chord == null)
            {
                ErrorsHandler.SemanticError(context, "Invalid chord : " + chordName);
                return;
            }

            this.Result = new ChordStatement(Parent, context, chord, duration, velocity, octave);

        }

        public override void EnterNotesStatement([NotNull] NotesStatementContext context)
        {
            List<Note> notes = new List<Note>();

            foreach (var noteLiteral in context.noteLiteral())
            {
                Note note = NotesManager.GetNote(noteLiteral.GetText());

                if (note == null)
                {
                    ErrorsHandler.SemanticError(context, "Invalid note : " + noteLiteral.GetText());
                    return;
                }
                notes.Add(note);
            }
            float duration = context.duration.Get<float>();
            float velocity = context.velocity.Get<float>();

            this.Result = new NotesStatement(Parent, context, notes, duration, velocity);
        }
    }
}
