namespace CodeFirstTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual Genre ParentGenre { get; set; }

        public virtual ICollection<Genre> ChildGenres { get; set; }
    }
}
