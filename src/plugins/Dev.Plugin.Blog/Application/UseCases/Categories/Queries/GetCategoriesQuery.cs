using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dev.Plugin.Blog.Application.UseCases.Categories.Queries;

internal class GetCategoriesQuery : IRequest<IEnumerable<CategoryListDto>>
{

}

internal class CategoryListDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}

internal class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryListDto>>
{
    private readonly IBlogDbContext _context;

    public GetCategoriesQueryHandler(IBlogDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryListDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _context.Categories
            .Select(c => new CategoryListDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync(cancellationToken);

        return categories;
    }
}