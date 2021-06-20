using Harmony.IDE.Avalon;
using Harmony.Instruments;
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
using Harmony.Notes;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Harmony.IDE.Rendering;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Document;
using Harmony.IDE.Keys;
using Key = Harmony.IDE.Keys.Key;
using Harmony.Sheets;
using Harmony.DP;
using Harmony.Interpreter;
using System.IO;
using Microsoft.Win32;
using Harmony.Interpreter.Errors;
using Harmony.Chords;

namespace Harmony.IDE
{

    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int FramePerSecond = 60;

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

        public MainWindow()
        {
            InitializeComponent();
            NotesManager.Initialize();
            ChordsManager.Initialize("chords.json");
            ConfigManager.Initialize();
            InstrumentsManager.Initialize();
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

            Renderer.Keyboard.InstrumentPlayer.DefineInstrument(InstrumentsManager.GetInstrument("Reverb Concert Grand"));

            RestoreScript();

            var timer = new HighPrecisionTimer((int)(1000d / FramePerSecond));
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
            Sheet sheet = new Sheet();
            sheet.TotalDuration = 8f;

            sheet.Tempo = 50;

            sheet.Notes.Add(new SheetNote(55, 2f, 4f, 100f));

            sheet = Sheet.FromMIDI(@"C:\Users\Skinz\Desktop\Harmony\Harmony.GUI\bin\Debug\Test\Chopin.mid");

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
                Renderer.Load(script.Sheet);
            }
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
    }
}
