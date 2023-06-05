using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    class MoreAnswQuest : IQuestion
    {
        public string question;
        public Dictionary<char, string> answers;
        public List<string> correctAnsw;
        public MoreAnswQuest(string quest, Dictionary<char, string> answers, List<string> correct)
        {
            question = quest;
            this.answers = answers;
            correctAnsw = correct;
        }

        public bool IsCorrect()
        {
            char vari;
            Console.WriteLine(question);
            foreach (var v in answers)
            {
                Console.WriteLine($"{v.Key} - {v.Value}");
            }
            int i = 0;
            foreach (var one in correctAnsw)
            {
                vari = char.Parse(Console.ReadLine());
                while (vari != 'A' && vari != 'B' && vari != 'C' && vari != 'D')
                {
                    Console.WriteLine("Wrong Letter Again");
                    vari = char.Parse(Console.ReadLine());
                }
                if (answers[vari] == one)
                {
                    i++;
                }
                else
                {
                    i--;
                }
            }
            if (i == 2)
                return true;
            else
                return false;
        }
    }
}
