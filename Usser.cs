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
        private string login;
        private string passw;
        private DateTime dateBirth;
        private List<string> scores;

        public Usser()
        {
            scores = new List<string>();
        }
        public void AddScore(string score)
        {
            scores.Add(score);
        }
        public void Create(List<Usser> some)
        {
            Console.WriteLine("Start to create new Account");
            Console.WriteLine("Enter Loggin or Nickname:");
            login = Console.ReadLine();

            foreach (Usser one in some)
            {
                if (one.login != login)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("This name is taken");
                    Console.WriteLine("Enter Loggin or Nickname:");
                    login = Console.ReadLine();
                }
            }
            Console.WriteLine("Enter password:");
            passw = Console.ReadLine();
            Console.WriteLine("Enter your date of birthday:");
            dateBirth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("\tCongratulation!!!\n You create accaunt!");

        }
        public bool Sing_in(List<Usser> some)
        {
            Console.WriteLine("Enter Login:");
            login = Console.ReadLine();
            foreach (Usser one in some)
            {
                if (one.login == login)
                {
                    Console.WriteLine("Find you!");
                    Console.WriteLine("Enter password:");
                    passw = Console.ReadLine();
                    if (one.passw == passw)
                    {
                        Console.WriteLine("Sucsess");
                        return true;

                    }
                }
            }
            Console.WriteLine("Not found!");
            return false;
        }
        public void LookLastScore()
        {
            if (scores == null)
            {
                Console.WriteLine("Dont have yet");
            }
            else
            {
                foreach (var one in scores)
                    Console.WriteLine(one);
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
