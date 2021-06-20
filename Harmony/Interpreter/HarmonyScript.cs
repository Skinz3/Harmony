﻿using Antlr4.Runtime;
using Harmony.Interpreter.AST;
using Harmony.Interpreter.Errors;
using Harmony.Sheets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter
{
    public class HarmonyScript
    {
        private const string MainUnitName = "main";

        public const string Extension = ".hm";

        public CompilerErrors Errors
        {
            get;
            private set;
        }
        public string Text
        {
            get;
            private set;
        }
        public HarmonyScript(string text)
        {
            this.Text = text;
            this.Errors = new CompilerErrors();
            this.Units = new List<Unit>();
            this.Process();
        }

        public List<Unit> Units
        {
            get;
            private set;
        }

        public Unit MainUnit
        {
            get;
            private set;
        }
        public float TotalDuration
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public int Tempo
        {
            get;
            set;
        }

        public float BarDuration => (60f / Tempo) * 4f;

        public Sheet Sheet
        {
            get;
            private set;
        }

        private bool Process()
        {
            var inputStream = new AntlrInputStream(Text);
            var lexer = new HarmonyLexer(inputStream);
            lexer.RemoveErrorListener(ConsoleErrorListener<int>.Instance);

            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new HarmonyParser(commonTokenStream);
            parser.RemoveErrorListener(ConsoleErrorListener<IToken>.Instance);
            parser.AddErrorListener(Errors);

            HarmonyParser.CompilationUnitContext ectx = parser.compilationUnit();

            ScriptListener listener = new ScriptListener(Errors);
            ectx.EnterRule(listener);


            this.Units = listener.Units;
            this.MainUnit = GetUnit(MainUnitName);

            if (MainUnit == null)
            {
                Errors.Error(ErrorType.Other, "Unable to find main unit.");
            }

            Prepare();

            this.TotalDuration = listener.TotalDuration;
            this.Name = listener.Name;
            this.Tempo = listener.Tempo;

            BuildSheet();

            return true;
        }
        private void Prepare()
        {
            foreach (var unit in Units)
            {
                unit.Prepare(this);
            }
        }
        public Unit GetUnit(string name)
        {
            return Units.FirstOrDefault(x => x.Name == name);
        }


        private void BuildSheet()
        {
            if (Errors.Count == 0)
            {
                this.Sheet = new Sheet();
                this.Sheet.Tempo = this.Tempo;
                this.Sheet.Name = this.Name;

                float time = 0;
                this.Sheet.Notes = MainUnit.Execute(ref time).ToList();
                this.Sheet.TotalDuration = time;
            }
        }



    }
}