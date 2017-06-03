# Entity Framework

## Connect existing DB to C# project
- Create new item in current project - ADO.NET
- Name it with *DataBaseNameEntities*
- 4 Options
    - Create base from existing DB
    - Empty Designer model (diagram view)
    - Empty Code First
    - Code First from DB
- Use first Option
- Add Connection to `.\SQLEXPRESS` - optional add credentials
- Select Database to use
- It automatically saves the connection string to `App.COnfig`
- Name the connection (or use default)
- Select EF version
- Select tables, views, stored procedures
- FINISH

## App.Config file
- connection with DB in `<connectionStrings>`
- there can be many connection strings

## Created classes

| Origin | Emplyee    | Address            | Town               |
| ---    | ---        | ---                | ---                |
| DB     | `Id`       | `Id`               | `Id`               |
| DB     | `FirstName`| `Text`             | `Name`             |
| DB     | `LastName` | -                  | -                  |
| JOINED |`Address`   | `Town`             | `HashSet<Address>` |
| JOINED |  -         | `HashSet<Emplyee>` | -                  |

## Use current DB with LINQ
```c#
using (var db = new DataBaseNameEntities()) // create dbContext
{
    var project = db.Projects // if table Projects exists
        .Where(pr => pr.Id == 1)
        .FirstOrDefault();    // gets first project with ID = 1

    Console.WriteLine(project.Name);
}
```
- `db` is the main class everything starts from
- `using` is added to dispose memory resources
- if `using` is impossible - `use db.dispose()`, do it regularly after each 100 or some objects and create another dbContext
- do not use global object like this - `private static DataBaseNameEntities db = new DataBaseNameEntities()`

## Read data from `dbContext`
- Main properties 
    - Connection (generated automatically)
    - CommandTimeout 
    - IDbSet<ClassName>

- Use **LINQ-to-SQL** or **Fluent API** (above example)
```c#
var Project = db.Projects.Find(1); // fast way to search but will throw exception if not found
var project = FirstOrDefault(pr => pr.ProjectId == 1); // better option, requires expression
```
- If we use `ToList()` somewhere it retuns it to `IEnumerable` and is not `Expression` any more
- `ToList()` creates the request to DB and returns a regular list
```c#
var employees = db
    .Employees
    .Where(e => e.Department.Name = "Sales") // creates reques
    .Select(e => new                         // another request added
    {
        Id = e.EmplyeeId,
        Name = e.FirstName + " " + e.LastName,
        DepartmentName = e.Department.Name
    })
    .GroupBy(e => e.DepartmentName)         // another request added
    .FirstOrDefault()                       // returns data (execute request)
```
- Methods that send request and return data:
    - `ToList()`
    - `First()`
    - `FirstOrDefault`
    - `Any()`
    - `All()`
- When we add `Select` we shrink the object properties to selected, so we need to use it at the end 
- We can see the query woth `Console.WriteLine(query)` before materializing with a return-data method
- Use SQL Profile - better way to follow SQL requests

### Difference between `IEnumerable` and `IQuariable`

- reqular list requires Func (delegate or method that is called az one code)
```c#
// this is how List (IEnumerable) works
var list = new List<Project>();
list.FirstOrDefault(pr => pr.ProjectId == 1); // requires Func
```
- IQuariable requires expression which is very different, it can use every part of the code 
- SQL transpation is made from expression - `Expression<Func<Something>>`
```c#
// this is expression
Expression<Func<Project, bool>> expr = pr => pr.ProjectId == 1;
// this is func
Func<Project, bool> expr = pr => pr.ProjectId == 1;
```

## CRUD operations
### create
```c#
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
// Mark the object for inserting, cascade addition
db.Towns.Add(town);
db.Addresses.Add(address);
db.SaveChanges();
```
### read
```c#
var towns = db.Towns
    .Where(t => t.Addresses.Any())
    .Select(t => new
    {
        t.Name,
        Addresses = t.Addresses.Select(a => a.AddressText) // nested select
    })
    .ToList(); // only one request
// use created collection
foreach (var town in towns)
{
    Console.WriteLine(town.Name);
    foreach (var addr in town.Addresses)
    {
        Console.WriteLine(addr);
    }
    Console.WriteLine(new String('-', 32));
}
```
- join tables
*with select*
```c#
var result = db.Towns
    .Select(t => new TownDataModel // create temporary object
    { 
        Name = t.Name,
        Addresses = t.Addresses.Select(a => a.AddressText)
    });
```
*with join*
```c#
var result - db.Towns
    .Join(db.Addresses,
        t => t.TownID, 
        a => a.TownID,
        (t, a) => new {
            TownName = t.Name.
            AddressTexts = a.Addresstext
        });
```

- group data
```c#
var emplGroups = db
    .Employees
    .GroupBy(e => e.Department.Name)
    .ToList();

foreach(var group in emplGroups)
{
    Console.WriteLine(group.Key);
    foreach(var employee in group)
    {
        Console.WriteLine(employee.FullName());
    }
    Console.WriteLine("==========")
}
```

### update 
- extend entity classes (use partial classes, create another file with same class)
```c#
public partial class Employee // create in EmployeeExtended.cs file
{
    public string FullName()
    {
        return this.FirstName + " " + this.LastName;
    }
}
```
- update data - use only native object (do not use select)
```c#
var employee = db.Employees.FirstOrDefault();
employee.FirstName = "Ivan";
db.SaveChanges();
```

### delete
```c#
var employees = db.Employee
.Where(e => !e.Projects.Any())
.ToList();
// Mark and delete, can be deleted if the DB lets us to do so
db.Employees.Remove(employees[0])
db.SaveChanges();
```
- to delete many things
- use Another Library *EF - Exteneded* or use *Native Query*

### native query
- beware of sql injection
```c#
string query = "SELECT count(*) FROM dbo.Customers";
var queryResult = db.Database.SqlQuery(query);
int customerCount = queryResult.FirstOrDefault();
```

## Attach and Detach from dbContext
- All called objects are followed for changes
- If we need an object to not be changed after `SaveChanges()` we detach it
```c#
var dbEntry = db.Entry(emp); // attach object 
dbEntry.State = EntityState.Added; // Deleted, Detached, Modified, Unchanged
db.SaveChanges();
```
- Attach
```c#
db.Employees.Attach(object);
db.SaveChanges();
```