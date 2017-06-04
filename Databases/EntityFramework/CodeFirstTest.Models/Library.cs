using System.Collections.Generic;

namespace CodeFirstTest.Models
{
    public class Library
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
