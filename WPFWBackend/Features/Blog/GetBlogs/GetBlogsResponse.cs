namespace WPFWBackend.Features.Blog.GetBlogs;
public sealed record class GetBlogsResponse(int Id, string Titel, string Inhoud, DateOnly Publicatiedatum);