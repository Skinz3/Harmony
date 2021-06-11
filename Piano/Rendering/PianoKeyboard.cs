using Harmony.Notes;
using Piano.SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano.Rendering
{
    public class PianoKeyboard : IDrawable
    {
        public delegate void OnKeyPressedDelegate(Key key, bool selected);

        public event OnKeyPressedDelegate OnKeyPressed;

        public static readonly Color BlackColor = new Color(70, 70, 70);

        public static readonly Color WhiteColor = Color.White;

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
        private Vector2f Position
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
            var key = Keys.FirstOrDefault(x => x.Value.Note.Number == number).Value;
            SelectKey(key);
        }

        public void UnselectAll()
        {
            foreach (var key in Keys.Values)
            {
                UnselectKey(key);
            }
        }

        private void SelectKey(Key key)
        {
            key.Fill(new Color(100, 149, 237));
            SelectedKeys.Add(key);
            OnKeyPressed?.Invoke(key, true);
        }
        private void UnselectKey(Key key)
        {
            key.UnFill();
            SelectedKeys.Remove(key);
            OnKeyPressed?.Invoke(key, false);

        }
        private void RenderWindow_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left && HoveredKey != null)
            {
                if (!IsSelected(HoveredKey))
                {
                    SelectKey(HoveredKey);
                }
                else
                {
                    UnselectKey(HoveredKey);
                }


            }
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
