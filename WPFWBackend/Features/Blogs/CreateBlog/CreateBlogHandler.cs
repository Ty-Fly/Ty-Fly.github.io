using WPFWBackend.Data;
using WPFWBackend.Domain;
using Microsoft.EntityFrameworkCore;

namespace WPFWBackend.Features.Blogs.CreateBlog;

public sealed class CreateBlogHandler
{
    private readonly WPFWDb _db;

    public CreateBlogHandler(WPFWDb db) => _db = db;

    public async Task<CreateBlogResponse> HandleAsync(CreateBlogRequest request, CancellationToken token)
    {
        var blog = new Blog
        {
            Titel = request.Titel,
            Inhoud = request.Inhoud,
            Publicatiedatum = request.Publicatiedatum!.Value
        };

        _db.Blogs.Add(blog);
        await _db.SaveChangesAsync(token);

        return new CreateBlogResponse(blog.Id, blog.Titel, blog.Inhoud,
            blog.Publicatiedatum);
    }
}
