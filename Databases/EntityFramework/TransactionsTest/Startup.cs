using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionsTest.Data;
using TransactionsTest.Migrations;
using TransactionsTest.Models;

namespace TransactionsTest
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CoolAppContext, Configuration>());
            var data = new CoolAppContext();

            var cream = new IceCream() { A = 5, B = 5 };
            data.IceCreams.Add(cream);
            data.SaveChanges();
            Console.WriteLine(data.IceCreams.FirstOrDefault());
        }
    }
}
