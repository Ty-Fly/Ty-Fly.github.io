using WPFWBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace WPFWBackend.Features.Projects.UpdateProject;

public sealed class UpdateProjectHandler
{
    private readonly WPFWDb _db;

    public UpdateProjectHandler(WPFWDb db) => _db = db;

    public async Task<bool> HandleAsync(int id, UpdateProjectRequest request, CancellationToken token)
    {

        var project = await _db.Projects
            .FirstOrDefaultAsync(project => project.Id == id, token);

        if (project is null)
            return false;



        project.Titel = request.Titel;
        project.Beschrijving = request.Beschrijving;
        project.Categorie = request.Categorie;
        project.GithubUrl = request.GithubUrl;
        project.Datum = request.Datum!.Value;

        await _db.SaveChangesAsync(token);

        return true;

    }

}
