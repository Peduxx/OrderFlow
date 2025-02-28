namespace OrderFlow.Api.Config;

public static class DependencyInjectionConfig
{
    public static void AddConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        NativeInjector.RegisterServices(services);
    }
}
