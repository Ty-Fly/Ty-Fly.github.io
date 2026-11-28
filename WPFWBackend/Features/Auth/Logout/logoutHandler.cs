using Microsoft.AspNetCore.Identity;
using WPFWBackend.Domain;

namespace WPFWBackend.Features.Auth.Logout;

public sealed class LogoutHandler
{
    private readonly SignInManager<User> _signInManager;

    public LogoutHandler(SignInManager<User> signInManager) => _signInManager = signInManager;

    public Task HandleAsync() => _signInManager.SignOutAsync();
}