using Microsoft.EntityFrameworkCore;
using WPFWBackend.Domain;

class WPFWDb : DbContext
{
    public WPFWDb(DbContextOptions<WPFWDb> options)
        : base(options) { }

    public DbSet<Project> Projects => Set<Project>();

    public DbSet<Blog> Blogs => Set<Blog>();
}