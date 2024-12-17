using MediatR;
using Common.Common.CleanArch;
using Microsoft.Extensions.DependencyInjection;
using Medical.Office.App.Services.BackgroundService;


namespace Medical.Office.App
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {

            return services
                .AddHostedService<MedicalAppointmentCalendarHostedService>()
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(InteractorPipeline<,>))
                .AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionEx).Assembly); });
        }
    }
}
