namespace WPFWBackend.Features.Auth.Logout;

public static class LogoutEndpoint
{
    public static RouteHandlerBuilder MapLogoutEndpoint(this RouteGroupBuilder group)
    {
        return group.MapPost("/logout", async Task<IResult> (LogoutHandler handler) =>
        {
            await handler.HandleAsync();
            return TypedResults.NoContent();   
        })
        .RequireAuthorization()                
        .WithName("Logout");
    }
}