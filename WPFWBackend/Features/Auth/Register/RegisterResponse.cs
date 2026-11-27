namespace WPFWBackend.Features.Auth.Register;

public sealed record RegisterResponse(string Id, string Email, string[] Roles);