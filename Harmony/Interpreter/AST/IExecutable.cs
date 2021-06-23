using Harmony.Interpreter.AST.Functions;
using Harmony.Notes;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST
{
    public interface IEntity
    {
        float GetDuration();

        float GetTotalDuration();

        void Prepare();

        Function TargetFunction
        {
            get;
            set;
        }
    }
}
