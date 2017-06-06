namespace CodeFirstTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
