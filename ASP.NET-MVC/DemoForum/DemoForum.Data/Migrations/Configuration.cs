namespace DemoForum.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DemoForum.Data.MsSqlDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MsSqlDbContext context)
        {
            const string AdministratorUserName = "info@telerikacademy.com";
            const string AdministratorPassword = "123456";

            this.SeedAdmin(context, AdministratorUserName, AdministratorPassword);
            this.SampleData(context, AdministratorUserName);
        }

        private void SeedAdmin(MsSqlDbContext context, string AdministratorUserName, string AdministratorPassword)
        {
            if (!context.Roles.Any())
            {
                var roleName = "Admin";

                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = roleName };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, roleName);
            }
        }

        private void SampleData(MsSqlDbContext context, string userName)
        {
            if (!context.Posts.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var post = new Post()
                    {
                        Title = "Post " + i,
                        Content = "Bacon ipsum dolor amet brisket jowl shankle meatloaf salami biltong jerky shoulder drumstick, ball tip bresaola prosciutto ham hock venison. Swine tail prosciutto meatloaf, sausage pork belly kevin pork chop.",
                        Author = context.Users.First(x => x.Email == userName),
                        CreatedOn = DateTime.Now
                    };

                    context.Posts.Add(post);
                }
            }
        }
    }
}
