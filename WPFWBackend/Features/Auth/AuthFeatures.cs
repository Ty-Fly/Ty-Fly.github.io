using WPFWBackend.Features.Auth.Login;
using WPFWBackend.Features.Auth.Logout;
using WPFWBackend.Features.Auth.Register;

namespace WPFWBackend.Features.Auth;

public static class AuthFeatures
{
    public static IServiceCollection AddAuthFeature(this IServiceCollection services)
    {
        services.AddScoped<RegisterHandler>();
        services.AddScoped<LoginHandler>();
        services.AddScoped<LogoutHandler>();
        return services;
    }

    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auth")
            .WithTags("Auth")
            .DisableCookieRedirect();   

        group.MapRegisterEndpoint();    
        group.MapLoginEndpoint();       
        group.MapLogoutEndpoint();      

        return app;
    }
}