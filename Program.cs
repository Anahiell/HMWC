using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileAds
{
    class Program
    {
        public static string path1 = "Task1.dat";
        public static string path;
        public static string pathtext;
        public static string path2 = "Task2.txt";
        static void Creator_File1()
        {
            /*task with number*/
            Random RND = new Random();
            int counts = 100000;
            
            Console.WriteLine("Chouse Manual(1) or Automaticl(2):");
            int x = int.Parse(Console.ReadLine());
            switch(x)
            {
                case 1:
                    {
                        path = Console.ReadLine();
                        using (var fs = new FileStream(path, FileMode.Create))
                        {
                            using (BinaryWriter bf = new BinaryWriter(fs))
                            {
                                for (int i = 0; i < counts; i++)
                                {
                                    Int32 ar = new Int32();
                                    ar = (RND.Next(-1 * (counts / 2), counts / 2));
                                    bf.Write(ar);
                                }
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        using (var fs = new FileStream(path1,FileMode.Create))
                        {
                            using (BinaryWriter bf = new BinaryWriter(fs))
                            {
                                for (int i = 0; i < counts; i++)
                                {
                                    Int32 ar = new Int32();
                                    ar = (RND.Next(-1 * (counts / 2), counts / 2));
                                    bf.Write(ar);
                                }
                            }

                        }
                        break;
                    }
                default:
                    break;
            }
        }
        static void Creator_Faile2()
        {
            string message = "Bee, a bee, a bumblebee\nStung a man upon his knee\nAnd a hog upon his snout,\nI'll be dogged if you ain't out!";
            Console.WriteLine("Chouse Manual(1) or Automaticl(2):");
            int x = int.Parse(Console.ReadLine());
            switch (x)
            {
                case 1:
                    {
                        
                        pathtext = Console.ReadLine();
                        File.WriteAllText(pathtext,message);
                        break;
                    }
                case 2:
                    {
                        using (var stream=new StreamWriter(path2))
                        {
                            stream.Write(message);
                        }
                        break;
                    }
                default:
                    break;
            }
        }
        public static void Changer(string Text,string word1,string word2,string paths)
        {
            string Text2=Text.Replace(word1, word2);
            using (var stream = new StreamWriter(paths))
            {
                stream.Write(Text2);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Text2);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task#1");
            // Creator_File1();
            BinFileWork Inetrn = new BinFileWork();
            Inetrn.Univers(path1);
            Console.WriteLine("Task#2");
            //Creator_Faile2();
            string text;
            Console.ForegroundColor = ConsoleColor.Green;
            using (var stream = new StreamReader(path2))
            {
                text=stream.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Write wich word you wont to change in text:");
         
            string word1 = Console.ReadLine();
            Console.WriteLine("Write NEW word:");
            string neword2 = Console.ReadLine();
           Changer(text, word1,neword2, path2);
        }
    }
}
