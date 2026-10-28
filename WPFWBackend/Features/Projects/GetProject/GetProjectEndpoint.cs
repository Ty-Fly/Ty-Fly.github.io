namespace WPFWBackend.Features.Projects.GetProject;

public static class GetProjectEndpoint
{
    public static RouteHandlerBuilder MapGetProjectEndpoint(this RouteGroupBuilder group)
    {
        return group.MapGet("/{id:int}", async Task<IResult> (int id, GetProjectHandler handler, CancellationToken token)  =>
        {
            var project = await handler.HandleAsync(id: id, token: token);

            return project is null ?
             TypedResults.NotFound() :
             TypedResults.Ok(project);

        })
            .WithName("GetProject");
    }
}
