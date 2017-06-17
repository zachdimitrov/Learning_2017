using Forum.Models;
using Ninject;
using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace Forum.ConsoleApp
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var dp = kernel.Get<MyDataProvider>();

            //using (var unitOfWork = dp.UnitOfWork())
            //{
            //    dp.Categories.Add(new Category()
            //    {
            //        Name = "Different",
            //        ParentCategory = new Category()
            //        {
            //            Name = "New Parent"
            //        }
            //    });

            //    unitOfWork.Commit();
            //}

            //using (var uow = dp.UnitOfWork())
            //{
            //    dp.Posts.Add(new Post()
            //    {
            //        CategoryId = 1,
            //        Content = "TestPostNew",
            //        Title = "TitleNew",
            //        PostType = PostType.Important
            //    });
            //    uow.Commit();
            //}

            // var importer = new ForumDbImporter();
            // importer.BeginImport();

            var categories = dp.Categories.All.ToList();

            foreach(var catg in categories)
            {
                Console.WriteLine($"*** {catg.Name} ***");

                var pList = dp
                    .Posts
                    .FilterAll(p => p.Category.Id == catg.Id)
                    .Select(p => "Id: " + p.Id + ", " + p.Title + " - " + p.Content + ", created on: " + p.CreatedOn)
                    .ToList();

                var posts = String.Join("\n    ", pList);
                if (posts.Length > 0)
                {
                    Console.WriteLine("    " + posts);
                }
            }
        }
    }
}
