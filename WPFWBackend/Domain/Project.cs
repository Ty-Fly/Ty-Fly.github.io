namespace WPFWBackend.Domain;

public sealed class Project
{
    public int Id { get; set; }
    public required string Titel { get; set; }
    public required string Beschrijving { get; set; }
    public required string Categorie { get; set; }
    public string? GithubUrl { get; set; }
    public required DateOnly Datum { get; set; }
}



