using WPFWBackend.Data;
using Microsoft.EntityFrameworkCore;
namespace WPFWBackend.Features.Projects.DeleteProject;

public sealed class DeleteProjectHandler
{
	private readonly WPFWDb _db;

	public DeleteProjectHandler(WPFWDb db) => _db = db;

	public async Task<bool> HandleAsync(int id, CancellationToken token)
	{
		var project = await _db.Projects
			.FirstOrDefaultAsync(project => project.Id == id, token);

		if (project is null)
			return false;



		_db.Projects.Remove(project);

		await _db.SaveChangesAsync(token);

		return true;
	}
}