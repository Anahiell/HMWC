using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NLog;
using System.Xml;

namespace Musick_Album
{
    class LibConw
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private List<Album> albums = new List<Album>();
        private Album al = new Album();
        private int IDcount;
        public LibConw()
        {
            IDcount = 0;
        }
        public void AddAlbum(Album some)
        {
            albums.Add(some);
            logger.Info("Add new Album");
            IDcount++;
        }
        public void Serialiaz(string path1)
        {
            if (albums.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You can't save, first add Album");
                logger.Warn("Try to save empty space");
                Console.ForegroundColor = ConsoleColor.White;
            }
            using (FileStream fs = new FileStream(path1, FileMode.Append))
            {
                BinaryFormatter bf = new BinaryFormatter();
                foreach (var al in albums)
                    bf.Serialize(fs, al);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saving to file completed");
            Console.ForegroundColor = ConsoleColor.White;
            logger.Info("Save to file");
        }
        public void Deserialize(string path1)
        {
            if (albums.Count != 0)
            {
                logger.Warn("Lose albums,not save before");
            }
            if (File.Exists(path1))
            {
                using (FileStream fs = new FileStream(path1, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    albums.Clear();
                    IDcount = 0;

                    while (fs.Position < fs.Length)
                    {
                        Object ali = bf.Deserialize(fs);
                        Album convAl = (Album)ali;//костыль
                        albums.Add(convAl);
                    }
                }
            }
            else
            {
                Console.WriteLine("Not finde File");
                logger.Error("File not found");
            }
            logger.Info("Load from file");
        }
        public void SaveToXml()
        {
            /*create*/
            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoc.AppendChild(xmlDeclaration);
            /**/
            XmlElement rootElement = xmlDoc.CreateElement("Albums");
            xmlDoc.AppendChild(rootElement);
            /**/
            // Создание дочерних элементов
            if (albums.Count > 0)
            {

                for (int i = 0; i < albums.Count(); i++)
                {
                    Album sup = albums[i];
                    XmlElement LibraryElement = xmlDoc.CreateElement($"Alb{i}");
                    XmlAttribute NAlb = xmlDoc.CreateAttribute("Name");
                    NAlb.InnerText = albums[i].NameAlbum;
                    LibraryElement.SetAttributeNode(NAlb);

                    XmlAttribute CreatorElement = xmlDoc.CreateAttribute("Creator");
                    CreatorElement.InnerText = albums[i].NameOfCreator;
                    LibraryElement.SetAttributeNode(CreatorElement);

                    XmlAttribute StudEl = xmlDoc.CreateAttribute("Studio");
                    StudEl.InnerText = albums[i].Studia;
                    LibraryElement.SetAttributeNode(StudEl);

                    XmlAttribute YearEl = xmlDoc.CreateAttribute("Year");
                    YearEl.InnerText = albums[i].DateCreate.ToString();
                    LibraryElement.SetAttributeNode(YearEl);

                    XmlAttribute TimeEl = xmlDoc.CreateAttribute("FullTime");
                    TimeEl.InnerText = albums[i].FullTime;
                    LibraryElement.SetAttributeNode(TimeEl);

                    rootElement.AppendChild(LibraryElement);
                }
                xmlDoc.Save("albums.xml");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Saving to XML file completed");
                Console.ForegroundColor = ConsoleColor.White;
                logger.Info("Save to XML");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error you dont have what save");
                Console.ForegroundColor = ConsoleColor.White;
                logger.Warn("Try save empty space to XML");
            }
        }
        public void Show()
        {
            foreach (var c in albums)
                Console.WriteLine("==========================\n" + c);
        }
    }

}
