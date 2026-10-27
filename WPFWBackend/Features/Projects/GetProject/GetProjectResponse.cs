namespace WPFWBackend.Features.Projects.GetProject;

public sealed record GetProjectResponse(int Id, string Titel, string Beschrijving, string Categorie, string? GithubUrl, DateOnly Datum);