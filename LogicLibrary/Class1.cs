using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace testAppForDigDes
{  
    public class Class1
    { 
        private Dictionary<string, int> method(string s)
        {
             
            List<string> lines = new List<string>();            
                
            string[] words = s.Split(new char[] { ' ', ',', '.', '\0', '-', '—', '\"', '&', '*',
                                                  '!', '?', '(', ')', '\n', '»', '«', ':', ';' });
            foreach (string word in words)
                if (word != "" && word != null && word !="\r") 
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
            
            return dict.OrderByDescending(x => x.Value).ToDictionary(x=>x.Key, x=>x.Value);
        }
    }
}
