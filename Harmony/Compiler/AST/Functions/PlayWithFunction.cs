using Harmony.Compiler.AST.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Compiler.AST.Functions
{
    public class PlayWithFunction : Function
    {
        private Statement Parameter
        {
            get;
            set;
        }
        public PlayWithFunction(Statement parameter)
        {
            this.Parameter = parameter;
        }
        public override void Prepare(HarmonyScript script)
        {
            Parameter.Prepare(script);
        }
    }
}
