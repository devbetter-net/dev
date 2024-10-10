using MediatR;

namespace Dev.Plugin.Blog.Application.UseCases.Posts.Commands;

internal class CreatePostCommand: IRequest<Guid>
{

}

internal class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
{
    public Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}