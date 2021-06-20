using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST.Functions
{
    public class ArpeggiateFunction : Function
    {
        private float Delta
        {
            get;
            set;
        }
        public ArpeggiateFunction(float delta)
        {
            this.Delta = delta;
        }

        public override void Prepare(HarmonyScript script)
        {
           
        }

        public override void Apply(List<SheetNote> notes)
        {
            throw new NotImplementedException();
        }
    }
}
