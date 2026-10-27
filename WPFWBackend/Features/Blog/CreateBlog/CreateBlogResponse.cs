namespace WPFWBackend.Features.Blog.CreateBlog;
public sealed record CreateBlogResponse(public int Id, public string Titel, public string Inhoud, public DateOnly Publicatiedatum);