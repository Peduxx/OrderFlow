using OrderFlow.Api.Mapping;
using OrderFlow.Application.Mapping;

namespace OrderFlow.Api.Config
{
    public static class AutoMapperConfig
    {
        public static void AddConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(Program));
            services.AddAutoMapper(cfg => cfg.AddProfile<ApiMappingProfile>());
            services.AddAutoMapper(cfg => cfg.AddProfile<ApplicationMappingProfile>());
        }
    }
}