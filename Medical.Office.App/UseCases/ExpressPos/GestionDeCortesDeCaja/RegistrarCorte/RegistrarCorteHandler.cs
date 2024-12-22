using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.RegistrarCorte.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.RegistrarCorte;

internal sealed class RegistrarCorteHandler : IInteractor<RegistrarCorteRequest, RegistrarCorteResponse>
{
    private readonly ILogger<RegistrarCorteHandler> _logger;
    private readonly POSInterfacesRepository.ICorteService _corteService;

    public RegistrarCorteHandler(ILogger<RegistrarCorteHandler> logger, POSInterfacesRepository.ICorteService corteService)
    {
        _logger = logger;
        _corteService = corteService;
    }

    public async Task<RegistrarCorteResponse> Handle(RegistrarCorteRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.TotalVendido < 0 || request.TotalVentas < 0)
        {
            return new FailureRegistrarCorteResponse("Datos no válidos para registrar el corte.");
        }

        try
        {
            await _corteService.RegistrarCorteAsync(request.TotalVendido, request.TotalVentas);
            return new SuccessRegistrarCorteResponse(request.FechaHora, request.TotalVendido, request.TotalVentas);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al registrar el corte.");
            return new FailureRegistrarCorteResponse("Error interno al registrar el corte.");
        }
    }
}