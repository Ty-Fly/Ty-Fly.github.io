using Microsoft.AspNetCore.Identity;

namespace WPFWBackend.Features.Auth.Register;

public static class RegisterEndpoint
{
    public static RouteHandlerBuilder MapRegisterEndpoint(this RouteGroupBuilder group)
    {
        return group.MapPost("/register", async Task<IResult> (RegisterRequest request, RegisterHandler handler) =>
        {
            var result = await handler.HandleAsync(request);

            return result.Succeeded
                ? TypedResults.Ok()                                   
                : TypedResults.ValidationProblem(ToDictionary(result.Errors)); 
        })
        .WithName("Register");
    }
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