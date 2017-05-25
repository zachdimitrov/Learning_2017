using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Processing
{
    class Program
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../Data/catalog.xml");

            var root = doc.DocumentElement;

            foreach (XmlNode node in root.ChildNodes)
            {
                string name = node.Name;
                Console.WriteLine("========== " + name + " ==========");

                foreach (XmlNode innerNode in node.ChildNodes)
                {
                    string innerName = innerNode.Name;
                    string text = innerNode.InnerText;

                    if (innerName == "songs")
                    {
                        Console.WriteLine("----- songs -----");
                        foreach (XmlNode song in innerNode.ChildNodes)
                        {
                            string songTag = song.Name;
                            string songName = song.InnerText;
                            Console.WriteLine($"{songTag}: {songName}");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine($"{innerName}: {text}");
                    }
                }
            }
        }
    }
}
