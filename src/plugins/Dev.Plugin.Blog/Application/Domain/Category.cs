namespace Dev.Plugin.Blog.Application.Domain;

public class Category
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsPublished { get; set; }
    public ICollection<CategoryPost>? CategoryPosts { get; set; }
}
