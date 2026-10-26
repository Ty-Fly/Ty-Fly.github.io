using Microsoft.EntityFrameworkCore;
using WPFWBackend.Domain;

namespace WPFWBackend.Data;
public class WPFWDb : DbContext
{
    public WPFWDb(DbContextOptions<WPFWDb> options)
        : base(options) { }

    public DbSet<Project> Projects => Set<Project>();

    public DbSet<Blog> Blogs => Set<Blog>();
}