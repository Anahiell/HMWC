using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Musick_Album
{
    [Serializable]
    class Album
    {
        public string NameAlbum { get; set; }
        public string NameOfCreator { get; set; }
        public DateTime DateCreate { get; set; }
        private int Minut;
        private int Second;
        public string FullTime { get; set; }
        public string Studia { get; set; }
        public Album()
        {

        }
        public Album(string Name1,string Name2,DateTime Date,int Min,int Sec,string Name3)
        {
            NameAlbum = Name1;
            NameOfCreator = Name2;
            Studia = Name3;
            DateCreate = Date;
            Minut = Min;
            Second = Sec;
            FullTime = $"{Minut}:{Second}";
        }
        public void EnterInfo()
        {
            Console.WriteLine("Enter Name of album:");
            NameAlbum = Console.ReadLine();
            Console.WriteLine("Enter Name of creator:");
            NameOfCreator = Console.ReadLine();
            Console.WriteLine("Enter Date of create:");
            DateCreate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Full time of album(minuts after seconds):");
            Minut = int.Parse(Console.ReadLine());
            Second = int.Parse(Console.ReadLine());
            FullTime = $"{Minut}:{Second}";
            Console.WriteLine("Enter Studio:");
            Studia = Console.ReadLine();
        }
        public override string ToString()
        {
            return $"Name:{NameAlbum}\nCreator:{NameOfCreator}\nDate:{DateCreate}\n" +
                $"Full Time:"+FullTime+$"\nStudio:{Studia}";
        }
    }
}
