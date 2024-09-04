namespace TeduShop.Data.Migrations
{
    using devUTEHY.Data;
    using devUTEHY.Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<devUTEHY.Data.devUTEHYDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(devUTEHY.Data.devUTEHYDbContext context)
        {
            //CreateUser(context);
        }
        private void CreateUser(devUTEHYDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new devUTEHYDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new devUTEHYDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "vutruongit",
                Email = "vutruong2003it@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Vũ Văn Trường"

            };

            manager.Create(user, "123456");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("vutruong2003it@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
       
    }
}
