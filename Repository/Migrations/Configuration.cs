namespace Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Diagnostics;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    internal sealed class Configuration : DbMigrationsConfiguration<Repo.Models.AdContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Repo.Models.AdContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();
            SeedRoles(context);
            SeedUsers(context);
            SeedAdvertisements(context);
            SeedCategories(context);
            SeedAdCategory(context);



        }

        private void SeedRoles(AdContext context)
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>
                (new RoleStore<IdentityRole>());

            if(!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
        }

       private void SeedUsers(AdContext context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            if (!context.Users.Any(u => u.UserName == "Admin"))
            {

                var user = new User
                {
                    UserName = "Admin"
                };
                var adminresult = manager.Create(user, "12345678");

                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Admin");

            }

        }

        private void SeedAdvertisements(AdContext context)
        {
            var idUser = context.Set<User>().Where(u => u.UserName == "Admin").FirstOrDefault().Id;
            for (int i = 1; i <= 10; i++)
            {
                var ad = new Advertisement()
                {
                    Id = i,
                UserID = idUser,
                Content = "Ad Content" + i.ToString(),
                Title = "Ad Title" + i.ToString(),
                DateOfAdd = DateTime.Now.AddDays(-i)

                };

                context.Set<Advertisement>().AddOrUpdate(ad);

            }
            context.SaveChanges();

        }

        private void SeedCategories(AdContext context)
        {
            for (int i = 1; i <=10; i++)
            {
                var category = new Category()
                {
                    Id = i,
                    CategoryName = " Category Name" + i.ToString(),
                    ParentId = i
                };
                context.Set<Category>().AddOrUpdate(category);
            }
            context.SaveChanges();
        }

        private void SeedAdCategory(AdContext context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var adcat = new AdCategory()
                {
                    Id = i,
                    AdId = i /2 +1,
                    CategoryId = i/2 +2
                };
                context.Set<AdCategory>().AddOrUpdate(adcat);
            }
            context.SaveChanges();

        }


    }
}
