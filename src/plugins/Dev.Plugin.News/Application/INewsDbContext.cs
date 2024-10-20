using System;

namespace Dev.Plugin.News.Application;

public interface INewsDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    public string GenerateCreateScript();
    Task SaveChangesAsync();
}
