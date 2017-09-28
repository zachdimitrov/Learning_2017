using DemoForum.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoForum.Data.Models
{
    public class Post : DataModel
    {
        public string Content { get; set; }

        public Guid AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
