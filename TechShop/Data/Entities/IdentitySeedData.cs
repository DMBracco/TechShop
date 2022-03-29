using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TechShop.Data.Entities
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {

            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<StoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                user.Email = "admin@example.com";
                user.PhoneNumber = "555-1234";
                IdentityResult result = await userManager.CreateAsync(user, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "admin");
                }
            }

            IdentityUser user1 = await userManager.FindByIdAsync("User");
            if (user1 == null)
            {
                user1 = new IdentityUser("User");
                user1.Email = "user@mail.com";
                user1.PhoneNumber = "543355-1234";
                await userManager.CreateAsync(user1, "Qwerty123$");
            }
        }
    }
}
