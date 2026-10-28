namespace WPFWBackend.Features.Blogs.GetBlogs;

public static class GetBlogsEndpoint
{
    public static RouteHandlerBuilder MapGetBlogsEndpoint(this RouteGroupBuilder group)
    {
        return group.MapGet("", async Task<IResult> (GetBlogsHandler handler, CancellationToken token) =>
        {
            var blogs = await handler.HandleAsync(token);


            return TypedResults.Ok(blogs);

        })
            .WithName("GetBlogs");
    }
}
