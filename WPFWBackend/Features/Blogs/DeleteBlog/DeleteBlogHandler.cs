using WPFWBackend.Data;
using Microsoft.EntityFrameworkCore;
namespace WPFWBackend.Features.Blogs.DeleteBlog;

public sealed class DeleteBlogHandler
{
	private readonly WPFWDb _db;

	public DeleteBlogHandler(WPFWDb db) => _db = db;

	public async Task<bool> HandleAsync(int id, CancellationToken token)
	{
		var blog = await _db.Blogs
			.FirstOrDefaultAsync(blog => blog.Id == id, token);

		if (blog is null)
			return false;



		_db.Blogs.Remove(blog);

		await _db.SaveChangesAsync(token);

		return true;
	}
}