namespace WPFWBackend.Features.Projects.GetProjects;

public sealed record GetProjectsResponse(int Id, string Titel, string Beschrijving, string Categorie, string? GithubUrl, DateOnly Datum);