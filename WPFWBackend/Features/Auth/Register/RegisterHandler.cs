using Microsoft.AspNetCore.Identity;
using WPFWBackend.Domain;

namespace WPFWBackend.Features.Auth.Register;

public sealed class RegisterHandler
{
    private readonly UserManager<User> _userManager;

    public RegisterHandler(UserManager<User> userManager) => _userManager = userManager;

    public async Task<IdentityResult> HandleAsync(RegisterRequest request)
    {
        var user = new User { UserName = request.Email, Email = request.Email };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return result;

        return await _userManager.AddToRoleAsync(user, Roles.Gast);
    }
}