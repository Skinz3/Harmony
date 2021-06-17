using Harmony.Notes;
using Harmony.Compiler.AST.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony.Sheets;

namespace Harmony.Compiler.AST
{
    public class Unit : ICompilable
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
        public Unit()
        {
            this.Statements = new List<Statement>();
        }

        public IEnumerable<SheetNote> GetNotes()
        {
            List<SheetNote> results = new List<SheetNote>();

            foreach (var statement in Statements)
            {
                results.AddRange(statement.GetNotes());
            }

            return results;
        }

        public void Prepare(HarmonyScript script)
        {
            foreach (var statement in Statements)
            {
                statement.Prepare(script);
            }
        }
    }
}
