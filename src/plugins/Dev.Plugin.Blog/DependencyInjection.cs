using Dev.Plugin.Blog.Application;
using Dev.Plugin.Blog.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dev.Plugin.Blog;

public static class DependencyInjection
{
    public static void UseBlog(this IApplicationBuilder app)
    {

    }
    public static void AddBlog(this IServiceCollection services, WebApplicationBuilder builder)
    {

        //mysql
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
        services.AddScoped<IBlogDbContext, BlogDbContext>(provider =>
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new BlogDbContext(optionsBuilder.Options);
        });

        // Register MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Register FluentValidation validators from the current assembly
        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        //services.RegisterValidators();
    }
    private static void RegisterValidators(this IServiceCollection services)
    {

        //services.AddValidatorsFromAssemblyContaining<CreateCategoryValidator>();        
    }

}
