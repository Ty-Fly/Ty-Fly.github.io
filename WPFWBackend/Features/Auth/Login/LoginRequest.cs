using System.ComponentModel.DataAnnotations;

namespace WPFWBackend.Features.Auth.Login;

public sealed record LoginRequest
{
    [Required(ErrorMessage = "{0} is verplicht")]
    [EmailAddress(ErrorMessage = "{0} moet een geldig e-mailadres zijn!")]
    public string Email { get; init; } = string.Empty;

    [Required(ErrorMessage = "{0} is verplicht")]
    public string Password { get; init; } = string.Empty;
}