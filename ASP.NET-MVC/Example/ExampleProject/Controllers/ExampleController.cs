using Example.Services;
using ExampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleProject.Controllers
{
    public class ExampleController : Controller
    {
        private readonly IExampleService exampleService;

        public ExampleController(IExampleService exampleService)
        {
            this.exampleService = exampleService;
        }

        public ActionResult Index()
        {
            // can use auto-mapper dataModel.MapTo()

            var name = exampleService.GetName();
            var friends = exampleService.GetFriends();

            var model = new ExampleViewModel(name, friends);

            return this.View(model);
        }
    }
}