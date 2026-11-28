using Microsoft.AspNetCore.Identity;
using WPFWBackend.Domain;

namespace WPFWBackend.Features.Auth.Login;

public sealed class LoginHandler
{
    private readonly SignInManager<User> _signInManager;

    public LoginHandler(SignInManager<User> signInManager) => _signInManager = signInManager;

    public async Task<bool> HandleAsync(LoginRequest request)
    {

        var result = await _signInManager.PasswordSignInAsync(
            request.Email,              
            request.Password,
            isPersistent: true,         
            lockoutOnFailure: true);    

        return result.Succeeded;
    }
}