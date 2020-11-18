using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Web;

namespace BudzetDomowy.Models
{
    public class DateGenerate
    {
        public static Random random;
        static DateGenerate()
        {
            random = new Random();
        }
        public static Dictionary<string, List<string>> womanDictionary;
        public static Dictionary<string, List<string>> manDictionary;
        public static void Generate()
        {
            womanDictionary = SetWomanDictionary();
            manDictionary = SetManDictionary();
        }
        private static Dictionary<string, List<string>> SetWomanDictionary()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"/App_Data/woman.json";
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string json = sr.ReadToEnd();
                var dictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
                return dictionary;
            }
        }
        private static Dictionary<string, List<string>> SetManDictionary()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"/App_Data/man.json";
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string json = sr.ReadToEnd();
                var dictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
                return dictionary;
            }
        }
        public static void ShowList()
        {
            womanDictionary = SetWomanDictionary();
            manDictionary = SetManDictionary();
        }
    }
}