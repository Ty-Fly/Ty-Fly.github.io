namespace WPFWBackend.Features.Blogs.DeleteBlog;

public static class DeleteBlogEndpoint
{
    public static RouteHandlerBuilder MapDeleteBlogEndpoint(this RouteGroupBuilder group)
    {
        return group.MapDelete("/{id:int}", async Task<IResult> (int id, DeleteBlogHandler handler, CancellationToken token)  =>
        {
            var isDeleted = await handler.HandleAsync(id: id, token: token);

            return isDeleted ?
             TypedResults.NoContent() :
             TypedResults.NotFound();
        })
            .WithName("DeleteBlog");
    }
}
