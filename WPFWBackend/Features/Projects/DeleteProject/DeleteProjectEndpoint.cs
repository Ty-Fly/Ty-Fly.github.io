namespace WPFWBackend.Features.Projects.DeleteProject;

public static class DeleteProjectEndpoint
{
    public static RouteHandlerBuilder MapDeleteProjectEndpoint(this RouteGroupBuilder group)
    {
        return group.MapDelete("/{id:int}", async Task<IResult> (int id, DeleteProjectHandler handler, CancellationToken token)  =>
        {
            var isDeleted = await handler.HandleAsync(id: id, token: token);

            return isDeleted ?
             TypedResults.NoContent() :
             TypedResults.NotFound();
        })
            .WithName("DeleteProject");
    }
}
