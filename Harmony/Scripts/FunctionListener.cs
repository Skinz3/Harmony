using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Scripts
{
    public class FunctionListener : HarmonyParserBaseListener
    {
        private List<SheetNote> Notes
        {
            get;
            set;
        }

        public FunctionListener(List<SheetNote> notes)
        {
            this.Notes = notes;
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

            foreach (var note in Notes)
            {
                note.Number += value;
            }
        }
        public override void EnterPropagateFunction([NotNull] HarmonyParser.PropagateFunctionContext context)
        {
            int amount = context.amount.Get<int>();

            foreach (var note in Notes.ToArray())
            {
                for (int i = 1; i < amount; i++)
                {
                    var newNote = new SheetNote(note.Number + 12 * i, note.Start, note.End, note.Velocity);
                    Notes.Add(newNote);
                }
            }
        }
        public override void EnterArpeggiateFunction([NotNull] HarmonyParser.ArpeggiateFunctionContext context)
        {
            float shift = context.offset.Get<float>();

            int i = 0;

            foreach (var note in Notes.ToArray())
            {
                note.Start += i * shift;
                note.End += i * shift;
                i++;
            }
        }
    }
}
