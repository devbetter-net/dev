using Dev.Plugin.Blog.Application;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dev.Plugin.Blog.Infrastructure.Data;

internal class BlogDbContext : DbContext, IBlogDbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public string GenerateCreateScript()
    {
        return base.Database.GenerateCreateScript();
    }

    public async Task SaveChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}
