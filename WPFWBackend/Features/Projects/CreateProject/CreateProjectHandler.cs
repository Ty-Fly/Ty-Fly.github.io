using WPFWBackend.Data;
using WPFWBackend.Domain;
using Microsoft.EntityFrameworkCore;

namespace WPFWBackend.Features.Projects.CreateProject;

public sealed class CreateProjectHandler
{
    private readonly WPFWDb _db;

    public CreateProjectHandler(WPFWDb db) => _db = db;

    public async Task<CreateProjectResponse> HandleAsync(CreateProjectRequest request ,CancellationToken ct)
    {
        var project = new Project
        {
            Titel = request.Titel,
            Beschrijving = request.Beschrijving,
            Categorie = request.Categorie,
            GithubUrl = request.GithubUrl,
            Datum = request.Datum!.Value
        };

        

        _db.Projects.Add(project);
        await _db.SaveChangesAsync(ct);

        return new CreateProjectResponse(project.Id, project.Titel, project.Beschrijving,
            project.Categorie, project.GithubUrl, project.Datum);

    }

}
