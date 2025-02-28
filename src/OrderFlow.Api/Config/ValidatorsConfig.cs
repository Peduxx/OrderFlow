namespace OrderFlow.Api.Config;

public static class ValidatorsConfig
{
    public static void AddConfiguration(this IServiceCollection services)
    {
        services.AddTransient<IValidator<CreateOrderCommand>, CreateOrderCommandValidator>();
        services.AddTransient<IValidator<UpdatePaymentInformationCommand>, UpdatePaymentInformationCommandValidator>();
        services.AddTransient<IValidator<UpdatePaymentStatusCommand>, UpdatePaymentStatusCommandValidator>();
        services.AddTransient<IValidator<UpdateShippingInformationCommand>, UpdateShippingInformationCommandValidator>();
        services.AddTransient<IValidator<UpdateShippingStatusCommand>, UpdateShippingStatusCommandValidator>();
    }
}

