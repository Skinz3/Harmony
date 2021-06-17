using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Compiler.AST.Functions
{
    public abstract class Function 
    {
        public abstract void Prepare(HarmonyScript script);
    }
}
