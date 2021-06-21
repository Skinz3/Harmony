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
using System.Windows.Threading;

namespace Harmony.IDE.WPF
{
    /// <summary>
    /// Logique d'interaction pour Loader.xaml
    /// </summary>
    public partial class Loader : UserControl
    {
        public Loader()
        {
            InitializeComponent();

            this.Loaded += OnControlLoaded;
        }

        
        private void OnControlLoaded(object sender, RoutedEventArgs e)
        {

            var window = (MainWindow)Window.GetWindow(this);


            Thread thread = new Thread(new ThreadStart(() =>
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

            thread.Start();
        }



    }
}
