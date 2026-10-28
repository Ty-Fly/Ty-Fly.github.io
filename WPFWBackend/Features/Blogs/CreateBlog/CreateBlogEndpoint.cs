namespace WPFWBackend.Features.Blogs.CreateBlog;

public static class CreateBlogEndpoint
{
    public static RouteHandlerBuilder MapCreateBlogEndpoint(this RouteGroupBuilder group) 
    {
        return group.MapPost("", async Task<IResult> (CreateBlogRequest request, CreateBlogHandler handler, CancellationToken token) =>
        {
          var createdBlog = await handler.HandleAsync(request, token);

            return TypedResults.CreatedAtRoute(createdBlog, "GetBlog", new { id = createdBlog.Id });

        })
        .WithName("CreateBlog");
    }
}
