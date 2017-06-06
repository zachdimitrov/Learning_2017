using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionsTest.Models;

namespace TransactionsTest.Data
{
    class CoolAppContext : DbContext
    {
        public CoolAppContext() : base("CoolApp")
        {
        }

        public virtual IDbSet<IceCream> IceCreams { get; set; }
    }
}
