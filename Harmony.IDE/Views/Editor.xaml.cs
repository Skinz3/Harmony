using Harmony.Chords;
using Harmony.DP;
using Harmony.IDE.Avalon;
using Harmony.IDE.Rendering;
using Harmony.Instruments;
using Harmony.Interpreter;
using Harmony.Interpreter.Errors;
using Harmony.Notes;
using Harmony.Sheets;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Harmony.IDE.Views
{
    /// <summary>
    /// Logique d'interaction pour Editor.xaml
    /// </summary>
    public partial class Editor : UserControl
    {
        private HarmonyRenderer Renderer
        {
            get;
            set;
        }

        private Configuration ConfigurationWindow
        {
            get;
            set;
        }

        private Thumb TimeSliderThumb
        {
            get;
            set;
        }

        private DateTime? LastTimeEdit
        {
            get;
            set;
        }

        public Editor()
        {
            InitializeComponent();

            host.Child = new DrawingSurface();
            host.SizeChanged += Host_SizeChanged;
            AvalonUtils.ApplySyntaxRules("harmony.xshd", textEditor);

            this.KeyDown += OnKeyDown;


            mainPanel.MouseDown += (s, e) =>
            {
                var window = Window.GetWindow(this);


                if (window != null && window.WindowState != WindowState.Maximized)
                {
                    window.DragMove();
                }
            };

            var settings = new SFML.Window.ContextSettings();
            settings.AntialiasingLevel = 7;

            Renderer = new HarmonyRenderer(host.Child.Handle, settings);

            this.TimeSliderThumb = GetThumb(timeSlider);

            RestoreScript();

            var timer = new HighPrecisionTimer((int)(1000d / Constants.FramerateLimit));
            timer.Tick += OnTick;

            if (ConfigManager.Instance.DisplayKeyMetadata)
            {
                Renderer.Keyboard.DisplayKeyMetadata();
            }
            else
            {
                Renderer.Keyboard.HideKeyMetadata();
            }

            foreach (var chord in ChordsManager.GetChordNames())
            {
                chords.Items.Add(chord);
            }

            textEditor.TextArea.Caret.PositionChanged += Caret_PositionChanged;
            textEditor.TextChanged += TextEditor_TextChanged;

            Renderer.Keyboard.OnKeyPressed += OnKeyPressed;

        }

        private void OnKeyPressed(Keys.Key key)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                textEditor.Document.Insert(textEditor.CaretOffset, key.Note.ToString() + ",");
            }
        }

        private void TextEditor_TextChanged(object sender, EventArgs e)
        {
            LastTimeEdit = DateTime.Now;
        }

        private void Compile()
        {
            Renderer.Flow.Pause();
            string text = textEditor.Text;
            HarmonyScript script = new HarmonyScript(text);
            LoadScript(script, false);


            if (script.Errors.Count == 0)
            {
                SnapToConcernedLine();

                Renderer.Flow.Play();
            }
            else
            {
                Renderer.Flow.Pause();
            }

        }
        private void Caret_PositionChanged(object sender, EventArgs e)
        {
            LastTimeEdit = DateTime.Now;

        }
        private void SnapToConcernedLine()
        {
            var line = textEditor.TextArea.Caret.Position.Line;

            var notes = Renderer.Flow.Notes.Where(x => x.SheetNote.Entity.Context.Start.Line == line || x.SheetNote.Entity.Context.Stop.Line == line);


            foreach (var note in Renderer.Flow.Notes)
            {
                note.Shape.OutlineColor = SFML.Graphics.Color.Transparent;

            }

            if (notes.Count() > 0)
            {
                Renderer.Flow.Snap(notes.First().SheetNote.Start - 2f);

                foreach (var note in notes)
                {
                    note.Shape.OutlineColor = SFML.Graphics.Color.White;
                    note.Shape.OutlineThickness = 2f;
                }
            }


        }

        public bool LoadInstrument()
        {
            Instrument instrument = InstrumentsManager.GetInstrument(ConfigManager.Instance.Instrument);

            if (instrument == null)
            {
                var defaultInstrument = InstrumentsManager.GetInstruments().FirstOrDefault();

                if (defaultInstrument == null)
                {
                    return false;
                }

                instrument = defaultInstrument;
                ConfigManager.Instance.Instrument = defaultInstrument.Name;
                ConfigManager.Save();
            }
            Renderer.Keyboard.InstrumentPlayer.DefineInstrument(instrument);

            return true;
        }

        private static Thumb GetThumb(Slider slider)
        {
            var track = slider.Template.FindName("PART_Track", slider) as Track;
            return track == null ? null : track.Thumb;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                host.Focus();
                Save(true);
            }
        }

        private void RestoreScript()
        {
            if (File.Exists(ConfigManager.Instance.ScriptPath))
            {
                string text = File.ReadAllText(ConfigManager.Instance.ScriptPath);
                HarmonyScript script = new HarmonyScript(text);
                LoadScript(script, true);
            }
        }


        private void Host_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (host.Visibility == Visibility.Visible)
            {
                Renderer.RecreateWindow(host.Child.Handle);
            }
        }

        private void OnTick(object sender, HighPrecisionTimer.TickEventArgs e)
        {
            if (this.IsVisible)
            {
                Dispatcher.Invoke(() =>
                {
                    if (LastTimeEdit.HasValue && (DateTime.Now - LastTimeEdit).Value.TotalSeconds > 1)
                    {
                        Compile();
                        LastTimeEdit = null;
                    }
                    UpdateTime();
                    Renderer.Loop();
                });
            }
        }

        private void ExitClick(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void GridSplitter_DragStarted(object sender, DragStartedEventArgs e)
        {
            host.Visibility = Visibility.Hidden;
        }

        private void GridSplitter_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            host.Visibility = Visibility.Visible;

            Point relativePoint = splitter.TransformToAncestor(grid)
                              .Transform(new Point(0, 0));

            host.Height = (relativePoint.Y);

            Renderer.RecreateWindow(host.Child.Handle);
        }


        private void PauseClick(object sender, RoutedEventArgs e)
        {
            Renderer.Flow.Pause();
        }

        private void PlayClick(object sender, RoutedEventArgs e)
        {
            Renderer.Flow.Play();
        }

        private void PreferencesClick(object sender, RoutedEventArgs e)
        {
            ConfigurationWindow?.Close();
            this.ConfigurationWindow = new Configuration(Renderer);
            ConfigurationWindow.Show();
        }

        private void LoadScript(HarmonyScript script, bool loadText)
        {
            scriptErrors.Items.Clear();

            foreach (var error in script.Errors)
            {
                Label label = new Label();
                label.Content = error;

                switch (error.Type)
                {
                    case ErrorType.Semantic:
                    case ErrorType.Syntaxic:
                        label.Foreground = Brushes.Red;
                        break;
                    case ErrorType.Other:
                        label.Foreground = Brushes.Orange;
                        break;
                    default:
                        break;
                }

                scriptErrors.Items.Add(label);
            }

            if (loadText)
            {
                textEditor.Text = script.Text;
            }

            if (script.Errors.Count == 0)
            {
                scriptName.Content = "Script : " + script.Name + " (" + script.Sheet.Notes.Count + " notes)";
                Renderer.Load(script.Sheet);
                UpdateTime();
            }
        }

        private void UpdateTime()
        {
            if (TimeSliderThumb != null && TimeSliderThumb.IsDragging)
            {
                return;
            }
            if (Renderer.Flow.SheetPlayer.Sheet == null)
            {
                return;
            }

            TimeSpan position = TimeSpan.FromSeconds(Renderer.Flow.SheetPlayer.Position);
            TimeSpan totalDuration = TimeSpan.FromSeconds(Renderer.Flow.SheetPlayer.Sheet.TotalDuration);
            timeSlider.Maximum = totalDuration.TotalSeconds;
            timeSlider.Value = position.TotalSeconds;
            time.Content = position.ToString(@"mm\:ss") + " / " + totalDuration.ToString(@"mm\:ss");
        }
        private void CompileClick(object sender, RoutedEventArgs e)
        {
            string text = textEditor.Text;
            HarmonyScript script = new HarmonyScript(text);
            LoadScript(script, false);
            Renderer.Flow.Play();
        }

        private void OpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Harmony Scripts (*.hm)|*.hm";
            if (dialog.ShowDialog().Value)
            {
                string text = File.ReadAllText(dialog.FileName);
                HarmonyScript script = new HarmonyScript(text);
                LoadScript(script, true);

                ConfigManager.Instance.ScriptPath = dialog.FileName;
                ConfigManager.Save();
            }
        }

        private void Save(bool notify)
        {
            if (File.Exists(ConfigManager.Instance.ScriptPath))
            {
                string text = textEditor.Text;
                File.WriteAllText(ConfigManager.Instance.ScriptPath, text);

                if (notify)
                {
                    MessageBox.Show("Script saved.", "Informations", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            else
            {
                SaveAs();
            }
        }
        private void SaveAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Harmony Scripts (*.hm)|*.hm";

            if (dialog.ShowDialog().Value)
            {
                ConfigManager.Instance.ScriptPath = dialog.FileName;
                ConfigManager.Save();

                string text = textEditor.Text;
                File.WriteAllText(ConfigManager.Instance.ScriptPath, text);
                MessageBox.Show("Script saved.");
            }
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            Save(true);
        }

        private void SaveAsClick(object sender, RoutedEventArgs e)
        {
            SaveAs();
        }

        private void Minimize(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void Maximize(object sender, MouseButtonEventArgs e)
        {
            var window = Window.GetWindow(this);

            if (window.WindowState == WindowState.Maximized)
            {
                double screenWidth = SystemParameters.PrimaryScreenWidth;
                double screenHeight = SystemParameters.PrimaryScreenHeight;
                double windowWidth = this.Width;
                double windowHeight = this.Height;
                window.Left = (screenWidth / 2) - (windowWidth / 2);
                window.Top = (screenHeight / 2) - (windowHeight / 2);

                window.WindowState = WindowState.Normal;
            }
            else
            {
                window.WindowState = WindowState.Maximized;
            }
        }
        [WIP("temporary")]
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var sheet = Sheet.FromMIDI(@"ex.mid");

            sheet.Tempo = 60;

            foreach (var note in sheet.Notes)
            {
                //  note.Number++;
            }
            Renderer.Load(sheet);
        }


        private void timeSlider_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            if (Renderer.Flow.SheetPlayer.Sheet != null)
            {
                Renderer.Snap((float)timeSlider.Value);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Renderer.Flow.SheetPlayer.Sheet != null)
            {
                Renderer.Snap(Renderer.Flow.SheetPlayer.Position + 3f);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Renderer.Flow.SheetPlayer.Sheet != null)
            {
                Renderer.Snap(Renderer.Flow.SheetPlayer.Position - 3f);
            }
        }

        private void chords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chords.SelectedItem == null)
            {
                return;
            }
            Renderer.Flow.SheetPlayer.InstrumentPlayer.Stop();
            Renderer.Flow.Pause();
            Renderer.Keyboard.UnselectAll();

            var chord = ChordsManager.BuildChord(chords.SelectedItem.ToString(), 4);

            foreach (var note in chord.Notes)
            {
                Renderer.Keyboard.SelectKey(note.Number);
                Renderer.Flow.SheetPlayer.InstrumentPlayer.Play(note.Number, 100f);
            }
        }

        private void chord_TextChanged(object sender, TextChangedEventArgs e)
        {

            chords.Items.Clear();

            foreach (var chord in ChordsManager.GetChordNames().Where(x => x.ToLower().Contains(chord.Text.ToLower())))
            {
                chords.Items.Add(chord);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AvalonUtils.ApplySyntaxRules("harmony.xshd", textEditor);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Renderer.Keyboard.UnselectAll();
            Renderer.Clear();
            ConfigManager.Instance.ScriptPath = string.Empty;
            textEditor.Text = string.Empty;
        }
    }
}
