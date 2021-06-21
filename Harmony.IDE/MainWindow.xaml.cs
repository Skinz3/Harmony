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
using Harmony.IDE.Views;

namespace Harmony.IDE
{

    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Content = new Loader();
        }
    }
}
