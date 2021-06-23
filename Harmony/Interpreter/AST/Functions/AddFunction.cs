using Harmony.Interpreter.AST.Statements;
using Harmony.Notes;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST.Functions
{
    public class AddFunction : Function
    {
        private Note Target
        {
            get;
            set;
        }
        public AddFunction(IEntity parent, Note target) : base(parent)
        {
            this.Target = target;
        }

        public override float GetDuration()
        {
            return 0f;
        }

        public override void Prepare()
        {
            
        }

        protected override void Execute(ref float time, List<SheetNote> notes)
        {
            var firstNote = notes.First();

            notes.Add(new SheetNote(Target.Number, firstNote.Start, firstNote.End, firstNote.Velocity));
        }
    }
}
