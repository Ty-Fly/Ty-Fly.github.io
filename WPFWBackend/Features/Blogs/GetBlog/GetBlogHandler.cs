using WPFWBackend.Data;
using Microsoft.EntityFrameworkCore;
namespace WPFWBackend.Features.Blogs.GetBlog;

public sealed class GetBlogHandler
{
    private readonly WPFWDb _db;

    public GetBlogHandler(WPFWDb db) => _db = db;

    public async Task<GetBlogResponse?> HandleAsync(int id, CancellationToken token)
    {
        var blog = await _db.Blogs
                    .Where(blog => blog.Id == id)
                    .Select(blog => new GetBlogResponse(blog.Id, blog.Titel, blog.Inhoud,
            blog.Publicatiedatum))
                    .AsNoTracking()
                    .FirstOrDefaultAsync(token);

        return blog;
    }
}