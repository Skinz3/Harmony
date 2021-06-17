using Harmony.Notes;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Compiler.AST
{
    public interface ICompilable
    {
        IEnumerable<SheetNote> GetNotes();

        void Prepare(HarmonyScript script);
    }
}
