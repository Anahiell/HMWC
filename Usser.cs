using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Quiz
{
    [Serializable]
    class Usser
    {
        public string login { get; set; }
        public string passw { get; set; }
        public DateTime dateBirth { get; set; }
        public int lastscore { get; set; }
        public List<string> scores { get; set; }

        public Usser()
        {

        }
        public Usser(string log, string passw, DateTime date)
        {
            login = log;
            this.passw = passw;
            dateBirth = date;
            scores = new List<string>();
        }
        public void AddScore(string score)
        {
            scores.Add(score);
        }


        public void LookLastScore()
        {
            if (scores == null)
            {
                Console.WriteLine("Don't have yet");
            }
            else
            {
                var lastScores = scores.Skip(Math.Max(0, scores.Count - 4)).Take(4); // Вывести последние 4 результатов
                foreach (var score in lastScores)
                {
                    Console.WriteLine(score);
                }
            }
        }
        public override string ToString()
        {
            return $"Nickname:{login}\t\tDate of birthday:{dateBirth}";
        }
        public void Change()
        {
            Console.WriteLine($"Your birthday:{dateBirth}\nEnter new bithday date");
            dateBirth = DateTime.Parse(Console.ReadLine());
        }

    }
}
