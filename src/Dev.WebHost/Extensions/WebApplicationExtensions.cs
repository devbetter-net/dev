using Dev.Plugin.Blog;
using Dev.WebHost.Components;

namespace Dev.WebHost.Extensions;

internal static class WebApplicationExtensions
{
    public static async Task ConfigureRequestPipelineAsync(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            //app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseExceptionHandler();
        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.MapControllers();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddAdditionalAssemblies(
                typeof(Plugin.Blog.Application.IBlogDbContext).Assembly,
                typeof(Plugin.News.Application.INewsDbContext).Assembly)
            .AddInteractiveServerRenderMode();

        app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

        app.UseBlog();

        await app.RunAsync();
    }
}