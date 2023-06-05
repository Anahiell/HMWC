using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace Quiz
{
    class Menu
    {
        private ManagerUssers userManager;
        private Viktorin vik;

        public void Run()
        {
            userManager = new ManagerUssers();
            userManager.Deserialize("Users.dat");

            while (true)
            {
                Console.WriteLine("1 - Sign in\n2 - Create account\n0 - Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Usser user = userManager.Sing_in();
                        if (user != null)
                        {
                            MainMenu(user);
                        }
                        else
                            Console.WriteLine("Invalid login or password. Please try again.");
                        break;

                    case 2:
                        Usser newUser = userManager.CreateUser();
                        if (newUser != null)
                            MainMenu(newUser);
                        break;

                    case 0:
                        userManager.Serialize("Users.dat");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void MainMenu(Usser user)
        {
            while (true)
            {
                Console.WriteLine("1 - Start quiz\n2 - View account\n3 - Change birthday\n4-Look on TOP\n0 - Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        MenuViki(user);
                        break;

                    case 2:
                        ViewAccount(user);
                        break;

                    case 3:
                        ChangeBirthday(user);
                        break;
                    case 4:
                        ViewTopUsers();
                        break;

                    case 0:
                        userManager.UpdateUser(user);
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void MenuViki(Usser user)
        {
            while (true)
            {
                Console.WriteLine("1 - Math quiz\n2 - History quiz\n0 - Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        vik = new Viktorin("Viktorins_Math.xml");
                        vik.Start();
                        user.lastscore = vik.score;
                        user.AddScore($"Name: {vik.nameOfVik}\t{vik.score}");
                        userManager.UpdateUser(user);
                        AddUserToTopUsersFile(user);
                        break;

                    case 2:
                        vik = new Viktorin("Viktorins_History.xml");
                        vik.Start();
                        user.lastscore = vik.score;
                        user.AddScore($"Name: {vik.nameOfVik}\t{vik.score}");
                        userManager.UpdateUser(user);
                        AddUserToTopUsersFile(user);
                        break;

                    case 0:
                        userManager.UpdateUser(user);
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void ViewAccount(Usser user)
        {
            while (true)
            {
                Console.WriteLine("1 - Check your score\n2 - Look at your info\n0 - Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Your scores:");
                        user.LookLastScore();
                        break;

                    case 2:
                        Console.WriteLine(user);
                        break;

                    case 0:
                        userManager.UpdateUser(user);
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void ChangeBirthday(Usser user)
        {
            Console.WriteLine($"Your birthday: {user.dateBirth}");
            Console.WriteLine("Enter your new birthday date:");
            user.Change();
        }
        public void AddUserToTopUsersFile(Usser user)
        {
            string filePath = "TopUsers.txt";

            List<string> lines = new List<string>();

            //  если он существует
            if (File.Exists(filePath))
            {
                lines = File.ReadAllLines(filePath).ToList();
            }

            // Создаем новую запись в формате "Имя пользователя: Количество очков"
            string newUserEntry = $"{user.login}: {user.lastscore}";

            // Добавляем новую запись в список
            lines.Add(newUserEntry);

            // Сортируем список по убыванию количества очков
            lines = lines.OrderByDescending(line =>
            {
                int score = 0;
                if (int.TryParse(line.Split(':')[1].Trim(), out score))
                {
                    return score;
                }
                return 0;
            }).ToList();

            // Если количество записей в списке превышает 5, удаляем лишние записи
            if (lines.Count > 5)
            {
                lines = lines.Take(5).ToList();
            }

            // Записываем отсортированный список в файл
            File.WriteAllLines(filePath, lines);
        }
        public void ViewTopUsers()
        {
            string filePath = "TopUsers.txt";

            if (File.Exists(filePath))
            {
                Console.WriteLine("Top Users:");

                // Читаем записи из файла
                string[] lines = File.ReadAllLines(filePath);

                // Выводим каждую запись на экран
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("Top Users file does not exist.");
            }
        }
    }
}



