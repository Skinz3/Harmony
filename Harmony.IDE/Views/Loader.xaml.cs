using Harmony.Chords;
using Harmony.Instruments;
using Harmony.Notes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Harmony.IDE.Views
{
    /// <summary>
    /// Logique d'interaction pour Loader.xaml
    /// </summary>
    public partial class Loader : UserControl
    {
        public Loader()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }
        public static IntPtr GetHandler(Window window)
        {
            var interop = new WindowInteropHelper(window);
            return interop.Handle;
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);

            Thread worker = new Thread(new ThreadStart(() =>
              {
                  window.Dispatcher.Invoke(() =>
                   {
                       state.Content = "Loading data...";

                   });

                  NotesManager.Initialize();
                  ChordsManager.Initialize("chords.json");
                  ConfigManager.Initialize();
                  InstrumentsManager.Initialize();

                  Editor editor = null;

                  var result = window.Dispatcher.BeginInvoke((Action)(() =>
                  {
                      editor = new Editor();
                  }));

                  result.Wait();

                  window.Dispatcher.Invoke(() =>
                  {
                      state.Content = "Loading Instrument...";
                  });

                  if (!editor.LoadInstrument())
                  {
                      window.Dispatcher.Invoke(() =>
                      {
                          state.Content = "Unable to find any instrument. Aborting.";
                       
                      });
                  }
                  else
                  {
                      try
                      {
                          window.Dispatcher.Invoke(() =>
                          {
                              window.Content = editor;

                          });
                      }
                      catch
                      {
                          Environment.Exit(0);
                      }
                  }



              }));

            worker.Start();
        }


    }
}
