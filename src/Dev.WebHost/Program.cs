using Dev.WebHost.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configure web application
builder.ConfigureWebApplication();

var app = builder.Build();
await app.ConfigureRequestPipelineAsync();

