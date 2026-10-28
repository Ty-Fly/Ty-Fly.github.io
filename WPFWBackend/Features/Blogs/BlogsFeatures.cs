using WPFWBackend.Features.Blogs.CreateBlog;
using WPFWBackend.Features.Blogs.DeleteBlog;
using WPFWBackend.Features.Blogs.GetBlogs;
using WPFWBackend.Features.Blogs.GetBlog;
using WPFWBackend.Features.Blogs.UpdateBlog;

namespace WPFWBackend.Features.Blogs;
public static class BlogsFeatures
{
    public static IServiceCollection AddBlogsFeature(this IServiceCollection services)
    {
        services.AddScoped<GetBlogHandler>();
        services.AddScoped<GetBlogsHandler>();
        services.AddScoped<CreateBlogHandler>();
        services.AddScoped<UpdateBlogHandler>();
        services.AddScoped<DeleteBlogHandler>();


        return services;
    }

    public static IEndpointRouteBuilder MapBlogsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/blogs").WithTags("Blogs");

        group.MapGetBlogEndpoint();     
        group.MapGetBlogsEndpoint();
        group.MapDeleteBlogEndpoint();
        group.MapUpdateBlogEndpoint();
        group.MapCreateBlogEndpoint();    

        return app;
    }
}
