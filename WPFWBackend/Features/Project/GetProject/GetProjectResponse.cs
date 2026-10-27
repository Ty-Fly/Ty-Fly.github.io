namespace WPFWBackend.Features.Project.GetProject;
public sealed record GetProjectResponse(int Id, string Titel, string Beschrijving, string Categorie, string? GithubUrl, DateOnly Datum);