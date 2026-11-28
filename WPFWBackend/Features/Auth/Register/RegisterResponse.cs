namespace WPFWBackend.Features.Auth.Register;

// Alleen veilige velden – nooit het wachtwoord of de hash teruggeven
public sealed record RegisterResponse(string Id, string Email, IList<string> Roles);