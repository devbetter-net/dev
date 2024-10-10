using Dev.Plugin.Blog.Application.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dev.Plugin.Blog.Application;

public interface IBlogDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    public string GenerateCreateScript();
    Task SaveChangesAsync();

    DbSet<Author> Authors { get; }
    DbSet<Category> Categories { get; }
    DbSet<CategoryPost> CategoryPosts { get; }
    DbSet<Post> Posts { get; }
}
