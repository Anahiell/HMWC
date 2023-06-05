using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class OneAnswQuest : IQuestion
    {
        public string question;
        public Dictionary<char, string> answers;
        public string correctAnsw;
        public OneAnswQuest(string quest, Dictionary<char, string> answers, string correct)
        {
            question = quest;
            this.answers = answers;
            correctAnsw = correct;
        }
        public bool IsCorrect()
        {
            Console.WriteLine(question);
            foreach (var v in answers)
            {
                Console.WriteLine($"{v.Key} - {v.Value}");
            }
            char vari = char.Parse(Console.ReadLine());
            while (vari != 'A' && vari != 'B' && vari != 'C' && vari != 'D')
            {
                Console.WriteLine("Wrong Letter Again");
                vari = char.Parse(Console.ReadLine());
            }
            if (answers[vari] == correctAnsw)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
