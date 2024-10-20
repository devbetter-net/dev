using Dev.Plugin.Blog.Application.UseCases.Scripts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Plugin.Blog.Controllers;


public class HomeController : PublicController
{
    private readonly IMediator _mediator;

    public HomeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Scripts()
    {
        var scripts = await _mediator.Send(new GetScriptsQuery());
        return Ok(scripts);
    }
}

