
namespace WPFWBackend.Features.Blogs.UpdateBlog;

public static class UpdateProjectEndpoint
{
     public static RouteHandlerBuilder MapUpdateBlogEndpoint(this RouteGroupBuilder group)
    {
        return group.MapPut("/{id:int}", async Task<IResult> (int id, UpdateBlogRequest request, UpdateBlogHandler handler, CancellationToken token) =>
        {
            var updated = await handler.HandleAsync(id, request, token);
            return updated
                ? TypedResults.NoContent()
                : TypedResults.NotFound();

        })
            .WithName("UpdateProject");
    }
}
