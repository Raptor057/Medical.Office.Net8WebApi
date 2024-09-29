using Common.Common.Logging;
using Medical.Office.Domain.Repository;
using Medical.Office.Infra.DataSources;
using Medical.Office.Infra.Repositories;
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
                .AddSingleton<MedicalOfficeSqlLocalDB>()
                .AddSingleton<IUsersRepository, UsersRepository>()
                .AddSingleton<IConfigurationsRepository, ConfigurationsRepository>()
                .AddSingleton<IPatientsData, PatientsData>();
        }
    }
}
