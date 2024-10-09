namespace Dev.Plugin.Blog.Application.Domain;

public class Author
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public ICollection<Post>? Posts { get; set; }
}
