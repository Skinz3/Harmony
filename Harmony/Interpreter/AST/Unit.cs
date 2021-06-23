using Harmony.Notes;
using Harmony.Interpreter.AST.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony.Sheets;

namespace Harmony.Interpreter.AST
{
    public class Unit  
    {
        public string Name
        {
            get;
            set;
        }
        public List<Statement> Statements
        {
            get;
            private set;
        }
        public HarmonyScript Script
        {
            get;
            private set;
        }
        public Unit(HarmonyScript script)
        {
            this.Script = script;
            this.Statements = new List<Statement>();
        }
        public void Prepare()
        {
            foreach (var statement in Statements)
            {
                statement.Prepare();
            }
        }

        public List<SheetNote> Apply(ref float time)
        {
            List<SheetNote> results = new List<SheetNote>();

            foreach (var statement in Statements)
            {
                var result = statement.Apply(ref time);
                results.AddRange(result);
            }

            return results;
        }

        public float GetSteppedDuration()
        {
            float result = Statements.OfType<StepStatement>().Sum(x => x.GetRightDuration());

            return result;
        }
        public float GetTotalDuration()
        {
            float result = Statements.Sum(x => x.GetRightDuration());

            return result;
        }


    }
}
