using Dev.Plugin.Blog.Application.UseCases.Categories.Commands;
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

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _mediator.Send(new GetCategoriesQuery());
        return Ok(categories);
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var category = await _mediator.Send(new GetCategoryByIdQuery(id));
        return Ok(category);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var result = await _mediator.Send(new DeleteCategoryCommand { Id = id });
        return Ok(result);
    }
}