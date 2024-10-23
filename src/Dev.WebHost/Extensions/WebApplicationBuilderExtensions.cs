using Dev.Common.Behaviors;
using Dev.Plugin.Blog;
using Dev.WebHost.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;

namespace Dev.WebHost.Extensions;

internal static class WebApplicationBuilderExtensions
{
    public static void ConfigureWebApplication(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        
        builder.Services.AddControllersWithViews();

        //https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-8.0
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        builder.Services.AddBlog(builder);
        builder.Services.AddHttpClient();
    }
}
