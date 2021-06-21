using Harmony.Notes;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST
{
    public interface IExecutable
    {
        List<SheetNote> Execute(ref float time);

        void Prepare();
    }
}
