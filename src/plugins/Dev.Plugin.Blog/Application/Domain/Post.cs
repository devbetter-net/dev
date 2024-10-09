namespace Dev.Plugin.Blog.Application.Domain;

public class Post
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public required Author Author { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsPublished { get; set; }
    public ICollection<CategoryPost>? CategoryPosts { get; set; }
}
