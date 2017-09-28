﻿using DemoForum.Data.Models.Abstracts;

namespace DemoForum.Data.Models
{
    public class Post : DataModel
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public virtual User Author { get; set; }
    }
}
