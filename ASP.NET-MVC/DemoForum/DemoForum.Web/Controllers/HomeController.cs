using DemoForum.Services;
using DemoForum.Web.Models.Home;
using System.Linq;
using System.Web.Mvc;

namespace DemoForum.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPostService postService;

        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }

        public ActionResult Index()
        {
            var posts = this.postService
                .GetAll()
                .Select(x => new PostViewModel()
                {
                    Title = x.Title,
                    Content = x.Content,
                    AuthorEmail = x.Author.Email,
                    PostedOn = x.CreatedOn.Value
                })
                .ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}