using Microsoft.EntityFrameworkCore;
using WPFWBackend.Data;

namespace WPFWBackend.Features.Projects.GetProjects;

public sealed class GetProjectsHandler
{
    private readonly WPFWDb _db;

    public GetProjectsHandler(WPFWDb db) => _db = db;

    public async Task<List<GetProjectsResponse>> HandleAsync(CancellationToken cancellationToken)
    {

        var projects = await _db.Projects
            .AsNoTracking()
            .OrderBy(project => project.Id)
            .Select(project => new GetProjectsResponse(project.Id ,project.Titel, project.Beschrijving, project.Categorie, project.GithubUrl, project.Datum))
            .ToListAsync(cancellationToken);

        return projects;
    }
}

