using WPFWBackend.Data;
using Microsoft.EntityFrameworkCore;
namespace WPFWBackend.Features.Projects.GetProject;

public sealed class GetProjectHandler
{
    private readonly WPFWDb _db;

    public GetProjectHandler(WPFWDb db) => _db = db;

    public async Task<GetProjectResponse?> HandleAsync(int id, CancellationToken token)
    {
        var project = await _db.Projects
                    .Where(project => project.Id == id)
                    .Select(project => new GetProjectResponse(project.Id, project.Titel, project.Beschrijving, project.Categorie, project.GithubUrl, project.Datum))
                    .AsNoTracking()
                    .FirstOrDefaultAsync(token);

        return project;
    }
}