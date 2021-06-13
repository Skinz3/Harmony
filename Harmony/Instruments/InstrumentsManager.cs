using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Instruments
{
    public class InstrumentsManager
    {
        private static Dictionary<string, Instrument> Instruments = new Dictionary<string, Instrument>();

        public static string RelativePath = "Instruments\\";

        public static void Initialize()
        {
            if (!Directory.Exists(RelativePath))
            {
                Directory.CreateDirectory(RelativePath);
            }

            foreach (var directory in Directory.GetDirectories(RelativePath))
            {
                Instrument instrument = new Instrument();
                instrument.Name = Path.GetFileName(directory);

                foreach (var file in Directory.GetFiles(directory))
                {
                    instrument.Notes.Add(new InstrumentNote()
                    {
                        Name = Path.GetFileNameWithoutExtension(file),
                        WavFile = file,
                    });

                }

                Instruments.Add(instrument.Name, instrument);
            }
        }
        public static Instrument GetInstrument(string name)
        {
            return Instruments[name];
        }

    }
}
