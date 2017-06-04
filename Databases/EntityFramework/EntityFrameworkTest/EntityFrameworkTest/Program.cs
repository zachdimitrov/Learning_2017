using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example 1 - simple example
            Console.WriteLine("Example 1 - simple example" + new String('-', 30));
            using (var db = new TelerikAcademyEntities())
            {
                var project = db.Projects
                    .Select(pr => pr.Name)
                    .ToList();

                Console.WriteLine(String.Join("\n", project));
            }

            // Example 2 - make multiple requests
            Console.WriteLine("Example 2 - make multiple requests" + new String('-', 30));
            using (var db = new TelerikAcademyEntities())
            {
                var employees = db
                    .Employees
                    .Where(e => e.Department.Name == "Sales") // creates reques
                    .Select(e => new                          // another request
                    {
                        Id = e.EmployeeID,
                        Name = e.FirstName + " " + e.LastName,
                        DepartmentName = e.Department.Name
                    })
                    .GroupBy(e => e.DepartmentName)         // another request
                    .FirstOrDefault();

                Console.WriteLine(employees);
            }

            // Example 3 - create data
            Console.WriteLine("Example 3 - create data" + new String('-', 30));
            using (var db = new TelerikAcademyEntities())
            {
                // Create new object
                var town = new Town()
                {
                    Name = "Pavlikeni"
                };

                var address = new Address()
                {
                    AddressText = "Mladost 1A",
                    Town = town
                };

                // Mark the object for inserting
                db.Towns.Add(town);
                db.Addresses.Add(address);
                db.SaveChanges();

                var addedAddress = db
                    .Addresses
                    .Where(a => a.Town.Name == "Pavkileni")
                    .Select(a => (a.AddressText + ", " + a.Town.Name))
                    .FirstOrDefault();

                Console.WriteLine(addedAddress);
            }

            // Example 4 - loop through lots of data
            Console.WriteLine("Example 4 - loop through lots of data" + new String('-', 30));
            using (var db = new TelerikAcademyEntities())
            {
                var towns = db.Towns
                    .Where(t => t.Addresses.Any())
                    .Select(t => new
                    {
                        t.Name,
                        Addresses = t.Addresses.Select(a => a.AddressText)
                    })
                    .ToList();

                foreach (var town in towns)
                {
                    Console.WriteLine(town.Name);
                    foreach (var addr in town.Addresses)
                    {
                        Console.WriteLine(addr);
                    }
                    Console.WriteLine(new String('-', 32));
                }
            }

            // Example 5 - extend db class
            Console.WriteLine("Example 5 - extend db class" + new String('-', 30));
            using (var db = new TelerikAcademyEntities())
            {
                var emp = db
                    .Employees
                    .ToList()
                    .Select(em => em.FullName());

                foreach (var employee in emp)
                {
                    Console.WriteLine(employee);
                }
            }

            // Example 6 - join tables
            Console.WriteLine("Example 6 - join tables" + new String('-', 30));
            using (var db = new TelerikAcademyEntities())
            {
                var result = db.Towns
                    .Select(t => new TownDataModel // create temporary object
                    {
                        Name = t.Name,
                        Addresses = t.Addresses.Select(a => a.AddressText)
                    });

                Console.WriteLine(result);
            }

            // Example 7 - group data
            Console.WriteLine("Example 7 - group data" + new String('-', 30));
            using (var db = new TelerikAcademyEntities())
            {
                var emplGroups = db
                        .Employees
                        .GroupBy(e => new { e.Department.Name, TownName = e.Address.Town.Name })
                        .ToList();

                foreach (var group in emplGroups)
                {
                    Console.WriteLine(group.Key);
                    foreach (var employee in group)
                    {
                        Console.WriteLine(employee.FullName());
                    }
                    Console.WriteLine("==========");
                }
            }

            // Example 8 - update data
            Console.WriteLine("Example 8 - update data" + new String('-', 30));
            using (var db = new TelerikAcademyEntities())
            {
                var employee = db.Employees.FirstOrDefault();
                employee.FirstName = "Ivan";
                db.SaveChanges();

                Console.WriteLine(db.Employees.FirstOrDefault().FullName());
            }
        }
    }
}
