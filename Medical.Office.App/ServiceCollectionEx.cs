using MediatR;
using Common.Common.CleanArch;
//using Medical.Office.App.Mapper;
//using Medical.Office.App.IMapper;
using Microsoft.Extensions.DependencyInjection;


namespace Medical.Office.App
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            return services
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(InteractorPipeline<,>))
                //.AddSingleton<IConfigurationsRepositoryMapper,ConfigurationsRepositoryMapper>()
                .AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionEx).Assembly); });
        }
    }
}
