using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using NLog;

namespace Musick_Album
{
   
    class Program
    {
        
        public static string path = "Albums.dat";
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Album al1 = new Album("Revolver", "The Beatles",new DateTime(1966,8,5), 34, 12, "EMI Studios");
            Album al2 = new Album("Thriller", "Michael Jackson", new DateTime(1982, 11, 30), 42, 02, "Westlake recording Studios");
            Album al3 = new Album("Dark Side of the Moon", "Pink Floyd", new DateTime(1973, 3, 1), 43, 0, "Abbey Road Studios");

            LibConw Liberty = new LibConw();
            Liberty.AddAlbum(al1);
            Liberty.AddAlbum(al2);
            Liberty.AddAlbum(al3);
            Liberty.Show();
            Liberty.Serialiaz(path);
            Liberty.Deserialize(path);
            Liberty.SaveToXml();
            Liberty.Show();
        }
    }
}
