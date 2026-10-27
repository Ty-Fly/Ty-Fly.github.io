namespace WPFWBackend.Features.Project.GetProjects;
public sealed record GetProjectsResponse(int Id, string Titel, string Beschrijving, string Categorie, string? GithubUrl, DateOnly Datum);