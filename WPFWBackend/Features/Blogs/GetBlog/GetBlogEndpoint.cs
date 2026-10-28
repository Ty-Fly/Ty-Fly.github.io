namespace WPFWBackend.Features.Blogs.GetBlog;

public static class GetBlogEndpoint
{
    public static RouteHandlerBuilder MapGetBlogEndpoint(this RouteGroupBuilder group)
    {
        return group.MapGet("/{id:int}", async Task<IResult> (int id, GetBlogHandler handler, CancellationToken token)  =>
        {
            var blog = await handler.HandleAsync(id, token);

            return blog is null ?
             TypedResults.NotFound() :
             TypedResults.Ok(blog);

        })
            .WithName("GetBlog");
    }
}
