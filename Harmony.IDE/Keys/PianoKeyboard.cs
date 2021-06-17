using Harmony.IDE.Rendering;
using Harmony.Instruments;
using Harmony.Notes;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.IDE.Keys
{
    public class PianoKeyboard : IDrawable
    {
        public delegate void KeyPressedDelegate(Key key);

        public event KeyPressedDelegate OnKeyPressed;

        public delegate void KeySelectionDelegate(Key key);

        public event KeySelectionDelegate OnKeySelected;

        public event KeySelectionDelegate OnKeyUnselected;

        public static readonly Vector2f BlackSize = new Vector2f(18, 80);

        public static readonly Vector2f WhiteSize = new Vector2f(36, 130);

        public static readonly Dictionary<NoteId, float> KeysOffsets = new Dictionary<NoteId, float>()
        {
            { NoteId.A, WhiteSize.X/2 -BlackSize.X/2 },
            { NoteId.ASharp,WhiteSize.X/2+BlackSize.X/2 },
            { NoteId.B,BlackSize.X/2},
            { NoteId.C,WhiteSize.X },
            { NoteId.CSharp,WhiteSize.X - BlackSize.X/2 },
            { NoteId.D,BlackSize.X/2 },
            { NoteId.DSharp,WhiteSize.X -BlackSize.X/2 },
            { NoteId.E,BlackSize.X/2 },
            { NoteId.F,WhiteSize.X },
            { NoteId.FSharp,WhiteSize.X -BlackSize.X/2 },
            { NoteId.G,BlackSize.X/2f},
            { NoteId.GSharp,WhiteSize.X -BlackSize.X/2f },
        };

        public List<Key> SelectedKeys
        {
            get;
            private set;
        }

        public Dictionary<int, Key> Keys
        {
            get;
            private set;
        }

        private Key HoveredKey
        {
            get;
            set;
        }
        public Vector2f Position
        {
            get;
            private set;
        }
        private Instrument Instrument
        {
            get;
            set;
        }
        public PianoKeyboard(Window renderWindow, Vector2f position)
        {
            this.Position = position;

            this.Keys = new Dictionary<int, Key>();

            this.SelectedKeys = new List<Key>();

            Vector2f keyPosition = Position;

            foreach (var note in NotesManager.GetNotes())
            {
                Vector2f size = note.Sharp ? BlackSize : WhiteSize;

                keyPosition += new Vector2f(KeysOffsets[note.Id], 0);

                Key key = new Key(note, keyPosition, size);

                Keys.Add(note.Number, key);
            }

            renderWindow.MouseButtonPressed += RenderWindow_MouseButtonPressed;
        }

        public void SelectKey(int number)
        {
            var key = Keys[number];
            SelectKey(key);
        }
        public void UnselectKey(int number)
        {
            var key = Keys[number];
            UnselectKey(key);
        }

        public void UnselectAll()
        {
            foreach (var key in Keys.Values)
            {
                UnselectKey(key);
            }
        }

        public void SetInstrument(Instrument instrument)
        {
            this.Instrument = instrument;

            foreach (var key in Keys.Values)
            {
                key.DestroySound();

                InstrumentNote instrumentNote = Instrument.GetNote(key.Note.ToString());

                if (instrumentNote != null)
                {
                    key.SetSound(instrumentNote.WavFile);
                }
            }
        }
        public Key GetKey(int number)
        {
            return Keys[number];
        }
        public Vector2f GetSize()
        {
            return new Vector2f(WhiteSize.X * Keys.Values.Where(x => !x.Note.Sharp).Count() + 2, WhiteSize.Y);
        }
        public void SelectKey(Key key)
        {
            if (!key.Note.Sharp)
            {
                key.Fill(Constants.WhiteKeySelectedColor);
            }
            else
            {
                key.Fill(Constants.BlackKeySelectedColor);
            }

            SelectedKeys.Add(key);
            OnKeySelected?.Invoke(key);

        }
        public void UnselectKey(Key key)
        {
            key.UnFill();
            SelectedKeys.Remove(key);
            OnKeyUnselected?.Invoke(key);

        }
        private void RenderWindow_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left && HoveredKey != null)
            {
                OnKeyPressed?.Invoke(HoveredKey);
            }
        }

        public bool IsSelected(int noteNumber)
        {
            return SelectedKeys.Any(x => x.Note.Number == noteNumber);
        }
        public bool IsSelected(Key key)
        {
            return SelectedKeys.Contains(key);
        }

        public void Draw(RenderWindow window)
        {
            var mousePosition = Mouse.GetPosition(window);

            var position = window.MapPixelToCoords(new Vector2i(mousePosition.X, mousePosition.Y));

            IEnumerable<Key> orderedKeys = Keys.Values.OrderByDescending(x => !x.Note.Sharp);


            foreach (var key in orderedKeys)
            {
                key.Draw(window);
            }

            orderedKeys = orderedKeys.Reverse();

            if (HoveredKey != null && !IsSelected(HoveredKey))
            {
                HoveredKey?.UnFill();
            }

            HoveredKey = orderedKeys.FirstOrDefault(x => x.Contains(position));


            if (!IsSelected(HoveredKey))
            {
                HoveredKey?.Fill(new Color(118, 167, 255));
            }




        }
    }
}
