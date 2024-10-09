using Dev.Plugin.Blog.Application.Domain;
using MediatR;

namespace Dev.Plugin.Blog.Application.UseCases.Categories.Commands;

internal class CreateCategoryCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsAction { get; set; }
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
            IsAction = request.IsAction
        };

       
        _context.Categories.Add(category);
        await _context.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}