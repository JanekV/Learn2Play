using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace DAL.App.EF
{
    public class SeedUsers
    {
        public static void SeedInitUsers(AppDbContext ctx, UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("DbAdmin").Result)
            {
                var dbRole = new AppRole {Name = "DbAdmin"};
                var dbRoleResult = roleManager.CreateAsync(dbRole).Result;
            }

            ctx.SaveChanges();
            
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var adminRole = new AppRole {Name = "Admin"};
                var adminRoleResult = roleManager.CreateAsync(adminRole).Result;
            }
            ctx.SaveChanges();
            
            if (userManager.FindByEmailAsync("db@admin").Result == null)
            {
                var dbAdmin = new AppUser {Email = "db@admin"};
                dbAdmin.UserName = dbAdmin.Email;
                var result = userManager.CreateAsync(dbAdmin, "Password").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(dbAdmin, "DbAdmin").Wait();
                }
            }
            ctx.SaveChanges();
            if (userManager.FindByEmailAsync("a@admin").Result == null)
            {
                var admin = new AppUser {Email = "a@admin"};
                admin.UserName = admin.Email;
                var result = userManager.CreateAsync(admin, "Password1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, "Admin").Wait();
                }
            }
            ctx.SaveChanges();
        }
    }
}