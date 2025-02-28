internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        var configuration = builder.Configuration;

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();

        services.AddHealthChecks();

        MediatrConfig.AddConfiguration(services);

        AutoMapperConfig.AddConfiguration(services);

        SwaggerConfig.AddConfiguration(services);

        ApiVersioningConfig.AddConfiguration(services);

        DatabaseConfig.AddConfiguration(services, configuration);

        DependencyInjectionConfig.AddConfiguration(services);

        ValidatorsConfig.AddConfiguration(services);

        services.AddControllers();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            });

            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var response = new { message = "An unexpected error occurred. Please contact support." };
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }

        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = async (context, report) =>
            {
                context.Response.ContentType = "application/json";

                var result = JsonSerializer.Serialize(new
                {
                    status = report.Status.ToString(),
                    checks = report.Entries.Select(e => new
                    {
                        name = e.Key,
                        status = e.Value.Status.ToString(),
                        exception = e.Value.Exception?.Message,
                        duration = e.Value.Duration.ToString()
                    })
                });

                await context.Response.WriteAsync(result);
            }
        });


        app.UseCors(c =>
        {
            c.AllowAnyHeader();
            c.AllowAnyMethod();
            c.AllowAnyOrigin();
        });

        app.UseHttpsRedirection();

        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseMiddleware<ApiLoggingMiddleware>();

        app.MapControllers();

        app.Run();
    }
}
