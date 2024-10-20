using System.Reflection;
using Dev.Plugin.News.Application;
using Microsoft.EntityFrameworkCore;

namespace Dev.Plugin.News.Infrastructure.Data;

internal class NewsDbContext : DbContext, INewsDbContext
{
    public string GenerateCreateScript()
    {
        return base.Database.GenerateCreateScript();
    }

    public async Task SaveChangesAsync()
    {
        await base.SaveChangesAsync();
    }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
