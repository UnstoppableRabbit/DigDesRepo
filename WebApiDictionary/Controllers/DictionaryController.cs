using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDictionary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        // POST api/<DictionaryController>
        [HttpPost]
        public Dictionary<string, int> Post([FromBody] string s)
        {
            List<string> lines = new List<string>();

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

            return dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
