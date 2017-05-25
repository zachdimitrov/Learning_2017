using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using JSON_Processing;

namespace JSON_Processing
{
    public class Video
    {
        public string Id { get; set; }
        public string VideoId { get; set; }
        public string ChannelId { get; set; }
        public string Title { get; set; }
        public VideoLink Link { get; set; }
        public Author Author { get; set; }
        public DateTime Published { get; set; }
        public DateTime Updated { get; set; }
        public VideoGroup Group { get; set; }

        public override string ToString()
        {
            return $@"----- Video Start -----
{Id}
{VideoId}
{ChannelId}
{Title}
{Link}
{Author}
{Published}
{Updated}
{Group}
----- Video End -----";
        }
    }

    public class VideoGroup
    {
        public string Title { get; set; }
        public Content Content { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public string Description { get; set; }
        public Community Community { get; set; }

        public override string ToString()
        {
            return $@"  ---- Group Start ----
    {Title}
    {Content}
    {Thumbnail}
    {Description}
    {Community}
    ---- Group End ----";
        }
    }

    public class Community
    {
        public StarRating StarRating { get; set; }
        public Statistics Statistics { get; set; }

        public override string ToString()
        {
            return $@"      --- Community Start ---
        {StarRating}
        {Statistics}
        --- Community End ---";
        }
    }

    public class Statistics
    {
        public int Views { get; set; }
    }

    public class StarRating
    {
        public int Count { get; set; }
        public decimal Average { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public override string ToString()
        {
            return $@"       -- StarRating Start --
            {Count}
            {Average}
            {Min}
            {Max}
            -- StarRating End --";
        }
    }


    public class Thumbnail
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return $@"      --- Thumbnail Start ---
        {Url}
        {Width}
        {Height}
        --- Thumbnail End ---";
        }
    }

    public class Content
    {
        public string Url { get; set; }
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public override string ToString()
        {
            return $@"      --- Content Start ---
        {Url}
        {Type}
        {Width}
        {Height}
        --- Content End ---";
        }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Uri { get; set; }
    }

    public class VideoLink
    {
        public string Rel { get; set; }
        public string Href { get; set; }
    }
}
