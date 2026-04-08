using Dynamic_Schema_Social_Platform.Enteties;
using Microsoft.AspNetCore.Identity;

namespace Dynamic_Schema_Social_Platform.Data.DataSeeding
{
    public class Roles
    {
        public static async Task SeedAdminAsync(
            UserManager<User> userManager,
            RoleManager<IdentityRole<int>> roleManager)
        {
            // Create Roles
            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole<int>("Admin"));

            if (!await roleManager.RoleExistsAsync("User"))
                await roleManager.CreateAsync(new IdentityRole<int>("User"));

            // Create Admin
            var adminEmail = "admin@talent.com";
            var admin = await userManager.FindByEmailAsync(adminEmail);

            if (admin == null)
            {
                admin = new User
                {
                    UserName = "admin",
                    Email = adminEmail,
                    EmailConfirmed = true,
                    CreatedAt = DateTime.UtcNow
                };

                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
