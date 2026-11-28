using Microsoft.AspNetCore.Identity;
using WPFWBackend.Domain;

namespace WPFWBackend.Features.Auth;

public static class UserSeeder
{
    public static async Task SeedUsersAsync(IServiceProvider services, IConfiguration configuration)
    {
        await using var scope = services.CreateAsyncScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        await SeedUserAsync(userManager, configuration.GetSection("SeedUsers:Admin"), Roles.Admin);
        await SeedUserAsync(userManager, configuration.GetSection("SeedUsers:Editor"), Roles.Editor);
    }

    private static async Task SeedUserAsync(UserManager<User> userManager, IConfigurationSection section, string role)
    {
        var email = section["Email"];
        var password = section["Password"];

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            return;

        var user = await userManager.FindByEmailAsync(email);
        if (user is null)
        {
            user = new User
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var createResult = await userManager.CreateAsync(user, password);
            if (!createResult.Succeeded)
            {
                var errors = string.Join(", ", createResult.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Seed-gebruiker {email} kon niet worden aangemaakt: {errors}");
            }
        }

        // Rol toekennen als de gebruiker die nog niet heeft
        if (!await userManager.IsInRoleAsync(user, role))
        {
            await userManager.AddToRoleAsync(user, role);
        }
    }
}