using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Quiz
{

    class Program
    {
        public static string path = "Users.dat";
        public static string pathFile = "Viktorins_Math.xml";
        public static string pathFileH = "Viktorins_History.xml";
        static public void CreateTopUsersFile()
        {
            if (File.Exists("TopUsers.txt"))
            {
                Console.WriteLine("TopUsers.txt file already exists.");
                return;
            }
            try
            {
                using (var wr = new StreamWriter("TopUsers.txt"))
                {
                    wr.WriteLine("Top 5 Users:");
                }

                Console.WriteLine("TopUsers.txt file created successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to create TopUsers.txt file: " + e.Message);
            }
        }

        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Run();


        }
    }
}
