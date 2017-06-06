using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionsTest.Models
{
    [Table("Pesho")]
    public class IceCream
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 10)]
        public int A { get; set; }

        [Range(1, 10)]
        public int B { get; set; }
    }
}
