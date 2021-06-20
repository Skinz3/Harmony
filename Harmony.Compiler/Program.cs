using Harmony.Chords;
using Harmony.Interpreter.Errors;
using Harmony.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            NotesManager.Initialize();
            ChordsManager.Initialize(@"C:\Users\Skinz\Desktop\Harmony\Harmony.GUI\bin\Debug\chords.json");

            HarmonyScript script = new HarmonyScript(@"C:\Users\Skinz\Desktop\Harmony\Harmony.GUI\bin\Debug\Test\test.hm");
            script.Process();

            foreach (var error in script.Errors)
            {
                switch (error.Type)
                {
                    case ErrorType.Syntaxic:
                        Log(error.ToString(), ConsoleColor.Yellow);
                        break;
                    case ErrorType.Semantic:
                        Log(error.ToString(), ConsoleColor.DarkYellow);
                        break;
                    case ErrorType.Other:
                        Log(error.ToString(), ConsoleColor.Red);
                        break;
                }
            }


            if (script.Errors.Count == 0)
            {
                Log("Compile sucessful.",ConsoleColor.Green);
            }
            Console.ReadLine();
        }
        static void Log(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }
    }
}
