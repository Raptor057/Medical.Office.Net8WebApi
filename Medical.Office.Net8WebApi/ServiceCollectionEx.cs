using Common.Common.CleanArch;
using Medical.Office.Infra;
using Medical.Office.App;
namespace Medical.Office.Net8WebApi
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Detectar el entorno desde las variables de entorno
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true) // Cargar configuración específica del entorno
                .AddEnvironmentVariables() // Permitir configuración desde variables de entorno
                .Build();

            return services
                .AddSingleton(config)
                .AddInfraServices(config)
                .AddSingleton(typeof(ResultViewModel<>))
                .AddSingleton(typeof(GenericViewModel<>))
                .AddAppServices()
                .AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionEx).Assembly); });
        }
    }
}
