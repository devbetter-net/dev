namespace Dev.Plugin.Blog.Application.UseCases.Posts;

internal class PostListItemDto
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
}
