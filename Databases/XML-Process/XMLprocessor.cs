using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace XML_Process
{
    class XMLprocessor
    {
        static string GetXml()
        {
            return @"<?xml version=""1.0"" encoding=""UTF - 8""?>
<breakfast_menu>
    <food>
        <name>Belgian Waffles</name>
        <price>$5.95</price>
        <description>
            Two of our famous Belgian Waffles with plenty of real maple syrup
        </description>
        <calories>650</calories>
    </food>
    <food name=""fruits"">
        <name>Strawberry Belgian Waffles</name>
        <price>$7.95</price>
        <description>
            Light Belgian waffles covered with strawberries and whipped cream
        </description>
        <calories>900</calories>
    </food>
    <food>
        <name>Berry-Berry Belgian Waffles</name>
        <price>$8.95</price>
        <description>
        Light Belgian waffles covered with an assortment of fresh berries and whipped cream
        </description>
        <calories>900</calories>
    </food>
    <food>
        <name>French Toast</name>
        <price>$4.50</price>
        <description>
            Thick slices made from our homemade sourdough bread
        </description>
        <calories>600</calories>
    </food>
    <food>
        <name>Homestyle Breakfast</name>
        <price>$6.95</price>
        <description>
            Two eggs, bacon or sausage, toast, and our ever-popular hash browns
        </description>
        <calories>950</calories>
    </food>
</breakfast_menu>
";
        }

        static void Main()
        {
            // create simple XML to parse to food
            var xml = GetXml();

            // create food to parse to XML
            #region
            Food food1 = new Food()
            {
                Id = 8,
                Name = "Apple",
                Description = "Delicious food!"
            };

            Food food2 = new Food()
            {
                Id = 9,
                Name = "Orange",
                Description = "An orange ball!"
            };

            Food food3 = new Food()
            {
                Id = 10,
                Name = "Banitsa",
                Description = "Very nice with cheese!"
            };

            var foods = new List<Food>();
            foods.Add(food1);
            foods.Add(food2);
            foods.Add(food3);
            #endregion

            // use XML DOM
            Console.WriteLine("-------- use DOM --------");
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var root = doc.DocumentElement;
            PrintChildren(root);

            // use STAX reader
            Console.WriteLine("-------- use STAX --------");
            using (var node = XmlReader.Create("../../data/Menu.xml"))
            {
                Food food = ReadNextFood(node);
                while (food != null)
                {
                    Console.WriteLine(food);
                    food = ReadNextFood(node);
                }
            }

            // use STAX writer
            using (var writer = XmlWriter.Create("../../data/OutputStax.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("dayly-menu");

                foreach (var food in foods)
                {
                    WriteNextBook(writer, food);
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            // LINQ to XML - Parse
            Console.WriteLine("-------- use LINQ --------");
            var doc1 = XDocument.Load("../../data/Menu.xml");
            doc1.Root
                .Elements("food")
                .Select(node =>
                {
                    var id = int.Parse(node.Attribute("id").Value);
                    var name = node.Element("name").Value;
                    var desc = node.Element("description").Value;

                    return new Food
                    {
                        Id = id,
                        Name = name,
                        Description = desc.Trim()
                    };
                })
                .ToList()
                .ForEach(Console.WriteLine);

            // LINQ to XML - Create
            var doc2 = new XDocument();
            var root2 = new XElement("menu-items",
                foods.Select(food => new XElement("food",
                        new XAttribute("id", food.Id),
                        new XElement("name", food.Name),
                        new XElement("description", food.Description)
                     )));

            doc2.Add(root2);
            doc2.Save("../../data/OutputLinq.xml");

            // LINQ edit XML
            Console.WriteLine("-------- use LINQ to edit XML --------");
            doc1.Root.Add(new XAttribute("last-update", DateTime.Now.ToString()));
            doc1.Save("../../data/UpdatedFood.xml");
            Console.WriteLine(" Success - document is written");

            // Search with LINQ
            Console.WriteLine("-------- use LINQ to search in XML --------");
            doc1.Root.Elements("food")
                .Where(foodElement => foodElement
                    .Attribute("id")
                    .Value
                    .Contains("2"))
                .Select(foodElement => foodElement.Element("name").Value)
                .ToList()
                .ForEach(Console.WriteLine);

            // XSL convert from XML to HTML
            Console.WriteLine("-------- use XSLT to create HTML --------");
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../data/Menu.xslt");
            xslt.Transform("../../data/Menu.xml", "../../data/Menu.html");
        }

        // Writes sequence of XML tags
        private static void WriteNextBook(XmlWriter writer, Food food)
        {
            writer.WriteStartElement("food");
            writer.WriteAttributeString("id", food.Id.ToString());

            writer.WriteElementString("name", food.Name);
            writer.WriteElementString("description", food.Description);

            writer.WriteEndElement();
        }

        // Read with STAX
        static Food ReadNextFood(XmlReader node)
        {
            var food = new Food();
            var isDescRead = false;
            var isIdRead = false;
            var isNameRead = false;

            while ((!isDescRead || !isIdRead) && node.Read())
            {
                if (node.IsStartElement() && node.Name == "food")
                {
                    food.Id = int.Parse(node.GetAttribute("id"));
                    isIdRead = true;
                }

                if (node.IsStartElement() && node.Name == "name")
                {
                    node.Read();
                    food.Name = node.Value.Trim();
                    isNameRead = true;
                }

                if (node.IsStartElement() && node.Name == "description")
                {
                    node.Read();
                    food.Description = node.Value.Trim();
                    isDescRead = true;
                }
            }

            if (isDescRead == false || isIdRead == false || isNameRead == false)
            {
                return null;
            }

            return food;
        }

        // Print with DOM Parcer
        static void PrintChildren(XmlNode node, string indent = "")
        {
            var attrs = "";
            if (node.Attributes != null)
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    attrs += attr.Name + "=" + attr.Value;
                }
            }

            Console.WriteLine(indent + node.Name + "(" + attrs + ")");

            foreach (XmlNode child in node.ChildNodes) // XmlElement
            {
                PrintChildren(child, indent + " - -");
            }
        }
    }
}
