using Harmony.Chords;
using Harmony.Instruments;
using Harmony.Notes;
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

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);

            Thread worker = new Thread(new ThreadStart(() =>
              {
                  NotesManager.Initialize();
                  ChordsManager.Initialize("chords.json");
                  ConfigManager.Initialize();
                  InstrumentsManager.Initialize();

                  try
                  {
                      window.Dispatcher.Invoke(() =>
                      {
                          window.Content = new Editor();
                      });
                  }
                  catch
                  {
                      Environment.Exit(0);
                  }

              }));

            worker.Start();


        }
    }
}
