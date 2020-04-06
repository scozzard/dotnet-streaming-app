using System.Collections.Generic;
using System.Linq;

namespace StreamingApp.Domain
{
    public class Summary
    {
        public List<Word> Words { get; set; }
        public List<Character> Letters { get; set; }
        public int TotalWords => Words.Sum(w => w.Frequency);
        public int TotalCharacters => Letters.Sum(c => c.Frequency);
        public List<string> FiveLongestWords => Words.OrderByDescending(w => w.Length).Take(5).Select(w => w.Text).ToList();
        public List<string> FiveShortestWords => Words.OrderBy(w => w.Length).Take(5).Select(w => w.Text).ToList();
        public List<string> TenMostFrequentWords => Words.OrderByDescending(w => w.Frequency).Take(10).Select(w => w.Text).ToList();
        public Dictionary<char, int> CharacterFrequencies => Letters.OrderByDescending(c => c.Frequency).ToDictionary(c => c.Letter, c => c.Frequency);

        public Summary()
        {
            Words = new List<Word>();
            Letters = new List<Character>();
        }
    }
}
