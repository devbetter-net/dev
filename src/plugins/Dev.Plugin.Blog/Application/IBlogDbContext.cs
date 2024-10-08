namespace Dev.Plugin.Blog.Application;

internal interface IBlogDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    public string GenerateCreateScript();
    Task SaveChangesAsync();
}
