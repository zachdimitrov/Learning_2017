using System;

namespace DemoForum.Web.Models.Home
{
    public class PostViewModel
    {
        public string Title { get; set; }

        public string  Content { get; set; }

        public string AuthorEmail { get; set; }

        public DateTime PostedOn { get; set; }
    }
}