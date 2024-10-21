using Dev.Plugin.Blog;

namespace Dev.WebHost.Extensions;

internal static class WebApplicationBuilderExtensions
{
    public static void ConfigureWebApplication(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        
        builder.Services.AddControllersWithViews(); 
        
        builder.Services.AddBlog(builder);
        builder.Services.AddHttpClient();
    }
}
