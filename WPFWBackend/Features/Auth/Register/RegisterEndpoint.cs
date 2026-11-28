using Microsoft.AspNetCore.Identity;

namespace WPFWBackend.Features.Auth.Register;

public static class RegisterEndpoint
{
    public static RouteHandlerBuilder MapRegisterEndpoint(this RouteGroupBuilder group)
    {
        return group.MapPost("/register", async Task<IResult> (RegisterRequest request, RegisterHandler handler) =>
        {
            var (result, response) = await handler.HandleAsync(request);

            return result.Succeeded
                ? TypedResults.Ok(response)                                     // 200 + id en e-mail
                : TypedResults.ValidationProblem(ToDictionary(result.Errors));  // 400
        })
        .WithName("Register");
    }

    // Zet de Identity-fouten om naar het formaat dat ValidationProblem verwacht
    private static Dictionary<string, string[]> ToDictionary(IEnumerable<IdentityError> errors)
    {
        var result = new Dictionary<string, string[]>();

        foreach (var error in errors)
        {
            result[error.Code] = [error.Description];
        }

        return result;
    }
}