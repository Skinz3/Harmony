using Antlr4.Runtime;
using Harmony.Interpreter.AST.Meta;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter.AST.Statements
{
    public class PedalStatement : Statement
    {
        private bool On
        {
            get;
            set;
        }
        public PedalStatement(Unit parent, ParserRuleContext ruleContext, bool on) : base(parent, ruleContext)
        {
            this.On = on;
        }

        public override float GetDuration()
        {
            return 0f;
        }

        protected override List<SheetNote> Execute(ref float time, NoteMetaProvider metaProvider)
        {
            metaProvider.SustainPedal = On;

            return new List<SheetNote>();
        }
    }
}
