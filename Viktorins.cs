using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    abstract class Viktorins
    {
        protected List<string> answ;
        protected List<string> task;
        protected int score;
        protected string nameOfQuiz;
        abstract public void Start(Usser usser);

    }
    class Vikt_Math : Viktorins
    {
        private List<Dictionary<char, string>> s = new List<Dictionary<char, string>>();
        public Vikt_Math()
        {
            nameOfQuiz = "Math";
            task = new List<string>()
            { "Число, у которого нет собственного числа?",
              //Ответ:                           0
                "Назовите единственное четное простое число?",
             //Ответ: Две
                "Как еще называют периметр круга?",
             //Ответ: Окружность
                "Каков фактический чистый номер после 7?",
             //Ответ: 11
                "53 разделить на четыре сколько будет?",
             //Ответ: 13
                "Что такое Пи, рациональное или иррациональное число?",
             //Ответ: Пи — иррациональное число.
                "Какое самое популярное счастливое число от 1 до 9?",
             //Ответ:  Семь
                "    Сколько секунд в одном дне?",
             //Ответ: 86,400 секунд
                "Сколько миллиметров в одном литре?",
             //Ответ: Всего в одном литре 1000 миллиметров.
                "9*N равно 108. Что такое N?",
             //Ответ: N = 12
                " Изображение, которое также можно увидеть в трех измерениях?",
             //Ответ: Голограмма
                " Что предшествует квадриллиону?",
             //Ответ:  Триллион предшествует квадриллиону
                "Какое число считается «магическим числом»?",
                //Ответ: Девять.
                "Какой день является числом Пи?",
                //Ответ: 14 марта.
                "Кто изобрел знак равенства '='?"
                //Ответ: Роберт Рекорд.
            };
            s.Add(new Dictionary<char, string>() { ['a'] = "0", ['b'] = "1", ['c'] = "2", ['d'] = "3" });
            s.Add(new Dictionary<char, string>() { ['a'] = "2", ['b'] = "3", ['c'] = "2", ['d'] = "7" });
            s.Add(new Dictionary<char, string>() { ['a'] = "Окужность", ['b'] = "квадрат", ['c'] = "Бицепс", ['d'] = "катангенс" });
            s.Add(new Dictionary<char, string>() { ['a'] = "11", ['b'] = "10", ['c'] = "8", ['d'] = "47" });
            s.Add(new Dictionary<char, string>() { ['a'] = "11", ['b'] = "13", ['c'] = "8", ['d'] = "47" });
            s.Add(new Dictionary<char, string>() { ['a'] = "классное", ['b'] = "пи-внеклассное", ['c'] = "Пи — иррациональное число", ['d'] = "пи-мощное" });
            s.Add(new Dictionary<char, string>() { ['a'] = "не знаю", ['b'] = "Восемь", ['c'] = "много", ['d'] = "Семь" });
            s.Add(new Dictionary<char, string>() { ['a'] = "42,354 секунд", ['b'] = "3 секунды", ['c'] = "86,400 секунд", ['d'] = "1 час" });
            s.Add(new Dictionary<char, string>() { ['a'] = "много мало нет разници", ['b'] = "без понятия", ['c'] = "Всего в одном литре 1000 миллиметров.", ['d'] = "всего в 1 литре достаточно для отличной компании" });
            s.Add(new Dictionary<char, string>() { ['a'] = "N = 1452", ['b'] = "N = 12", ['c'] = "N = 785", ['d'] = "N = 0,1" });
            s.Add(new Dictionary<char, string>() { ['a'] = "Голограмма", ['b'] = "картина", ['c'] = "жалюхи", ['d'] = "что-то" });
            s.Add(new Dictionary<char, string>() { ['a'] = "Какие такие цифры", ['b'] = "Триллион предшествует квадриллиону", ['c'] = "С++ рулят", ['d'] = "что-то" });
            s.Add(new Dictionary<char, string>() { ['a'] = "Девять", ['b'] = "это не верный ответ", ['c'] = "и этот", ['d'] = "неа" });
            s.Add(new Dictionary<char, string>() { ['a'] = "14 марта", ['b'] = "14 марта", ['c'] = "14 марта", ['d'] = "14 марта" });
            s.Add(new Dictionary<char, string>() { ['a'] = "Роберт Рекорд", ['b'] = "спать", ['c'] = "Роберт Дауни младший", ['d'] = "это не роберт" });
            answ = new List<string>()
            {
                 "0",
                 "2",
                 "Окужность",
                 "11",
                "13",
                "Пи — иррациональное число",
                 "Семь",
                 "86,400 секунд",
                 "Всего в одном литре 1000 миллиметров.",
                 "N = 12",
                 "Голограмма",
                 "Триллион предшествует квадриллиону",
                 "Девять",
                "14 марта",
                 "Роберт Рекорд"
            };
            score = 0;
        }
        public override void Start(Usser some)
        {
            for (int i = 0; i < task.Count; i++)
            {
                Console.WriteLine(task[i]);
                foreach(var one in s[i])
                Console.WriteLine($"{one.Key} - {one.Value}");
                char ok = char.Parse(Console.ReadLine());
                while(ok!='a'&&ok!='b'&&ok!='c'&&ok!='d')
                {
                    Console.WriteLine("Again");
                    ok = char.Parse(Console.ReadLine());
                }
                if(s[i][ok]==answ[i])
                {
                    score += 100;
                }
            }
            some.AddScore($"Type of Quiz: {nameOfQuiz}\tscore:{score.ToString()}");
            Console.WriteLine("Congratulation you finish this quiz, chek your new score");
        }
    }
}
