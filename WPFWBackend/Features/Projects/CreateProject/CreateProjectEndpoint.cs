namespace WPFWBackend.Features.Projects.CreateProject;

public static class CreateProjectEndpoint
{
    public static RouteHandlerBuilder MapCreateProjectEndpoint(this RouteGroupBuilder group) 
    {
        return group.MapPost("/{id:int}", async Task<IResult> (int id, CreateProjectRequest request, CreateProjectHandler handler, CancellationToken token) =>
        {
          var createdProject = await handler.HandleAsync(request, token);

            return TypedResults.CreatedAtRoute(createdProject, "GetProject", new { id = createdProject.Id });

        })
        .WithName("CreateProject");
    }
}
