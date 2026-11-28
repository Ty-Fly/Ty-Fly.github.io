using WPFWBackend.Features.Auth;
using WPFWBackend.Features.Projects.CreateProject;
using WPFWBackend.Features.Projects.DeleteProject;
using WPFWBackend.Features.Projects.GetProject;
using WPFWBackend.Features.Projects.GetProjects;
using WPFWBackend.Features.Projects.UpdateProject;

namespace WPFWBackend.Features.Projects;
public static class ProjectsFeatures
{
    public static IServiceCollection AddProjectsFeature(this IServiceCollection services)
    {
        services.AddScoped<GetProjectsHandler>();
        services.AddScoped<GetProjectHandler>();
        services.AddScoped<CreateProjectHandler>();
        services.AddScoped<UpdateProjectHandler>();
        services.AddScoped<DeleteProjectHandler>();

        return services;
    }

    public static IEndpointRouteBuilder MapProjectsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/projects")
            .WithTags("Projects")
            .DisableCookieRedirect();   

        // Iedereen mag lezen
        group.MapGetProjectEndpoint();
        group.MapGetProjectsEndpoint();

        // Alleen rollen met policy CanEditContent
        group.MapCreateProjectEndpoint().RequireAuthorization(Policies.CanEditContent);
        group.MapUpdateProjectEndpoint().RequireAuthorization(Policies.CanEditContent);
        group.MapDeleteProjectEndpoint().RequireAuthorization(Policies.CanEditContent);

        return app;
    }
}