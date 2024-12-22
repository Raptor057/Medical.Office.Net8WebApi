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

                // Repositorios generales
                .AddSingleton<IUsersRepository, UsersRepository>()
                .AddSingleton<IConfigurationsRepository, ConfigurationsRepository>()
                .AddSingleton<IPatientsData, PatientsData>()
                .AddSingleton<IAntecedentPatient, AntecedentPatientRepository>()

                // Repositorios y servicios de ExpressPos
                .AddSingleton<POSInterfacesRepository.IProductoService, ExpressPosRepository>()
                .AddSingleton<POSInterfacesRepository.IVentaService, ExpressPosRepository>()
                .AddSingleton<POSInterfacesRepository.ICorteService, ExpressPosRepository>()
                .AddSingleton<POSInterfacesRepository.IReporteService, ExpressPosRepository>();
        }
    }
}
