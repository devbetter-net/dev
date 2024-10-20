using Dev.Plugin.Blog.Application.UseCases.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Plugin.Blog.Controllers;


public class CategoryController : PublicController
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    public IActionResult Index()
    {
        return Ok("Hello from CategoryController");
    }   

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _mediator.Send(new GetCategoriesQuery());
        return Ok(categories);
    }
}