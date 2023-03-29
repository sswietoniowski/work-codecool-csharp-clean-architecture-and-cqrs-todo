using Microsoft.EntityFrameworkCore;

using Polly;

using TodoApp.Api;
using TodoApp.Application;
using TodoApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMinimalApiEndpoints();

const int MAX_RETRIES = 7;
const int RETRY_DELAY_IN_SECONDS = 15;
var retryPolicy = Policy.Handle<Exception>()
    .WaitAndRetryAsync(retryCount: MAX_RETRIES,
        sleepDurationProvider: (attemptCount) => TimeSpan.FromSeconds(RETRY_DELAY_IN_SECONDS));

await retryPolicy.ExecuteAsync(async () =>
{
    var context = (app as IApplicationBuilder)
        ?.ApplicationServices
        .CreateScope().ServiceProvider
        .GetRequiredService<BaseTodoContext>()
        ?? throw new InvalidOperationException("Invalid application builder");

    if ((await context.Database.GetPendingMigrationsAsync()).Any())
    {
        await context.Database.MigrateAsync();
    }
});

app.Run();

