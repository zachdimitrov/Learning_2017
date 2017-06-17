using Forum.Data.Common;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.ConsoleApp
{
    public class MyDataProvider
    {
        private IRepository<Category> categories;
        private IRepository<Post> posts;
        private Func<IUnitOfWork> unitOfWork;

        public MyDataProvider(Func<IUnitOfWork> unitOfWork, IRepository<Category> categories, IRepository<Post> posts)
        {
            this.categories = categories;
            this.posts = posts;
            this.unitOfWork = unitOfWork;
        }

        public IRepository<Post> Posts
        {
            get { return posts; }
            set { posts = value; }
        }

        public IRepository<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public Func<IUnitOfWork> UnitOfWork
        {
            get { return unitOfWork; }
            set { unitOfWork = value; }
        }
    }
}
