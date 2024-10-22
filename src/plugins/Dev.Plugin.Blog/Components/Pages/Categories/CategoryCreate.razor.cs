using System.Net.Http.Json;
using Dev.Plugin.Blog.Application.UseCases.Categories.Commands;
using Microsoft.AspNetCore.Components;

namespace Dev.Plugin.Blog.Components.Pages.Categories;

public partial class CategoryCreate : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; }
    [Inject]
    private NavigationManager NavigationManager { get; set; }
    private CreateCategoryCommand Category { get; set; } = new();
    private async Task HandleValidSubmit()
    {

        var response = await HttpClient.PostAsJsonAsync(NavigationManager.BaseUri + "api/blog/category/create", Category);

        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            var debug = $"API error: {response.StatusCode} - {errorMessage}";
            // You can log this message or show it to the user
        }
    }
}