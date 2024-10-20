﻿using Dev.Common;
using Dev.Common.Mappings;
using MediatR;

namespace Dev.Plugin.Blog.Application.UseCases.Posts.Queries;

internal class GetPostsWithPaginationQuery : IRequest<PaginatedList<PostListItemDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
internal class GetPostsWithPaginationQueryHandler : IRequestHandler<GetPostsWithPaginationQuery, PaginatedList<PostListItemDto>>
{
    private readonly IBlogDbContext _context;

    public GetPostsWithPaginationQueryHandler(IBlogDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<PostListItemDto>> Handle(GetPostsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var posts = await _context.Posts
            .Where(p => p.IsPublished)
            .OrderByDescending(p => p.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(p => new PostListItemDto
            {
                Id = p.Id,
                Title = p.Title
            })
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return posts;
    }
}