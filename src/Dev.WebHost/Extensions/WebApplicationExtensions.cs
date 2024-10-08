using Dev.WebHost.Components;

namespace Dev.WebHost.Extensions;

internal static class WebApplicationExtensions
{
    public static async Task ConfigureRequestPipelineAsync(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddAdditionalAssemblies(typeof(Dev.Plugin.Blog.DependencyInjection).Assembly)
            .AddInteractiveServerRenderMode();

        await app.RunAsync();
    }
}