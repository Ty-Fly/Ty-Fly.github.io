namespace WPFWBackend.Domain;

public sealed class Blog
{
    public int Id { get; set; }
    public required string Titel { get; set; }
    public required string Inhoud { get; set; }
    public required DateOnly Publicatiedatum { get; set; }
}



