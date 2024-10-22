using System.Net.Http.Json;
using Dev.Plugin.Blog.Application.UseCases.Categories.Queries;
using Microsoft.AspNetCore.Components;

namespace Dev.Plugin.Blog.Components.Pages.Categories;

public partial class CategoryList : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; }
    [Inject]
    private NavigationManager NavigationManager { get; set; }

    private IEnumerable<CategoryListDto> Categories { get; set; }   
    protected override async Task OnInitializedAsync()
    {
        await LoadCategories();
    }
    private async Task LoadCategories()
    {
        Categories = await HttpClient.GetFromJsonAsync<IEnumerable<CategoryListDto>>(NavigationManager.BaseUri + "api/blog/category/getall");
    }
}
