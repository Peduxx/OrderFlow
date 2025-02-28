namespace OrderFlow.CrossCutting;

public static class NativeInjector
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Infrastructure - Data
        services.AddScoped<IOrderRepository, OrderRepository>();

        // Application - Services
        services.AddScoped<IPaymentService, PaymentService>();
    }
}
