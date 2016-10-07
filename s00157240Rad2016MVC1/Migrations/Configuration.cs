namespace s00157240Rad2016MVC1.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<s00157240Rad2016MVC1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(s00157240Rad2016MVC1.Models.ApplicationDbContext context)
        {
            var manager =
                new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));

            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole
                {
                    Name = "Admin"
                }
            );

            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole
                {
                    Name = "Club Admin"
                }
            );

            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole
                {
                    Name = "Member"
                }
            );

            PasswordHasher ps = new PasswordHasher();

            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "s00157240@mail.itsligo.ie",
                    EmailConfirmed = true,
                    JoinDate = DateTime.Now,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Mihails",
                    Surname = "Gromovs",
                    PasswordHash = ps.HashPassword("Gmihail$1")
                });

            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "IT FC Admin",
                    Email = "rad301s00157240@outlook.com",
                    EmailConfirmed = true,
                    JoinDate = DateTime.Now,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Rad",
                    Surname = "Cjupa",
                    PasswordHash = ps.HashPassword("Radcjupa$2016")
                });
            context.SaveChanges();

            ApplicationUser admin = manager.FindByEmail("s00157240@mail.itsligo.ie");
            if (admin != null)
            {
                manager.AddToRoles(admin.Id, new string[] { "Admin", "Member", "Club Admin"});
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
