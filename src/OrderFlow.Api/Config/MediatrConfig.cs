namespace OrderFlow.Api.Config;

public static class MediatrConfig
{
    public static void AddConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(CreateOrderCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(UpdatePaymentInformationCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(UpdatePaymentStatusCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(UpdateShippingInformationCommand).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(UpdateShippingStatusCommand).Assembly);
        });
    }
}