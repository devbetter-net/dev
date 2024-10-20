using System;
using MediatR;

namespace Dev.Plugin.Blog.Application.UseCases.Scripts.Queries;

internal class GetScriptsQuery : IRequest<string>
{

}

internal class GetScriptsQueryHandler : IRequestHandler<GetScriptsQuery, string>
{
    private readonly IBlogDbContext _context;

    public GetScriptsQueryHandler(IBlogDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(GetScriptsQuery request, CancellationToken cancellationToken)
    {
        return _context.GenerateCreateScript();
    }
}