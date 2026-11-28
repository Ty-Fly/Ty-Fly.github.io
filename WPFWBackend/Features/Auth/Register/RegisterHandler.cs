using Microsoft.AspNetCore.Identity;
using WPFWBackend.Domain;

namespace WPFWBackend.Features.Auth.Register;

public sealed class RegisterHandler
{
    private readonly UserManager<User> _userManager;

    public RegisterHandler(UserManager<User> userManager) => _userManager = userManager;

    public async Task<(IdentityResult Result, RegisterResponse? Response)> HandleAsync(RegisterRequest request)
    {
        var user = new User
        {
            UserName = request.Email,   
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return (result, null);

        result = await _userManager.AddToRoleAsync(user, Roles.Gast);
        if (!result.Succeeded)
            return (result, null);

        var roles = await _userManager.GetRolesAsync(user);

        return (result, new RegisterResponse(user.Id, user.Email!));
    }
    
}