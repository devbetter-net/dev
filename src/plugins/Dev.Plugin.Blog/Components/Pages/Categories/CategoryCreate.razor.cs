using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Dev.Plugin.Blog.Application.UseCases.Categories.Commands;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Dev.Plugin.Blog.Components.Pages.Categories;

public partial class CategoryCreate : ComponentBase
{
    [Inject]
    private HttpClient HttpClient { get; set; }
    [Inject]
    private NavigationManager NavigationManager { get; set; }
    private CreateCategoryCommand Category { get; set; } = new();
    private ValidationMessageStore _validationMessageStore;
    private async Task HandleValidSubmit()
    {

        var response = await HttpClient.PostAsJsonAsync(NavigationManager.BaseUri + "api/blog/category/create", Category);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            NavigationManager.NavigateTo("/categories");
        }
        else if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
        {
            await AddErrorsToValidationStoreAsync(response);
        }
    }

    private async Task AddErrorsToValidationStoreAsync(HttpResponseMessage response)
    {
        //IReadOnlyDictionary<string, string[]> errors;
        var errorMessage = await response.Content.ReadAsStringAsync();
        // Deserialize the "errors" property
        var jsonDocument = JsonDocument.Parse(errorMessage);
        var errorsElement = jsonDocument.RootElement.GetProperty("errors");
        var errors = JsonSerializer.Deserialize<IReadOnlyDictionary<string, string[]>>(errorsElement.GetRawText());
        foreach (var error in errors)
        {
            var fieldIdentifier = new FieldIdentifier(Category, error.Key);
            // Add the error messages to the ValidationMessageStore
            _validationMessageStore.Add(fieldIdentifier, error.Value);
        }
    }
}