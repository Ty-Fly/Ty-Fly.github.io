using Microsoft.AspNetCore.Identity;
using WPFWBackend.Features.Auth;

public static class RoleSeeder
{
    public static async Task SeedRoleAsync(IServiceProvider services)
    {
        //Maak scope aan voor de RoleManager (Identity)
        await using var scope = services.CreateAsyncScope();

        var roleManager = scope.ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

        foreach (var role in Roles.All)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}