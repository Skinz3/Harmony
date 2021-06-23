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
using System.Windows.Shapes;

namespace Harmony.IDE
{
    /// <summary>
    /// Logique d'interaction pour Configuration.xaml
    /// </summary>
    public partial class Configuration : Window
    {
        HarmonyRenderer Renderer
        {
            get;
            set;
        }
        public Configuration(HarmonyRenderer renderer)
        {
            this.Renderer = renderer;
            InitializeComponent();
            headerBar.MouseDown += (s, e) => DragMove();

            foreach (var instrument in InstrumentsManager.GetInstruments())
            {
                instruments.Items.Add(instrument);
            }

            drawMeta.IsChecked = ConfigManager.Instance.DisplayKeyMetadata;
        }

        private void ExitClick(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void instruments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var instrument = (Instrument)instruments.SelectedItem;

            if (instrument != null)
            {
                ConfigManager.Instance.Instrument = instrument.Name;
                Renderer.Flow.SheetPlayer.InstrumentPlayer.DefineInstrument(instrument);
                ConfigManager.Save();
            }

        }

        private void drawMeta_Click(object sender, RoutedEventArgs e)
        {
            if (drawMeta.IsChecked.Value)
            {
                Renderer.Keyboard.DisplayKeyMetadata();
                ConfigManager.Instance.DisplayKeyMetadata = true;

            }
            else
            {
                Renderer.Keyboard.HideKeyMetadata();
                ConfigManager.Instance.DisplayKeyMetadata = false;
            }

            ConfigManager.Save();
        }
    }
}
