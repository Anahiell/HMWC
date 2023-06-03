using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Quiz
{
    class Back
    {
        private string path="Users.dat";
        private Usser some=new Usser();
        private Viktorins vik;
        public List<Usser> list { get; set; }
        public void FileSave(Usser some)
        {
            using (var fs = new FileStream(path, FileMode.Append))
            {
                var bw = new BinaryFormatter();
                bw.Serialize(fs, some);
            }
        }
        private void LoadUssers()
        {
            list = new List<Usser>();
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    
                    while (fs.Position < fs.Length)
                    {
                        Object one = bf.Deserialize(fs);
                        list.Add((Usser)one); // Добавляем десериализованный объект в список
                    }
                }
            }
            else
            {
                Console.WriteLine("Error file");
            }
        }
        public void FinderUsser()
        {
            LoadUssers();
            foreach (var one in list)
            {
                if ((Usser)one == some)
                {
                    some = (Usser)one;
                    break;
                }
            }
           
        }
        public void Entering()
        {
            LoadUssers();
            Console.WriteLine("1-sing in\t\t2-create\t\t0-exit");
            int x = int.Parse(Console.ReadLine());
            while (x != 0)
            {
                switch (x)
                {
                    case 1:
                        {
                            some = new Usser();
                            bool a = some.Sing_in(list);
                            if(a==false)
                            {
                                Console.WriteLine("try to create account");
                            }
                            else
                            Main_Menu();
                            break;
                        }
                    case 2:
                        {
                            some.Create(list);
                            Main_Menu();
                            break;
                        }
                    default:
                        FileSave(some);
                        break;
                }
                Console.WriteLine("1-sing in\t\t2-create\t\t0-exit");
                x = int.Parse(Console.ReadLine());
            }
        }
        public void Main_Menu()
        {
            Console.WriteLine("1-start quiz\t2-look on my account\t3-look top 20\t4-save account\t0-exit");
            int x = int.Parse(Console.ReadLine());
            while (x != 0)
            {
                switch (x)
                {
                    case 1:
                        {
                            Menu_Viki();
                            break;
                        }
                    case 2:
                        {
                            Menu_user();
                            break;
                        }
                    case 3:
                        {

                            break;
                        }
                    case 4:
                        {
                            FileSave(some);
                            break;
                        }
                    default:
                        FileSave(some);
                        break;
                }
                Console.WriteLine("1-start quiz\t2-look on my account\t3-look top 20\t4-save account\t0-exit");
                x = int.Parse(Console.ReadLine());
            }
            FileSave(some);
        }
        public void Menu_Viki()
        {
            Console.WriteLine("Right now have only Math Quiz\n1- math quiz\t\t0-exit");
            int x = int.Parse(Console.ReadLine());
            switch (x)
            {
                case 1:
                    {
                        vik = new Vikt_Math();
                        vik.Start(some);
                        break;
                    }
                default:
                    FileSave(some);
                    break;
            }
        }
        public void Menu_user()
        {
            Console.WriteLine("its your account you can:\n1-check your score\n2-look in yours info\n3-cheng your birthday\n0-exit");
            int x = int.Parse(Console.ReadLine());
            while (x != 0)
            {
                switch (x)
                {
                    case 1:
                        {
                            Console.WriteLine("Your  score:");
                            some.LookLastScore();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine(some);
                            break;
                        }
                    case 3:
                        {
                            some.Change();
                            break;
                        }
                    default:
                        FileSave(some);
                        break;
                }
                Console.WriteLine("its your account you can:\n1-check your score\n2-look in yours info\n3-cheng your birthday\n0-exit");
                x = int.Parse(Console.ReadLine());
            }
        }
        
    }
}

