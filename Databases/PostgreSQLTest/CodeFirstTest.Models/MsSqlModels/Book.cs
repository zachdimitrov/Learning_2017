namespace CodeFirstTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public virtual Library Library { get; set; }
    }
}
