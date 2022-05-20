using System.Collections.Generic;
using SystemMonitoring.Models.Entity;

namespace SystemMonitoring.Models
{
    internal class Data
    {
        public static int UserID { get; set; }
        public static int Access { get; set; }
        public bool IsAdmin() => Access == 1;
        public bool IsUser() => Access == 0;
        public static string DistrictName { get; set; } 
        public static double SizeWindow { get; set; }
        public static string Path { get; set; }
        public static string ConfigName { get; set; } = "settings";
        public static string ConfigFormat { get; set; } = "json";
        public static string DirectoryName { get; set; } = "SystemMonitoring";
        public static Seed SelectSeeding { get; set; }
        public static List<SensorDetails> Childs { get; set; }
    }
}