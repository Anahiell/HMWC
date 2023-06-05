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
    class ManagerUssers
    {
        private static string path = "Users.dat";
        public List<Usser> users { get; set; }

        public ManagerUssers()
        {
            users = new List<Usser>();
        }

        public void AddUser(Usser user)
        {
            users.Add(user);
        }

        public void Serialize(string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, users);
                }
                Console.WriteLine("Serialization successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Serialization failed: " + e.Message);
            }
        }

        public void Deserialize(string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    users = (List<Usser>)binaryFormatter.Deserialize(fileStream);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Deserialization failed: " + e.Message);
            }
        }
        public Usser Sing_in()
        {
            Console.WriteLine("Enter Login:");
            string login = Console.ReadLine();
            string passw;
            Usser user = users.FirstOrDefault(u => u.login == login);
            if (user != null)
            {
                Console.WriteLine("Find you!");
                Console.WriteLine("Enter password:");
                passw = Console.ReadLine();
                if (user.passw == passw)
                {
                    Console.WriteLine("Success");
                    return user;
                }
            }

            Console.WriteLine("Not found!");
            Usser n = null;
            return n;
        }
        public void UpdateUser(Usser some)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].login == some.login)
                {
                    users.RemoveAt(i);
                    users.Add(some);
                    Serialize(path);
                    break;
                }
            }
        }
        public Usser CreateUser()
        {
            Console.WriteLine("Start to create a new Account");
            Console.WriteLine("Enter Login or Nickname:");
            string login = Console.ReadLine();

            foreach (var user in users)
            {
                if (user.login == login)
                {
                    Console.WriteLine("This name is taken");
                    Console.WriteLine("Enter Login or Nickname:");
                    login = Console.ReadLine();
                    break;
                }
            }

            Console.WriteLine("Enter password:");
            string passw = Console.ReadLine();
            Console.WriteLine("Enter your date of birth:");
            DateTime dateBirth = DateTime.Parse(Console.ReadLine());

            Usser newUser = new Usser(login, passw, dateBirth);

            users.Add(newUser);
            Serialize("Users.dat");

            Console.WriteLine("\tCongratulations!!!\nYou have created an account!");
            return newUser;
        }

    }
}

