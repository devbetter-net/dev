using Dev.Plugin.Blog.Application.Domain;
using MediatR;

namespace Dev.Plugin.Blog.Application.UseCases.Categories.Commands;

public class CreateCategoryCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsPublished { get; set; }
}

internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
{
    private readonly IBlogDbContext _context;

    public CreateCategoryCommandHandler(IBlogDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        //TODO need to validate the request
        var category = new Category()
        {
            Name = request.Name,
            Description = request.Description,
            IsPublished = request.IsPublished
        };

       
        _context.Categories.Add(category);
        await _context.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}