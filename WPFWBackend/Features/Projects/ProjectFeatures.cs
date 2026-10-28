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
        var group = app.MapGroup("/api/projects").WithTags("Projects");

        group.MapGetProjectEndpoint();     
        group.MapGetProjectsEndpoint();
        group.MapDeleteProjectEndpoint();
        group.MapUpdateProjectEndpoint();
        group.MapCreateProjectEndpoint();    

        return app;
    }
}
