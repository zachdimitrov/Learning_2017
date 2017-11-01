using System.Linq;
using DemoForum.Data.Models;

namespace DemoForum.Services
{
    public interface IPostService
    {
        IQueryable<Post> GetAll();
    }
}