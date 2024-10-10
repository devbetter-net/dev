using MediatR;

namespace Dev.Plugin.Blog.Application.UseCases.Posts.Queries;

internal class GetPostsWithPaginationQuery : IRequest<PostDto>
{
}
