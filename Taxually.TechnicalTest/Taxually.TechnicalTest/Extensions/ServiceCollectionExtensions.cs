using Taxually.TechnicalTest.VatRegistrator;

namespace Taxually.TechnicalTest.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddVatRegistrationService(this IServiceCollection services)
        {
            services.AddSingleton<IVatRegistrationWriterFactory, VatRegistrationFactory>()
                .AddScoped<VatRegistrationService>()
                .AddScoped<VatRegistrationValidator>();
            return services;
        }
    }
}
