using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace Medical.Office.App.Services.BackgroundService
{
    public class MedicalAppointmentCalendarHostedService : IHostedService
    {
        private readonly ILogger<MedicalAppointmentCalendarHostedService> _logger;
        private readonly IPatientsData _patients;
        private Timer? _timer;

        public MedicalAppointmentCalendarHostedService(ILogger<MedicalAppointmentCalendarHostedService> logger, IPatientsData patients)
        {
            _logger=logger;
            _patients = patients;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Medical Appointment Calendar Background Worker started.");

            // Configura el Timer para ejecutar la tarea periódicamente.
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
            return Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {
            await _patients.UpdateAppointmentStatusAsync().ConfigureAwait(false);
            _logger.LogInformation($"Appointment Status Update: {DateTimeOffset.Now}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogWarning("Medical Appointment Calendar Background Worker is stopping.");
            _timer?.Change(Timeout.Infinite, 0); // Detiene el Timer.
            return Task.CompletedTask;
        }
    }
}
