using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace JSON_Processing
{
    class Program
    {
        static void Main()
        {
            // convert XML to JSON
            var address = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            WebClient client = new WebClient();
            var feed = client.DownloadData(address);

            XDocument doc = XDocument.Load(address);

            var node = doc.Root;

            string jsonText = JsonConvert.SerializeXNode(node, Newtonsoft.Json.Formatting.Indented);

            System.IO.File.AppendAllText(@"../../Data/feed.json", jsonText);

            // create object from JSON
            using (StreamReader r = new StreamReader(@"../../Data/feed2.json"))
            {
                string json = r.ReadToEnd();
                var videos = JsonConvert.DeserializeObject<List<Video>>(json);
                Console.WriteLine(String.Join("\n", videos));
            }
        }
    }
}
