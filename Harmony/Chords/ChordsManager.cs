using Harmony.Extensions;
using Harmony.Notes;
using Newtonsoft.Json;
using Piano.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Harmony.Chords
{
    public class ChordsManager
    {
        private static Dictionary<string, string[]> Chords
        {
            get;
            set;
        }

        private static readonly Dictionary<string, string> ChordsOverride = new Dictionary<string, string>()
        {
            { "+", "aug"},
            {"add2", "add9"},
            {"Bb", "A#" },
            {"Db", "C#" },
            {"Eb", "D#" },
            {"Gb", "F#" },
            {"Ab", "G#" },
        };

        public static void Initialize(string filePath)
        {
            Chords = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(File.ReadAllText(filePath));
        }
        public static Chord FindChord(IEnumerable<Note> notes)
        {
            Chord result = null;

            var c1 = notes.DistinctBy(x => x.Symbol).Select(note => note.Symbol).OrderBy(w => w).ToArray();

            var chord = Chords.FirstOrDefault(x => x.Value.OrderBy(n => n).SequenceEqual(c1));

            if (chord.Key != null)
            {
                result = new Chord();
                result.Notes = notes.ToList();
                result.Name = chord.Key;
            }

            return result;
        }

        private static string[] GetChordNames()
        {
            return Chords.Keys.ToArray();
        }
        public static Chord BuildChord(string chord, int octave)
        {
            foreach (var chordOverride in ChordsOverride)
            {
                chord = chord.Replace(chordOverride.Key, chordOverride.Value);
            }

            var bassRegex = Regex.Match(chord, @"(.*)\/(C#|G#|D#|A#|F#|C|D|E|F|G|A|B)");

            if (bassRegex.Success)
            {
                chord = bassRegex.Groups[1].Value;
            }


            if (!Chords.ContainsKey(chord))
            {
                return null;
            }

            Chord result = new Chord();
            result.Name = chord;

            List<Note> notes = new List<Note>();

            var rawNotes = Chords[chord];


            Note fundamental = NotesManager.GetNote(rawNotes[0].ToString(), octave);
            notes.Add(fundamental);

            for (int i = 1; i < rawNotes.Length; i++)
            {
                var rawNote = rawNotes[i];

                foreach (var note in NotesManager.GetNotes())
                {
                    if (note.Number > notes[i - 1].Number && note.Symbol == rawNote)
                    {
                        notes.Add(note);
                        break;
                    }
                }
            }

            if (bassRegex.Success)
            {
                notes.Add(NotesManager.GetNote(bassRegex.Groups[2].Value, octave - 1));
            }

            result.Notes = notes;
            return result;


        }
    }
}
