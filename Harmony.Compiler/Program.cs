using Harmony.Chords;
using Harmony.Notes;
using Harmony.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            NotesManager.Initialize();
            ChordsManager.Initialize(@"C:\Users\Skinz\Desktop\Harmony\Harmony.GUI\bin\Debug\chords.json");

            HarmonyScript script = new HarmonyScript(@"C:\Users\Skinz\Desktop\Harmony\Harmony.GUI\bin\Debug\Test\test.hm");
            script.Read();
            Console.WriteLine("Compile end.");
            Console.ReadLine();
        }
    }
}
