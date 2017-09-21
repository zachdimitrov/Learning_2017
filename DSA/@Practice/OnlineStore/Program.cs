using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace OnlineStore
{
    class Product
    {
        public Product(string name, decimal price, string producer)
        {
            Name = name;
            Price = price;
            Producer = producer;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Producer { get; set; }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2}}}", this.Name, this.Producer, this.Price.ToString("F2"));
        }
    }

    class Program
    {
        static Bag<Product> allProducts = new Bag<Product>();
        static void Main()
        {
            //Console.SetIn(new StreamReader("..\\..\\input.txt"));
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine();
                var index = command.IndexOf(" ");
                var commandName = command.Substring(0, index);
                var cp = command.Substring(index + 1).Split(';');

                if (commandName == "AddProduct")
                {
                    var provider = CultureInfo.InvariantCulture;
                    var productToAdd = new Product(cp[0], decimal.Parse(cp[1],provider), cp[2]);
                    allProducts.Add(productToAdd);
                    Console.WriteLine("Product added");
                }
                else if (commandName == "DeleteProducts")
                {
                    IEnumerable<Product> productsToDelete = new List<Product>();

                    if (cp.Length == 1)
                    {
                        productsToDelete = allProducts.RemoveAll(x => x.Producer == cp[0]);
                    }
                    else
                    {
                        productsToDelete = allProducts
                            .RemoveAll(x => x.Name == cp[0] && x.Producer == cp[1]);
                    }

                    if (productsToDelete.Any())
                    {
                        Console.WriteLine(productsToDelete.Count() + " products deleted");
                    }
                    else
                    {
                        Console.WriteLine("No products found");
                    }
                }
                else if (commandName == "FindProductsByName")
                {
                    var products = allProducts.Where(x => x.Name == cp[0]).OrderBy(x => x.ToString());
                    if (products.Any())
                    {
                        foreach (var item in products)
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No products found");
                    }
                }
                else if (commandName == "FindProductsByPriceRange")
                {
                    var start = decimal.Parse(cp[0]);
                    var end = decimal.Parse(cp[1]);
                    var products = allProducts.Where(x => x.Price >= start && x.Price <= end).OrderBy(x => x.ToString());
                    if (products.Any())
                    {
                        foreach (var item in products)
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No products found");
                    }
                }
                else if (commandName == "FindProductsByProducer")
                {
                    var products = allProducts.Where(x => x.Producer == cp[0]).OrderBy(x => x.ToString());
                    if (products.Any())
                    {
                        foreach (var item in products)
                        {
                            Console.WriteLine(item.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No products found");
                    }
                }
            }
        }
    }
}
