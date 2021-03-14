using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace ClientDictionary
{
    public class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            string newStr = "";
            FileStream file = new FileStream("C:/Users/ASUS/Desktop/текстовый файл сомнительного содержания.txt", FileMode.Open);
            using (StreamReader readFile = new StreamReader(file))
            {
                s = readFile.ReadToEnd().ToLower();
            }
            using (var webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                s = AddaptJson(s);
                newStr = webClient.UploadString("http://localhost:56155/api/Dictionary", "Post", "\""+ s+ "\"");
            }
            var lastDiction = JsonConvert.DeserializeObject<Dictionary<string, int>>(newStr);

            using (StreamWriter w = new StreamWriter("C:/Users/ASUS/Desktop/итог.txt"))
            {
                foreach (var str in lastDiction)
                    w.WriteLine($"{str.Value} {str.Key}");
            }
        }
        public static string AddaptJson(string value)
        {
            value = value.Replace('\n', ' ');
            value = value.Replace('\r', ' ');
            value = value.Replace('\"', ' ');
            value = value.Replace('/', ' ');
            value = value.Replace('\\', ' ');
            return value;
        }
    }
}
