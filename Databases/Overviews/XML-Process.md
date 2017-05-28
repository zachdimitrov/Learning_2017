## XML Basics  
- structure and rules  
 - opening tag `<?xml version="1.0" encoding="UTF-8"?>`  
 - root `<root>`  
 - any kind of data and elements (tags)  
 - can have attributes (properties)  
 - all names must be lowercase  

### namespaces
 - avoid name conflicts
 - url-a ne se izpolzva, samo dava unikalno ime na namespace
 - example: 
 ```xml
 <root 
xmlns:h="http://www.w3.org/TR/html4/"
xmlns:f="https://www.w3schools.com/furniture">

<h:table>
  <h:tr>
    <h:td>Apples</h:td>
    <h:td>Bananas</h:td>
  </h:tr>
</h:table>

<f:table>
  <f:name>African Coffee Table</f:name>
  <f:width>80</f:width>
  <f:length>120</f:length>
</f:table>

</root>
 ```
 - default namespace `xmlns="namespaceURI"` no prefixes used

#### XSD (schema)
 - defines rules for XML elements
 - can be automatically generated

#### XML Parsers
- DOM Parser - for small files
- SAX - Simple API for XML
- StAX - Streaming API for XML
- XDocument -> LINQ-to-XML (too slow but best for .NET)

#### XPath
- path to brouse XML file
`/library/book[isbn=""]`
`/catalog/cd[@price<10]`

#### XSL transformations
- creates HTML from XML

## Parse using DOM parser
```c#
var doc = new XmlDocument();
doc.LoadXml(xml);
var root = doc.DocumentElement;
PrintChildren(root);
```
- method to print children
```c#
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
```

## Using STAX 
#### Reader
```c#
using (var node = XmlReader.Create("../../data/Menu.xml"))
{
  Food food = ReadNextFood(node);
  while (food != null)
  {
    Console.WriteLine(food);
    food = ReadNextFood(node);
  }
}
```
- meethod to read from XML
```c#
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
```

#### Writer
```c#
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
```
- method to write
```c#
private static void WriteNextBook(XmlWriter writer, Food food)
{
    writer.WriteStartElement("food");
    writer.WriteAttributeString("id", food.Id.ToString());
    writer.WriteElementString("name", food.Name);
    writer.WriteElementString("description", food.Description);
    writer.WriteEndElement();
}
```

## LINQ to XML - Parse
```c#
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
```

## LINQ to XML - Create
```c#
var doc2 = new XDocument();
var root2 = new XElement("menu-items",
    foods.Select(food => new XElement("food",
            new XAttribute("id", food.Id),
            new XElement("name", food.Name),
            new XElement("description", food.Description)
         )));

doc2.Add(root2);
doc2.Save("../../data/OutputLinq.xml");
```

## LINQ edit XML
```c#
doc1.Root.Add(new XAttribute("last-update",DateTime.Now.ToString()));
doc1.Save("../../data/UpdatedFood.xml");
Console.WriteLine(" Success - document is written");
```  

## Search with LINQ
```c#
doc1.Root.Elements("food")
    .Where(foodElement => foodElement
        .Attribute("id")
        .Value
        .Contains("2"))
    .Select(foodElement => foodElement.Element("name").Value)
    .ToList()
    .ForEach(Console.WriteLine);
```   

## XSL convert from XML to HTML
```c#
Console.WriteLine("-------- use XSLT to create HTML --------");
XslCompiledTransform xslt = new XslCompiledTransform();
xslt.Load("../../data/Menu.xslt");
xslt.Transform("../../data/Menu.xml", "../../data/Menu.html");
```