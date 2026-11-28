namespace WPFWBackend.Features.Auth.Login;

public static class LoginEndpoint
{
    public static RouteHandlerBuilder MapLoginEndpoint(this RouteGroupBuilder group)
    {
        return group.MapPost("/login", async Task<IResult> (LoginRequest request, LoginHandler handler) =>
        {
            var succeeded = await handler.HandleAsync(request);

            return succeeded
                ? TypedResults.Ok()   
                : TypedResults.Problem("Ongeldige inloggegevens.", statusCode: StatusCodes.Status401Unauthorized);
        })
        .WithName("Login");
    }
}