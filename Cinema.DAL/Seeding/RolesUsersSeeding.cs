using Cinema.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Cinema.DAL.Seeding
{
    public class RolesUsersSeeding
    {
        public static async Task SeedRolesAsync(RoleManager<UserRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(
                    new UserRole { Id = Guid.NewGuid(), Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(
                    new UserRole { Id = Guid.NewGuid(), Name = "User", NormalizedName = "USER".ToUpper() });
            }
        }

        public static async Task SeedUsersAsync(UserManager<User> userManager)
        {
            // Seed Admin User
            var adminUser = new User
            {
                Id = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"), 
                UserName = "adminUser",
                Email = "adminUser@example.com",
                NormalizedUserName = "ADMINUSER",
            };

            if (userManager.Users.All(u => u.UserName != adminUser.UserName))
            {
                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded)
                {
                    // Assign the "Admin" role to the admin user
                    await userManager.AddToRoleAsync(adminUser, "Administrator");
                }
            }

            // Seed Standard User
            var standardUser = new User
            {
                Id = Guid.Parse("9c445865-a24d-4233-a6c6-9443d048cdb9"),
                UserName = "user",
                Email = "user@example.com",
                NormalizedUserName = "USER",
            };

            if (userManager.Users.All(u => u.UserName != standardUser.UserName))
            {
                var result = await userManager.CreateAsync(standardUser, "User123!");
                if (result.Succeeded)
                {
                    // Assign the "User" role to the standard user
                    await userManager.AddToRoleAsync(standardUser, "User");
                }
            }
        }
    }
}
