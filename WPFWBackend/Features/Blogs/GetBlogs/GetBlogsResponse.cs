namespace WPFWBackend.Features.Blogs.GetBlogs;
public sealed record GetBlogsResponse(int Id, string Titel, string Inhoud, DateOnly Publicatiedatum);