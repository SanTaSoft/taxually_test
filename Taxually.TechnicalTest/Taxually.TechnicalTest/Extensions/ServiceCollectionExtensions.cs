using Taxually.TechnicalTest.VatRegistrator;
using Taxually.TechnicalTest.VatRegistrator.VatRegistrationDataFactories;

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
