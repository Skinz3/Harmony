using Harmony.Chords;
using Harmony.Notes;
using Piano.Rendering;
using Piano.SFML;
using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Key = Piano.Rendering.Key;

namespace Piano
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

        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Renderer = new PianoRenderer(host.Child.Handle);
            Renderer.Keyboard.OnKeyPressed += Keyboard_OnKeyPressed;

            var timer = new HighPrecisionTimer((int)(1000 / FramePerSecond));
            timer.Tick += Timer_Tick;
        }


        private void Keyboard_OnKeyPressed(Key key, bool selected)
        {
            if (selected)
            {
                key.Play();
            }

            var keys = Renderer.Keyboard.SelectedKeys.Select(x => x.Note).OrderBy(x => x.Number);   
            var chord = ChordsManager.FindChord(keys);

            if (chord != null)
            {
                c.Text = "Chord : "+chord.Name;
            }
            else
            {
                c.Text = "Chord : ?";
            }

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
        private void chordName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var chord = ChordsManager.BuildChord(chordName.Text, 3);

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
    }
}
