namespace Dev.WebHost.Extensions;

internal static class WebApplicationBuilderExtensions
{
    public static void ConfigureWebApplication(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
    }
}
