# ASP.NEW MVS Framework

### Parts of the project 

#### Public Part
- all accessable, links should work

#### Private Part (Users only)
- only for authenticated users

#### Administration Part
- administration Panel
- controll DB data easy
- jqGrid

## MVC Pattern

### Model
- Plain Old Class - POCO
- Contain validation rules
- Separate view models and DB models
- No logic, only data

### View
- Html files, dynamically created

### Controller
- gets data from service and processes data
- Pass data to views
- Has one or more "Actions"
- Application logic

### How it works
- server side technology
- Request -> Web Server
  -> Routing Engine goes -> Controler (C# class)
- Controller processes the request (delegates)
- Controller creates CRUD model and passes data to View (Razor)
- View is displayed to user from View Engine

## ASP.NET Libraries
- Cashing
- .NET library
- Globalization
- Pages
- Controls
- Master Pages
- Profile
- Roles
- Membership
- Routes
- Handlers
- Other Libraries...

## Run IIS Web Server
- go to `windows features`


## Architecture

### Routing

```c#
public class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
}
```
### Controllers
- Class with methods with names of vies
  - Class name is the name of the views folder + Controller
  - Every view has the same name as `ActionResult` method in coresponding controller

```c#
namespace Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
```
folder `views/Home` will contain:
- `Index.cshtml`
- `About.cshtml`
