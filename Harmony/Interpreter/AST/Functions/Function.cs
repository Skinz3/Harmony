using Harmony.Notes;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST.Functions
{
    public abstract class Function
    {
        public abstract void Apply(List<SheetNote> notes);

        public abstract void Prepare(HarmonyScript script);

    }
}
