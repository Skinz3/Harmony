using Antlr4.Runtime;
using Harmony.Interpreter.AST.Functions;
using Harmony.Interpreter.AST.Meta;
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

        float GetRightDuration();

        float GetLeftDuration();

        void Prepare();

        ParserRuleContext Context
        {
            get;
            set;
        }
        Function TargetFunction
        {
            get;
            set;
        }


    }
}
