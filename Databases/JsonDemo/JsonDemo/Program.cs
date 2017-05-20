using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonDemo
{
    public class Book
    {
        [JsonIgnore] // work with JsonConvert
        public int Id { get; set; }

        public string Title { get; set; }

        [JsonProperty("description")] // work with JsonConvert
        public string Description { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public Book()
        {
            
        }
        public Book(int Id, string Title, string Description, List<string> Genres)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
            this.Genres = Genres;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{this.Id}");
            builder.AppendLine($"{this.Title}");
            builder.AppendLine($"{this.Description}");
            builder.AppendLine($"{string.Join(", ",this.Genres)}");
            return builder.ToString();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var genres = new List<string>() { "Horror", "Fantasy", "Other" };
            var book = new Book(1, "Hello", "Bad book", genres);

            var serializer = new JavaScriptSerializer();

            var serialized = serializer.Serialize(book);
            var serializedFormatted = JsonConvert.SerializeObject(book, Formatting.Indented);

            Console.WriteLine("------- Serialized with Serializer ---------");
            Console.WriteLine(serialized);
            Console.WriteLine("------- Serialized with JsonConvert Formatted ---------");
            Console.WriteLine(serializedFormatted);

            var jsonFile = @"{""Id"":1,""Title"":""Hello"",""Description"":""Bad book"",""Genres"":[""Horror"",""Fantasy"",""Other""]}";

            var book1 = serializer.Deserialize<Book>(jsonFile);
            var book2 = JsonConvert.DeserializeObject<Book>(jsonFile);

            Console.WriteLine("------- Deserialize with Serializer ---------");
            Console.WriteLine(book1.Id);
            Console.WriteLine(book1.Title);
            Console.WriteLine(book1.Description);
            Console.WriteLine(String.Join(", ",book1.Genres.ToArray()));

            Console.WriteLine("------- Deserialize with JsonConvert ---------");
            Console.WriteLine(book2.Id);
            Console.WriteLine(book2.Title);
            Console.WriteLine(book2.Description);
            Console.WriteLine(String.Join(", ", book2.Genres.ToArray()));
            Console.WriteLine("------- JArray ---------");
            JArray.Parse(jsonFile)
                .Where(
                    jObj =>
                        jObj["Title"]
                            .Value<string>()
                            .Contains("H"))
                .Select(jObj => jObj["Title"].ToString());

            Console.WriteLine("----------- XML -----------");
            var client = new WebClient();
            var url = "https://telerikacademy.com/Rss/LatestCourses";
            var data = client.DownloadData(url);

            Console.WriteLine(data);
        }
    }
}