using Newtonsoft.Json;
using System;
using System.IO;
using SystemMonitoring.Models;

namespace SystemMonitoring
{
    class FileManager
    {
        public static string GetPathConfig()
        {
            string appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = $@"{appdataPath}\{Data.DirectoryName}\{Data.ConfigName}.{Data.ConfigFormat}";
            if (!File.Exists(path))
            {
                if (!Directory.Exists($@"{appdataPath}\{Data.DirectoryName}\")) Directory.CreateDirectory($@"{appdataPath}\{Data.DirectoryName}\");
                File.Create(path).Dispose();
                Settings settings = new Settings();
                File.WriteAllText(path, JsonConvert.SerializeObject(settings));
            }
            return path;
        }
        public static Settings GetSettings() { return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(GetPathConfig())); }
        public static void SetSettings(Settings settings) { File.WriteAllText(GetPathConfig(), JsonConvert.SerializeObject(settings)); }
        public static string GetAppData()
        {
            string appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = $@"{appdataPath}\{Data.DirectoryName}\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory($@"{appdataPath}\{Data.DirectoryName}\");
            return path;
        }
        public static string GetSensorsJson()
        {
            string path = $@"{GetAppData()}\sensors.json";
            if (!File.Exists(path))
                File.Create(path).Dispose();
            return path;
        }
    }
}