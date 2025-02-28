using OrderFlow.Domain.Primitives;

namespace OrderFlow.Api.Config;

public static class DatabaseConfig
{
    public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddSingleton<IMongoClient>(serviceProvider =>
        {
            var connectionString = configuration.GetConnectionString("MongoConnection");
            return new MongoClient(connectionString);
        });

        services.AddScoped<IMongoDatabase>(serviceProvider =>
        {
            var client = serviceProvider.GetRequiredService<IMongoClient>();
            return client.GetDatabase("ordersdb");
        });

        services.AddScoped<IMongoCollection<Order>>(serviceProvider =>
        {
            var database = serviceProvider.GetRequiredService<IMongoDatabase>();
            return database.GetCollection<Order>("orders");
        });

        services.AddScoped<IMongoCollection<IDomainEvent>>(serviceProvider =>
        {
            var database = serviceProvider.GetRequiredService<IMongoDatabase>();
            return database.GetCollection<IDomainEvent>("events");
        });
    }
}
