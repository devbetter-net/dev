namespace Dev.Plugin.Blog.Application.UseCases.Posts;

internal class PostDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
}
