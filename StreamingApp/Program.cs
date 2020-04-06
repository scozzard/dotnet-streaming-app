using StreamingApp.Domain;
using StreamingApp.Services;
using System;
using System.Linq;
using System.Threading;

namespace StreamingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamingService service = new StreamingService();
            Timer timer = new Timer(TimerCallback, service.summary, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));

            try
            {
                service.Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an exception processing the stream:\n" + ex.Message);
            }

            Console.WriteLine("The stream has completed.");
            Console.ReadLine();
        }

        private static void TimerCallback(object state)
        {
            var result = (Summary)state;

            Console.Clear();
            Console.WriteLine("Total Words: " + result.TotalWords);
            Console.WriteLine("Total Characters: " + result.TotalCharacters);
            Console.WriteLine("Shorted Words: " + string.Join(", ", result.FiveShortestWords));
            Console.WriteLine("Longest Words: " + string.Join(", ", result.FiveLongestWords));
            Console.WriteLine("Most Frequent Words: " + string.Join(", ", result.TenMostFrequentWords));
            Console.WriteLine("Character Frequencies:\n" + string.Join("\n", result.CharacterFrequencies.Select(c => c.Key + " (" + c.Value + ")")));
        }
    }
}
