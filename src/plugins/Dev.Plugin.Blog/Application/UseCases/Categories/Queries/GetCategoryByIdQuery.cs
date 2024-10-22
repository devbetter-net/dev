using System;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dev.Plugin.Blog.Application.UseCases.Categories.Queries;

internal class CategoryItemDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsPublished { get; set; }
}

internal class GetCategoryByIdQuery : IRequest<CategoryItemDto?>
{
    public GetCategoryByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}

internal class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryItemDto?>
{
    private readonly IBlogDbContext _context;

    public GetCategoryByIdQueryHandler(IBlogDbContext context)
    {
        _context = context;
    }

    public async Task<CategoryItemDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories
            .Where(c => c.Id == request.Id)
            .Select(c => new CategoryItemDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                IsPublished = c.IsPublished
            })
            .FirstOrDefaultAsync(cancellationToken);

        return category;
    }
}