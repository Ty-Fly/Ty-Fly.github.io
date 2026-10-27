namespace WPFWBackend.Features.Projects.CreateProject;

public sealed record CreateProjectResponse(int Id, string Titel, string Beschrijving, string Categorie, string? GithubUrl, DateOnly Datum);