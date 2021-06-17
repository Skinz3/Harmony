using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Compiler.AST.Functions
{
    public class PropagateFunction : Function
    {
        private int Delta
        {
            get;
            set;
        }

        public PropagateFunction(int delta)
        {
            this.Delta = delta;
        }

        public override void Prepare(HarmonyScript script)
        {
            
        }
    }
}
