using DemoForum.Data.Models;
using DemoForum.Data.Repositories;
using System.Linq;

namespace DemoForum.Services
{
    public class PostService : IPostService
    {
        private readonly IEfRepository<Post> postsRepo;

        public PostService(IEfRepository<Post> postsRepo)
        {
            this.postsRepo = postsRepo;
        }

        public IQueryable<Post> GetAll()
        {
            return this.postsRepo.All;
        }
    }
}
