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



            foreach (var chord in ChordsManager.GetChordNames())
            {
                chords.Items.Add(chord);
            }

            foreach (var instrument in InstrumentsManager.GetInstrumentNames())
            {
                instruments.Items.Add(instrument);
            }

            string defaultInstrument = instruments.Items[0].ToString();

            Renderer.Keyboard.SetInstrument(InstrumentsManager.GetInstrument(defaultInstrument));
            instruments.SelectedItem = defaultInstrument;

            var timer = new HighPrecisionTimer((int)(1000 / FramePerSecond));
            timer.Tick += Timer_Tick;



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
            float offset = -6f;
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



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Renderer.Keyboard.UnselectAll();

            var chord = ChordsManager.BuildChord(chords.SelectedItem.ToString(), 3);

            if (chord == null)
            {
                return;
            }

            float offset = -5f;

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
                Sheet sheet = new Sheet(dialog.FileName);
                sheet.Open();
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
            dialog.Filter = "MIDI files (*.mid)|*.mid";
            if (dialog.ShowDialog().Value)
            {
                Sheet sheet = new Sheet(dialog.FileName);
                sheet.Open();
                Renderer.Flow.Play(sheet);
            }
        }
    }
}
