using Common.Common.CleanArch;
using Medical.Office.App.Dtos.EspressPos;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerCortesPorRango.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerCortesPorRango;

internal sealed class ObtenerCortesPorRangoHandler : IInteractor<ObtenerCortesPorRangoRequest, ObtenerCortesPorRangoResponse>
{
    private readonly ILogger<ObtenerCortesPorRangoHandler> _logger;
    private readonly POSInterfacesRepository.ICorteService _corteService;

    public ObtenerCortesPorRangoHandler(ILogger<ObtenerCortesPorRangoHandler> logger, POSInterfacesRepository.ICorteService corteService)
    {
        _logger = logger;
        _corteService = corteService;
    }

    public async Task<ObtenerCortesPorRangoResponse> Handle(ObtenerCortesPorRangoRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.FechaInicio == default || request.FechaFin == default)
        {
            return new FailureObtenerCortesPorRangoResponse("Rango de fechas no válido.");
        }

        try
        {
            var cortes = await _corteService.ObtenerCortesPorRangoAsync(request.FechaInicio, request.FechaFin);

            // Si no hay cortes, retorna una respuesta de éxito con datos vacíos
            var response = cortes.Any()
                ? cortes.Select(c => new CortesDto(c.CorteID, c.FechaHora, c.TotalVendido, c.TotalVentas))
                : Enumerable.Empty<CortesDto>();

            return new SuccessObtenerCortesPorRangoResponse(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener cortes por rango.");
            return new FailureObtenerCortesPorRangoResponse("Error interno al obtener cortes por rango.");
        }
    }

}