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

        public MainWindow()
        {
            InitializeComponent();
            NotesManager.Initialize();

            AvalonUtils.ApplySyntaxRules("harmony.xshd", textEditor);
            this.Loaded += OnLoad;


        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            host.Child = new DrawingSurface();
            host.SizeChanged += Host_SizeChanged;
            Renderer = new HarmonyRenderer(host.Child.Handle, new SFML.Window.ContextSettings());
            var timer = new HighPrecisionTimer((int)(1000d / FramePerSecond));
            timer.Tick += OnTick;
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

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
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

            var positionY = Renderer.Window.GetView().Center.Y;

            Renderer.RecreateWindow(host.Child.Handle);

            var v = Renderer.Window.GetView();
            v.Center = new SFML.System.Vector2f(v.Center.X, (float)(positionY));
            Renderer.Window.SetView(v);

        }
    }
}
