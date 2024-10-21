using Dev.Common.Exceptions;
using Dev.Plugin.Blog.Application.Domain;
using MediatR;

namespace Dev.Plugin.Blog.Application.UseCases.Categories.Commands;

public class UpdateCategoryCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsAction { get; set; }
}

internal class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Guid>
{
    private readonly IBlogDbContext _context;

    public UpdateCategoryCommandHandler(IBlogDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        //TODO need to validate the request
        var category = await _context.Categories.FindAsync(request.Id);
        if (category == null)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        category.Name = request.Name;
        category.Description = request.Description;
        category.IsAction = request.IsAction;

        await _context.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}

