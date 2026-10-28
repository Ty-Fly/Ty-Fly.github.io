namespace WPFWBackend.Features.Projects.UpdateProject;

public static class UpdateProjectEndpoint
{
     public static RouteHandlerBuilder MapUpdateProjectEndpoint(this RouteGroupBuilder group)
    {
        return group.MapPut("/{id:int}", async Task<IResult> (int id, UpdateProjectRequest request, UpdateProjectHandler handler, CancellationToken token) =>
        {
            var updated = await handler.HandleAsync(id, request, token);
            return updated
                ? TypedResults.NoContent()
                : TypedResults.NotFound();

        })
            .WithName("UpdateProject");
    }
}
