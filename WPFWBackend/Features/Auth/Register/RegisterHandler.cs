using Microsoft.AspNetCore.Identity;
using WPFWBackend.Domain;

namespace WPFWBackend.Features.Auth.Register;

public sealed class RegisterHandler
{
    private readonly UserManager<User> _userManager;

    public RegisterHandler(UserManager<User> userManager) => _userManager = userManager;

    // Geeft het IdentityResult terug (gelukt/fouten) en bij succes de response
    public async Task<(IdentityResult Result, RegisterResponse? Response)> HandleAsync(RegisterRequest request)
    {
        var user = new User
        {
            UserName = request.Email,   // verplicht voor Identity; inloggen gaat via UserName
            Email = request.Email
        };

        // Maakt de gebruiker aan en slaat alleen de HASH van het wachtwoord op
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return (result, null);

        // Iedere nieuwe gebruiker wordt Gast – nooit Editor/Admin via publieke registratie
        result = await _userManager.AddToRoleAsync(user, Roles.Gast);
        if (!result.Succeeded)
            return (result, null);

        // Rollen uit de database (AspNetUserRoles), niet hardcoded
        var roles = await _userManager.GetRolesAsync(user);

        return (result, new RegisterResponse(user.Id, user.Email!, roles));
    }
}