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
    public class Unit : IExecutable
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

        public List<SheetNote> Execute(ref float time)
        {
            List<SheetNote> results = new List<SheetNote>();

            foreach (var statement in Statements)
            {
                var result = statement.Execute(ref time);

                foreach (var function in statement.Functions)
                {
                    function.Apply(result);
                }

                results.AddRange(result);
            }

            return results;
        }

        public float GetDuration()
        {
            return Statements.Sum(x => x.GetDuration());
        }

        
    }
}
