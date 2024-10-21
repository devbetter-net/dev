using Dev.Common.Exceptions;
using Dev.Plugin.Blog.Application.Domain;
using MediatR;

namespace Dev.Plugin.Blog.Application.UseCases.Categories.Commands;

public class DeleteCategoryCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
}

internal class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Guid>
{
    private readonly IBlogDbContext _context;

    public DeleteCategoryCommandHandler(IBlogDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FindAsync(request.Id);
        if (category == null)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync(cancellationToken);
        return category.Id;
    }
}