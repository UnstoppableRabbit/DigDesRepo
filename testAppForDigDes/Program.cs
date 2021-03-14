using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace testAppForDigDes 
{ 
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            Class1 c = new Class1();
            var type = typeof(Class1);
            var atr = type.GetMethod("method", BindingFlags.NonPublic | BindingFlags.Instance);
          
            FileStream file = new FileStream("C:/Users/ASUS/Desktop/текстовый файл сомнительного содержания.txt", FileMode.Open);
            using (StreamReader readFile = new StreamReader(file))
            {
                 s = readFile.ReadToEnd().ToLower();
            }
            Dictionary<string, int> finishList = (Dictionary<string,int>)atr.Invoke(c, new string[] { s });

            using (StreamWriter w = new StreamWriter("C:/Users/ASUS/Desktop/итог.txt")) {
                foreach(var str in finishList)
                   w.WriteLine($"{str.Value} {str.Key}");
            }
        }
    }
}
