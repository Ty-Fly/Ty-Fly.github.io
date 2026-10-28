namespace WPFWBackend.Features.Projects.GetProjects;

public static class GetProjectsEndpoint
{
    public static RouteHandlerBuilder MapGetProjectsEndpoint(this RouteGroupBuilder group)
    {
        return group.MapGet("", async Task<IResult> (GetProjectsHandler handler, CancellationToken token) =>
        {
            var projects = await handler.HandleAsync(token: token);


            return TypedResults.Ok(projects);

        })
            .WithName("GetProjects");
    }
}
