using Harmony.Chords;
using Harmony.Instruments;
using Harmony.Notes;
using Harmony.Sheets;
using Microsoft.Win32;
using NAudio.Midi;
using Harmony.GUI.Rendering;
using Harmony.GUI.SFML;
using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Key = Harmony.GUI.Keys.Key;
using Harmony.GUI.Keys;
using SFML.System;
using System.IO;
using Harmony.Interpreter;

namespace Harmony.GUI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PianoRenderer Renderer
        {
            get;
            set;
        }
        private HarmonyScript Script
        {
            get;
            set;
        }
        private const double FramePerSecond = 60d;

        public MainWindow()
        {
            NotesManager.Initialize();
            ChordsManager.Initialize("chords.json");
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            host.Child = new DrawingSurface();


            InstrumentsManager.Initialize();
        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Renderer = new PianoRenderer(host.Child.Handle);
            Renderer.Keyboard.OnKeyPressed += Keyboard_OnKeyPressed;
            Renderer.Keyboard.OnKeySelected += OnKeySelectionChanged;
            Renderer.Keyboard.OnKeyUnselected += OnKeySelectionChanged;
            Renderer.Flow.OnSheetPlayed += OnSheetPlayed;


            foreach (var chord in ChordsManager.GetChordNames())
            {
                chords.Items.Add(chord);
            }

            foreach (var instrument in InstrumentsManager.GetInstruments())
            {
                instruments.Items.Add(instrument);
            }

            Instrument defaultInstrument = (Instrument)instruments.Items[0];

            Renderer.Keyboard.SetInstrument(defaultInstrument);
            instruments.SelectedItem = defaultInstrument;

            var timer = new HighPrecisionTimer((int)(1000 / FramePerSecond));
            timer.Tick += Timer_Tick;



        }

        private void OnSheetPlayed(Sheet sheet)
        {
            sheetName.Text = sheet.Name;
        }

        private void OnKeySelectionChanged(Key key)
        {
            var keys = Renderer.Keyboard.SelectedKeys.Select(x => x.Note).OrderBy(x => x.Number);
            var chord = ChordsManager.FindChord(keys);

            if (chord != null)
            {
                c.Text = "Chord : " + chord.Name;
            }
            else
            {
                c.Text = "Chord : ?";
            }
        }

        private void Keyboard_OnKeyPressed(Key key)
        {
            float offset = 0f;
            SheetNote sheetNote = new SheetNote(key.Note.Number, offset, offset + 3f, 100f);
            Renderer.Flow.AddNote(sheetNote, 4f);
        }

        private void Timer_Tick(object sender, HighPrecisionTimer.TickEventArgs e)
        {
            if (this.IsVisible)
            {
                Dispatcher.Invoke(() =>
                {
                    Renderer.Loop();
                });
            }
        }


        private void OnPlayClick(object sender, RoutedEventArgs e)
        {

            if (chords.SelectedItem == null)
                return;

            Renderer.Keyboard.UnselectAll();

            var chord = ChordsManager.BuildChord(chords.SelectedItem.ToString(), 3);

            if (chord == null)
            {
                return;
            }

            float offset = 0f;

            foreach (var note in chord.Notes)
            {
                var n2 = NotesManager.AddTone(note, 6);
                SheetNote sheetNote = new SheetNote(n2.Number, offset, offset + 2f, 100f);
                Renderer.Flow.AddNote(sheetNote, 2f);
            }

            offset += 2f;

            for (int octave = 0; octave < 3; octave++)
            {
                foreach (var note in chord.Notes)
                {
                    var n2 = NotesManager.AddTone(note, octave * 6);

                    if (n2 != null)
                    {
                        SheetNote sheetNote = new SheetNote(n2.Number, offset, offset + 1f, 100f);
                        Renderer.Flow.AddNote(sheetNote, 2f);
                        offset += 0.12f;
                    }
                }
            }
        }

        private void chords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chords.SelectedItem == null)
            {
                return;
            }
            var chord = ChordsManager.BuildChord(chords.SelectedItem.ToString(), 4);

            if (chord != null)
            {
                Renderer.Keyboard.UnselectAll();

                foreach (var note in chord.Notes)
                {
                    Renderer.Keyboard.SelectKey(note.Number);
                }
            }
            else
            {
                Renderer.Keyboard.UnselectAll();
            }
        }

        private void chord_TextChanged(object sender, TextChangedEventArgs e)
        {
            var results = ChordsManager.GetChordNames().Where(x => x.ToLower().Contains(chord.Text.ToLower()));
            chords.Items.Clear();

            foreach (var result in results)
            {
                chords.Items.Add(result);
            }
        }

        private void OpenMidiClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MIDI files (*.mid)|*.mid";
            if (dialog.ShowDialog().Value)
            {
                Reset();
                Sheet sheet = Sheet.FromMIDI(dialog.FileName);
                Renderer.Flow.Play(sheet);
            }
        }

        private void instruments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (instruments.SelectedItem != null)
                Renderer.Keyboard.SetInstrument(InstrumentsManager.GetInstrument(instruments.SelectedItem.ToString()));
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void OpenScriptClick(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Harmony Scripts (*.hm)|*.hm";
            if (dialog.ShowDialog().Value)
            {
                HarmonyScript script = new HarmonyScript(dialog.FileName);
                LoadScript(script);
            }
        }

        private void LoadScript(HarmonyScript script)
        {
            Reset();
            Renderer.Flow.Play(script.Sheet);
            this.Script = script;
            this.scriptStatus.Text = "Script : " + script.Sheet.Name;
            this.notesCount.Text = "Notes Count : " + script.Sheet.Notes.Count;
            this.totalDuration.Text = "Total Duration : " + script.Sheet.TotalDuration;
        }

        private void StopClick(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            Renderer.Flow.Notes.Clear();
            Renderer.Keyboard.UnselectAll();
            sheetName.Text = "No sheet loaded";
        }
        private void PauseClick(object sender, RoutedEventArgs e)
        {
            Renderer.Flow.PixelSpeed = 0f;
        }
        private void PlayClick(object sender, RoutedEventArgs e)
        {
            Renderer.Flow.PixelSpeed = 2f;
        }

        private void TransposeDownClick(object sender, RoutedEventArgs e)
        {
            Renderer.Keyboard.UnselectAll();

            if (Renderer.Flow.Notes.All(x => x.SheetNote.Number - 1 > 0))
            {
                foreach (var note in Renderer.Flow.Notes)
                {
                    note.SheetNote.Number -= 1;
                    note.Shape.Position = new Vector2f(Renderer.Keyboard.GetKey(note.SheetNote.Number).Rectangle.Position.X, note.Shape.Position.Y);
                }
            }
        }

        private void TransposeUpClick(object sender, RoutedEventArgs e)
        {
            Renderer.Keyboard.UnselectAll();

            if (Renderer.Flow.Notes.All(x => x.SheetNote.Number + 1 <= 88))
            {
                foreach (var note in Renderer.Flow.Notes)
                {
                    note.SheetNote.Number += 1;
                    note.Shape.Position = new Vector2f(Renderer.Keyboard.GetKey(note.SheetNote.Number).Rectangle.Position.X, note.Shape.Position.Y);
                }
            }
        }

        private void ReloadScriptClick(object sender, RoutedEventArgs e)
        {
            LoadScript(Script);
        }
    }
}