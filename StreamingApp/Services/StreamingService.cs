using DevTest;
using StreamingApp.Domain;
using StreamingApp.Extensions;
using System.IO;
using System.Linq;
using System.Text;

namespace StreamingApp.Services
{
    public class StreamingService
    {
        public Summary summary;

        public StreamingService()
        {
            summary = new Summary();
        }

        public void Start()
        {
            var stream = new LorumIpsumStream();
            StreamReader reader = new StreamReader(stream, Encoding.Unicode);

            do
            {
                var word = string.Empty;

                while (true)
                {
                    char[] cha = new char[1];
                    reader.Read(cha, 0, 1);
                    char ch = cha[0];

                    word = AddCharacterToWord(ch, word);
                    
                    if (IsEndOfWord(ch, word))
                    {
                        AddWordToSummary(word);
                        break;
                    }
                }
            } while (stream.CanRead);

            reader.Close();
            reader.Dispose();
        }

        public string AddCharacterToWord(char ch, string word)
        {
            if (!ch.IsSpaceOrFullStop())
            {
                var existingChar = summary.Letters.FirstOrDefault(c => c.Letter == ch);
                if (existingChar != null)
                {
                    summary.Letters.FirstOrDefault(c => c.Letter == ch).Frequency++;
                }
                else
                {
                    summary.Letters.Add(new Domain.Character(ch));
                }

                word += ch;
            }

            return word;
        }

        public bool IsEndOfWord(char ch, string word)
        {
            return (ch.IsSpaceOrFullStop()) && word.Length > 0;
        }

        public void AddWordToSummary(string word)
        {
            // Given we are talking about words we won't differentiate between upper and lower case characters.
            word = word.ToLower();

            var existingWord = summary.Words.FirstOrDefault(w => w.Text == word);
            if (existingWord != null)
            {
                summary.Words.FirstOrDefault(w => w.Text == word).Frequency++;
            }
            else
            {
                summary.Words.Add(new Domain.Word(word, word.Length));
            }
        }
    }
}
