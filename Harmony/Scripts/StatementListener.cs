using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Harmony.Chords;
using Harmony.Notes;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Scripts
{
    public class StatementListener : HarmonyParserBaseListener
    {
        public List<SheetNote> Notes
        {
            get;
            set;
        }
        public StatementListener()
        {
            this.Notes = new List<SheetNote>();
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
                Console.WriteLine("Invalid note : " + noteName); // Use a real error engine
                return;
            }
            float start = context.startTime.Get<float>();
            float duration = context.duration.Get<float>();
            float velocity = context.velocity.Get<float>();

            SheetNote sheetNote = new SheetNote(note.Number, start, start + duration, velocity);
            Notes.Add(sheetNote);
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
                Console.WriteLine("Invalid chord : " + chordName); // Use a real error engine
                return;
            }

            foreach (var note in chord.Notes)
            {
                SheetNote sheetNote = new SheetNote(note.Number, start, start + duration, velocity);
                Notes.Add(sheetNote);
            }
        }

    }
}
