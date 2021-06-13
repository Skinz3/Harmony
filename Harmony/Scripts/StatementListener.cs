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
        private HarmonyScript Script
        {
            get;
            set;
        }
        public StatementListener(HarmonyScript script)
        {
            this.Script = script;
        }
        public override void EnterStatement([NotNull] HarmonyParser.StatementContext context)
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
            string noteName = context.note().GetText();

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
            Script.Sheet.Notes.Add(sheetNote);
        }

    }
}
