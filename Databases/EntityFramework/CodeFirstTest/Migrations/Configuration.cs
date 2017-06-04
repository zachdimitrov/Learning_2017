namespace CodeFirstTest.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstTest.LibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false; // do not make it true
            AutomaticMigrationDataLossAllowed = false; // do not make it true 
        }

        protected override void Seed(CodeFirstTest.LibraryDbContext context)
        {
            context.Genres.AddOrUpdate(g => g.Name,
                new Genre
                {
                    Name = "Fantasy"
                });
        }
    }
}
