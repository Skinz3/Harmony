using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Notes
{
    public class NotesManager
    {
        private const int NotesCount = 88;

        private static Dictionary<int, Note> _notes = new Dictionary<int, Note>();

        public static void Initialize()
        {
            NoteId[] notes = (NoteId[])Enum.GetValues(typeof(NoteId));

            int octave = 0;

            for (int n = 0; n < NotesCount; n++)
            {
                int symbolIndex = n % notes.Length;

                if (symbolIndex == 3)
                {
                    octave++;
                }

                int noteNumber = n + 1;

                var symbol = notes.ElementAt(symbolIndex);

                Note note = new Note(symbol, octave, noteNumber);

                _notes.Add(noteNumber, note);
            }
        }

        public static Note AddTone(Note note, float tone)
        {
            int index = note.Number + (int)(tone * 2);

            if (!_notes.ContainsKey(index))
            {
                return null;
            }
            return _notes[index];
        }
        public static Note GetNote(string symbol,int octave)
        {
            return _notes.Values.FirstOrDefault(x => x.Symbol == symbol && x.Octave == octave);
        }
        public static IEnumerable<Note> GetNotes()
        {
            return _notes.Values;
        }
    }
}
