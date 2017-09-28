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

### Views

- strart rendering from outer most view

```c#
@using Example.Models
@model MyViewModel

@{
    ViewBag.Title = "Home Page";  // multi line scope (visible for whole view)
}

@DateTime.Now // single line C#

@for(int i = 0; i < 5; i++) { // c# scope
    <div> Hello </div> // html inside
} // end of c# scope

@: single line text to render

<text>
    multi-line text
    renders as normal html text
</text>
```

- layouts
if layout is set to `null` it will not render in layout

```c#
@{
    Layout="~/Views/Shared/_MasterLayout.cshtml" // default is _ViewStart.cshtml
}
```

- sections
create section
```c# 
@section mysection {
    <h1> In section! </h1>
}
```
render in layout
```c#
@RenderSection("mysection", required: false)
```
- helpers
```c#
@Html.TextBox("Username");

@using (Html.BeginForm("PostForm", "Home", FormMethod.Post))
{
    @Html.TextBoxFor(m => m.something, 
    new { @class="form-controll" type="number" }); // create object for attributes
}

<input class="form-control" asp-for="Something" /> // the same as above

@Url.Action

@Html.ActionLink("To about", "About", "Home"); // text, action, controller
```
- helpers 
in floder `App-Code`
with view - `Helpers.cshtml`
```c#
@helper WriteValue(int value)
{
    @:value passed: @value
}
```
use it like `@Helpers.WriteValue(10)`

- partial views
name it like this `_CustomPartial.cshtml`
use it with 
`@Html.Partial("_CustomPartial")` - inside html
`@Html.RenderPartial("_CustomPartial")` - inside c# mode

in controllers
`return this.PartialView();`

- child action
`@Html.Action("ChildAction", new {id = "5"})`

 ### Bundles
 - combine scripts and styles in bundles
 ```c#
 bundles.Add(new ScriptBundle())
 ```
### Areas
- create area with right button
- it is a complete set with controllers and views

### Action filters
- OutputCache
- ValidateInput (false)
- Authorize
- ValidateAntiForgeryToken
- HandleError