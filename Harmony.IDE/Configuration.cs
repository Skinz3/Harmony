using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.IDE
{
    public class Config
    {
        public string ScriptPath
        {
            get;
            set;
        }
        public bool DisplayKeyMetadata
        {
            get;
            set;
        }
        public string Instrument
        {
            get;
            set;
        }
        public static Config Default()
        {
            return new Config()
            {
                ScriptPath = string.Empty,
                DisplayKeyMetadata = false,
                Instrument = string.Empty,
            };
        }
    }
    public class ConfigManager
    {
        public static Config Instance;

        public static void Initialize()
        {
            if (File.Exists(Constants.ConfigPath))
            {
                Instance = JsonConvert.DeserializeObject<Config>(File.ReadAllText(Constants.ConfigPath));
            }
            else
            {
                Instance = Config.Default();
                Save();
            }
        }
        public static void Save()
        {
            File.WriteAllText(Constants.ConfigPath, JsonConvert.SerializeObject(Instance));
        }
    }
}
