using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;
using System.Threading.Tasks;


namespace testAppForDigDes
{  
    public class Class1
    {
        private static object _key = new object();
        ConcurrentDictionary<string, int> dict = new ConcurrentDictionary<string, int>();
        List<string> lines = new List<string>();
        public Dictionary<string, int> PublicMethod(string s)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string[] words = s.Split(new char[] { ' ', ',', '.', '\0', '-', '—', '\"', '&', '*',
                                                  '!', '?', '(', ')', '\n', '»', '«', ':', ';' });
            foreach (string word in words)
                if (word != "" && word != null && word != "\r")
                    lines.Add(word);

            Parallel.ForEach(lines, word =>
            {
                if (dict.ContainsKey(word))
                {
                    lock(_key)
                        dict[word]++;
                }
                else
                {
                    lock(_key)
                        dict[word] = 1;
                }
            });
            var k = dict.AsParallel().OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            sw.Stop();
            Console.WriteLine("Параллельно: " + sw.ElapsedMilliseconds);
            return k;
        }
        private Dictionary<string, int> PrivateMethod(string s)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string[] words = s.Split(new char[] { ' ', ',', '.', '\0', '-', '—', '\"', '&', '*',
                                                  '!', '?', '(', ')', '\n', '»', '«', ':', ';' });
            foreach (string word in words)
                if (word != "" && word != null && word != "\r")
                    lines.Add(word);

            var dict = new Dictionary<string, int>();
            foreach (string word in lines)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                else
                {
                    dict[word] = 1;
                }
            }

            var k = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            sw.Stop();
            Console.WriteLine("Не параллельно: " + sw.ElapsedMilliseconds);
            return k;
        }
    }
}
