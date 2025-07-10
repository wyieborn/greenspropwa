using GreensProPWA.Shared.Entity;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace GreensProPWA.Server
{


    public static class DatabaseSeeder
    {
        public static async Task SeedAdminUserAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var adminEmail = "admin@admin.com";
            var adminPassword = "Admin@123";
            var fullName = "Admin";

            if (!await context.Users.AnyAsync(u => u.Email == adminEmail))
            {
                var adminUser = new User
                {
                    Email = adminEmail,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(adminPassword),
                    Role = "Admin",
                    FullName = fullName,
                    IsTrainer = true
                };

                context.Users.Add(adminUser);
                await context.SaveChangesAsync();
            }
        }
    }


}
