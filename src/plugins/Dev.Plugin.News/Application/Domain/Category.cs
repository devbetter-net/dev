namespace Dev.Plugin.News.Application.Domain;

internal class Category
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
