# Databases
- Databases Course Examples and Definitions
- [2017 Course](http://in.thecamp.me/collection/Databases/6qZhL%2B9I)
- [2016 Course](https://telerikacademy.com/Courses/Courses/Details/388)

## JSON and XML
- best way to transfer data from server to client and reverse
- platform independant
 
#### Rules for JSON
- we can use these types:  

object | array | string | number | boolean
--- | --- | --- | --- | ---
{ "ivan": 23 } | ["gosho", 1, true] | "I am Pesho" | -53, 12 | true, false

### Parse JSON in .NET

##### Built in parser
- add reference to `System.Web.Extentions`

**Parse object - serialize**
```c#
var book = new Book(id, title, description, genres); // define class before
// create serializer instance
var serializer = new JavaScriptSerializer();
// parse object to JSON
var json = serializer.Serialize(book);
```

**Parse dictionary**
```c#
var dict = new Dictionary<string, int>();
for ( int i = 0; i < 10, i++ )
{
    dict["key-" + i] = book;
}
Console.WriteLine(serializer.Serialize(dict));
```

**Deserialize**
```c#
var json = {"Id":1,"Title":"Cool Book","Description":"A Book About Something","Genres":["Fantasy","Horror"]};
var book2 = serializer.Deserialize<Book>(json); // book needs empty constructor
```

##### Use Newtonsoft JsonConvert 
- install it with Nuget

```c#
JsonConvert.SerializeObject(book);
JsonConvert.SerializeObject(book, Formatting.Indented); // create formatted JSON (useful for test, indent increases filesize)
JsonConvert.DeserializeObject<Book>(json);
// anonymos objects
var person = new
{
    Name = "John",
    Age = 17
};
var personJson = JsonConvert.SerializeObject(person, Formatting.Indented);
// for the opposite we need template
var template = {Name = "", Age = 0};
var person2 = JsonConvert.DeserializeAnonimusType(personJson, template);

// use attributes for change keys above properties
[JsinProperty("new name")] // changes the name of the property in the JSON file (both ways)
public string Title { get; set; } // property

[JsonIgnore] // not used in the JSON file
```

### Linq to JSON
- filter data from JSON
- we can create class
- JSON always needs to start with object if array - { "data": [] }

```c#
public class SimpleBook
{
    public string Title { get; set; }
}

JObject.Parse(json)["data"]
    .Where(jObj => jObj["Title"]
        .Value<string>()
        .Contains("1"))
    .Select(jObj => new SimpleBook() { Title = jObj["Title"].ToString(); } )
    .ToList()
    .ForEach(Console.WriteLine);
```

### XML to JSON and reverse

```c#
var url = "https://telerikacademy.com/Rss/LatestCourses";
var client = new WebClient();
var xml = client.DownloadData(url);

var node = XDocument.Parse(xml.Root);
string jsonFromXML = JsonConvert.SerializeXNode(node);
```