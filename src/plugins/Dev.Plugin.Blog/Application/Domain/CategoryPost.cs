namespace Dev.Plugin.Blog.Application.Domain;

public class CategoryPost
{
    public Guid CategoryId { get; set; }
    public required Category Category { get; set; }
    public Guid PostId { get; set; }
    public required Post Post { get; set; }
}
