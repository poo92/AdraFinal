namespace AdraFullTestFinal.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AdraFullTestFinal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AdraFullTestFinal.Models.ApplicationDbContext";
        }

        protected override void Seed(AdraFullTestFinal.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            

            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "normaluser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "normaluser" };
                manager.Create(role);
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));         
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            ApplicationUser adminUser = userManager.FindByName("admin@gmail.com");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    
                };
                IdentityResult userResult = userManager.Create(adminUser, "admin@123");
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(adminUser.Id, "admin");
                }
            }


            ApplicationUser normalUser = userManager.FindByName("user@gmail.com");
            if (normalUser == null)
            {
                normalUser = new ApplicationUser()
                {
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com",

                };
                IdentityResult userResult = userManager.Create(normalUser, "user@123");
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(normalUser.Id, "normaluser");
                }
            }


        }
    }
}
