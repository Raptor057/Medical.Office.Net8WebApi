using Common.Common.Logging;
using Medical.Office.Infra.DataSources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Medical.Office.Infra
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            return services
                .AddLoggingServices(configuration)
                .AddSingleton(typeof(ConfigurationSqlDbConnectionFactory<>))
                .AddSingleton(typeof(ConfigurationSqlDbConnection<>))
                .AddSingleton<MedicalOfficeSqlLocalDB>();
        }
    }
}
