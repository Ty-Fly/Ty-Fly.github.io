using WPFWBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace WPFWBackend.Features.Blogs.UpdateBlog;

public sealed class UpdateBlogHandler
{
    private readonly WPFWDb _db;

    public UpdateBlogHandler(WPFWDb db) => _db = db;

    public async Task<bool> HandleAsync(int id, UpdateBlogRequest request, CancellationToken token)
    {

        var blog = await _db.Blogs
            .FirstOrDefaultAsync(blog => blog.Id == id, token);

        if (blog is null)
            return false;



        blog.Titel = request.Titel;
        blog.Inhoud = request.Inhoud;
        blog.Publicatiedatum = request.Publicatiedatum!.Value;

        await _db.SaveChangesAsync(token);

        return true;

    }

}
