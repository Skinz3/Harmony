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

        public Editor()
        {
            InitializeComponent();

            AvalonUtils.ApplySyntaxRules("harmony.xshd", textEditor);
            this.Loaded += OnLoad;
            this.KeyDown += OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                host.Focus();
                Save();
            }
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            host.Child = new DrawingSurface();
            host.SizeChanged += Host_SizeChanged;

            var settings = new SFML.Window.ContextSettings();
            settings.AntialiasingLevel = 7;

            Renderer = new HarmonyRenderer(host.Child.Handle, settings);

            Renderer.Keyboard.InstrumentPlayer.DefineInstrument(InstrumentsManager.GetInstrument("Concert Grand"));

            RestoreScript();

            var timer = new HighPrecisionTimer((int)(1000d / Constants.FramerateLimit));
            timer.Tick += OnTick;

        }


        private void RestoreScript()
        {
            if (File.Exists(ConfigManager.Instance.ScriptPath))
            {
                string text = File.ReadAllText(ConfigManager.Instance.ScriptPath);
                HarmonyScript script = new HarmonyScript(text);
                LoadScript(script);
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
                    UpdateTime();
                    Renderer.Loop();
                });
            }
        }

        private void ExitClick(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void GridSplitter_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            host.Visibility = Visibility.Hidden;
        }

        private void GridSplitter_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            host.Visibility = Visibility.Visible;

            Point relativePoint = splitter.TransformToAncestor(grid)
                              .Transform(new Point(0, 0));

            host.Height = (relativePoint.Y);

            Renderer.RecreateWindow(host.Child.Handle);
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (drawMeta.IsChecked.Value)
            {
                Renderer.Keyboard.DisplayKeyMetadata();
            }
            else
            {
                Renderer.Keyboard.HideKeyMetadata();
            }
        }


        [WIP("temporary")]
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var sheet = Sheet.FromMIDI(@"ex.mid");

            sheet.Tempo = 60;

            Renderer.Load(sheet);
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
            this.ConfigurationWindow = new Configuration();
            ConfigurationWindow.Show();
        }

        private void LoadScript(HarmonyScript script)
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

            textEditor.Text = script.Text;

            if (script.Errors.Count == 0)
            {
                scriptName.Content = "Script : " + script.Name;
                Renderer.Load(script.Sheet);
                UpdateTime();
            }
        }
        private void UpdateTime()
        {
            if (Renderer.Flow.SheetPlayer.Sheet == null)
            {
                return;
            }

            TimeSpan position = TimeSpan.FromSeconds(Renderer.Flow.SheetPlayer.Position);
            TimeSpan totalDuration = TimeSpan.FromSeconds(Renderer.Flow.SheetPlayer.Sheet.TotalDuration);

            if (!timeSlider.IsMouseOver)
            {
                timeSlider.Maximum = totalDuration.TotalSeconds;
                timeSlider.Value = position.TotalSeconds;
            }
            time.Content = position.ToString(@"mm\:ss") + " / " + totalDuration.ToString(@"mm\:ss");
        }
        private void CompileClick(object sender, RoutedEventArgs e)
        {
            string text = textEditor.Text;
            HarmonyScript script = new HarmonyScript(text);
            LoadScript(script);
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
                LoadScript(script);

                ConfigManager.Instance.ScriptPath = dialog.FileName;
                ConfigManager.Save();
            }
        }

        private void Save()
        {
            if (File.Exists(ConfigManager.Instance.ScriptPath))
            {
                string text = textEditor.Text;
                File.WriteAllText(ConfigManager.Instance.ScriptPath, text);
                MessageBox.Show("Script saved.", "Informations", MessageBoxButton.OK, MessageBoxImage.Asterisk);
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
            Save();
        }

        private void SaveAsClick(object sender, RoutedEventArgs e)
        {
            SaveAs();
        }

        private void Minimize(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void timeSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if (Renderer.Flow.SheetPlayer.Sheet != null)
            {
                Renderer.Snap((float)timeSlider.Value);
            }
        }
    }
}
