using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace testAppForDigDes 
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Class1 c = new Class1();
            var type = typeof(Class1);
            var atr = type.GetMethod("method", BindingFlags.NonPublic | BindingFlags.Instance);
            List<string> finishList = (List<string>)atr.Invoke(c, new string[]{ "C:/Users/ASUS/Desktop/Текстовый файл сомнительного содержания.txt" });
            using (StreamWriter w = new StreamWriter("C:/Users/ASUS/Desktop/итог.txt")) {
                foreach(var str in finishList)
                   w.WriteLine(str);
            }
        }
    }
}
