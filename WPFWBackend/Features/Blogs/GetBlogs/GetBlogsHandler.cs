using Microsoft.EntityFrameworkCore;
using WPFWBackend.Data;

namespace WPFWBackend.Features.Blogs.GetBlogs;

public sealed class GetBlogsHandler
{
    private readonly WPFWDb _db;

    public GetBlogsHandler(WPFWDb db) => _db = db;

    public async Task<List<GetBlogsResponse>> HandleAsync(CancellationToken cancellationToken)
    {

        var blogs = await _db.Blogs
            .AsNoTracking()
            .OrderBy(blog => blog.Id)
            .Select(blog => new GetBlogsResponse(blog.Id, blog.Titel, blog.Inhoud,
            blog.Publicatiedatum))
            .ToListAsync(cancellationToken);




        return blog;
    }
}

