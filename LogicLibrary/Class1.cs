using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace testAppForDigDes
{  
    public class Class1
    { 
        private List<string> method(string n)
        {
            FileStream file = new FileStream(n, FileMode.Open);    
            StreamReader readFile = new StreamReader(file);        
            List<string> lines = new List<string>();
            while (!readFile.EndOfStream)
            {
                string s = readFile.ReadLine().ToLower();
                string[] words = s.Split(new char[] { ' ', ',', '.', '\0', '-', '—', '\"', '&', '*',
                                                      '!', '?', '(', ')', '\n', '»', '«', ':', ';' });
                foreach (string word in words)
                    if (word != "" && word != null)
                        lines.Add(word);
            }
            readFile.Close();

            var k = lines.GroupBy(g => g).OrderByDescending(g => g.Count()).Select(g => $"{g.Key} {g.Count()}").ToList();
            return k;
        }
    }
}
