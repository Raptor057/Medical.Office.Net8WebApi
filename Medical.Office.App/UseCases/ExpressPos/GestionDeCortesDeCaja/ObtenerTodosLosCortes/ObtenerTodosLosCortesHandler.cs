using Common.Common.CleanArch;
using Medical.Office.App.Dtos.EspressPos;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerTodosLosCortes.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerTodosLosCortes;

internal sealed class ObtenerTodosLosCortesHandler : IInteractor<ObtenerTodosLosCortesRequest, ObtenerTodosLosCortesResponse>
{
    private readonly ILogger<ObtenerTodosLosCortesHandler> _logger;
    private readonly POSInterfacesRepository.ICorteService _corteService;

    public ObtenerTodosLosCortesHandler(ILogger<ObtenerTodosLosCortesHandler> logger, POSInterfacesRepository.ICorteService corteService)
    {
        _logger = logger;
        _corteService = corteService;
    }

    public async Task<ObtenerTodosLosCortesResponse> Handle(ObtenerTodosLosCortesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var cortes = await _corteService.ObtenerCortesAsync();

            if (!cortes.Any())
            {
                return new FailureObtenerTodosLosCortesResponse("No se encontraron cortes registrados.");
            }

            var response = cortes.Select(c => new CortesDto(c.CorteID, c.FechaHora, c.TotalVendido, c.TotalVentas));
            return new SuccessObtenerTodosLosCortesResponse(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todos los cortes.");
            return new FailureObtenerTodosLosCortesResponse("Error interno al obtener cortes.");
        }
    }
}