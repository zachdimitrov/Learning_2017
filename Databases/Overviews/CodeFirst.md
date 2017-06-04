# Entity Framework with Code First

## Startup
- creatte the main project `CodeFirstTest` for example
- using the **Package Manager Console** install EF - `PM> Install-Package EntityFramework`
- create new project - class library (.NET Framework) - `CodeFirstTest.Models` for models

## Create Code First Models
- plain C# classes
- when we have one to many we add collections like this
```c#
public virtual ICollection<Genre> Genres { get; set; }
```
- when we have many to one we add the class we want to use inside our class
```c#
public virtual Author Author { get; set; }
```

## Create DbContext Classs
- in the main project create `LibraryDbContext.cs` class (Library is our DB name)
```c#
class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base("LibraryConnection") // link to the connection string
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
```

## Add Connection String
- open `App.config` file in main project
- under `<startup>` add `<connectionStrings>`
```xml
<connectionStrings>
  <add name="LibraryConnection"
       connectionString="Data Source=.\SQLEXPRESS; Initial Catalog=LibraryCF; Integrated Security=True"
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```

## Enable Migrations ( to make it work )
- Execute `PM> Enable-Migrations` in the **Package Manager Console**
- In the `Configuration.cs` we can add Seed - Objects that will be created (if do not exist)
```c#
protected override void Seed(CodeFirstTest.LibraryDbContext context)
{
    context.Genres.AddOrUpdate(g => g.Name, new Genre { Name = "Fantasy" });
}
```
- Execute `PM> Add-Migration`, add migration name - this creates new migration class with `Up(), Down()` methods
- We can add this to our main file, and it will create the DB
```c#
Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryDbContext, Configuration>());
// when we execute any operation DB will be created if Automatic Migration is set to true
```
- Execute `PM> Update-Database - will add to database or create it
- If we add new class, we need to add it to DB Context or other class should points to it 
- Migration classes can be deleted
- To revert update to previous migration - `PM> Update-Database -TargetMigration "Initial"` it will call Down() method

## Mapping - Attributes and Fluent API

### Attributes
```c#
using System.ComponentModel.DataAnnotations
```
- attributes can be added:
    - `[Key]` - primary key
    - `[Required]` - not Null
    - `[StringLength(40)]` - add MAX length
    - `[Index]` - Index
    - `[ForeignKey("fk_name")]` - Foreign key
    - `[Column(TypeName = "ntext")]` - Add type
    - `[ConcurencyCheck]`, `[Timestamp]`, `[ComplexType]`, `[InverseProperty]`, `[DatabaseGenerated]`, `[NotMapped]`

### Fluent API
- Override `OnModelCreating`
```c#
protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.OnGenreModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder); // always call this at the end
        }

        private void OnAutorModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasKey(genre => genre.Id);

            modelBuilder.Entity<Genre>()
                .Property(genre => genre.Name)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Name") { IsUnique = true }));
        }
```