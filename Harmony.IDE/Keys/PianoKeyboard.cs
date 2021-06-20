using Harmony.Audio;
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

        public static readonly Dictionary<NoteId, float> KeysOffsets = new Dictionary<NoteId, float>()
        {
            { NoteId.A, Constants.WhiteSize.X/2 -Constants.BlackSize.X/2 },
            { NoteId.ASharp,Constants.WhiteSize.X/2+Constants.BlackSize.X/2 },
            { NoteId.B,Constants.BlackSize.X/2},
            { NoteId.C,Constants.WhiteSize.X },
            { NoteId.CSharp,Constants.WhiteSize.X - Constants.BlackSize.X/2 },
            { NoteId.D,Constants.BlackSize.X/2 },
            { NoteId.DSharp,Constants.WhiteSize.X -Constants.BlackSize.X/2 },
            { NoteId.E,Constants.BlackSize.X/2 },
            { NoteId.F,Constants.WhiteSize.X },
            { NoteId.FSharp,Constants.WhiteSize.X -Constants.BlackSize.X/2 },
            { NoteId.G,Constants.BlackSize.X/2f},
            { NoteId.GSharp,Constants.WhiteSize.X -Constants.BlackSize.X/2f },
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

        public InstrumentPlayer InstrumentPlayer
        {
            get;
            private set;
        }

        public PianoKeyboard(Vector2f position)
        {
            this.Position = position;

            this.Keys = new Dictionary<int, Key>();

            this.SelectedKeys = new List<Key>();

            Vector2f keyPosition = Position;

            foreach (var note in NotesManager.GetNotes())
            {
                keyPosition += new Vector2f(KeysOffsets[note.Id], 0);
                Key key = new Key(note, keyPosition);
                Keys.Add(note.Number, key);
            }

            this.InstrumentPlayer = new InstrumentPlayer();

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


        public Key GetKey(int number)
        {
            return Keys[number];
        }
        public Vector2f GetSize()
        {
            return new Vector2f(Constants.WhiteSize.X * Keys.Values.Where(x => !x.Note.Sharp).Count() + 2, Constants.WhiteSize.Y);
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
        public void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left && HoveredKey != null)
            {
                OnKeyPressed?.Invoke(HoveredKey);
            }
        }

        public void DisplayKeyMetadata()
        {
            foreach (var key in Keys)
            {
                key.Value.DrawMetadata = true;
            }
        }
        public void HideKeyMetadata()
        {
            foreach (var key in Keys)
            {
                key.Value.DrawMetadata = false;
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

            if (HoveredKey != null && !IsSelected(HoveredKey))
            {
                HoveredKey.Fill(Constants.KeyHoverColor);
            }

        }
    }
}
