using Common.Common.CleanArch;
using Medical.Office.App.Dtos.EspressPos;
using Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerResumenDeCortesPorDia.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerResumenDeCortesPorDia;

internal sealed class ObtenerResumenDeCortesPorDiaHandler : IInteractor<ObtenerResumenDeCortesPorDiaRequest, ObtenerResumenDeCortesPorDiaResponse>
{
    private readonly ILogger<ObtenerResumenDeCortesPorDiaHandler> _logger;
    private readonly POSInterfacesRepository.IReporteService _reporteService;

    public ObtenerResumenDeCortesPorDiaHandler(ILogger<ObtenerResumenDeCortesPorDiaHandler> logger, POSInterfacesRepository.IReporteService reporteService)
    {
        _logger = logger;
        _reporteService = reporteService;
    }

    public async Task<ObtenerResumenDeCortesPorDiaResponse> Handle(ObtenerResumenDeCortesPorDiaRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.FechaInicio == default || request.FechaFin == default)
        {
            return new FailureObtenerResumenDeCortesPorDiaResponse("Rango de fechas no válido.");
        }

        try
        {
            var cortes = await _reporteService.ObtenerResumenDeCortesPorDiaAsync(request.FechaInicio, request.FechaFin);

            if (!cortes.Any())
            {
                return new FailureObtenerResumenDeCortesPorDiaResponse("No se encontraron cortes en el rango especificado.");
            }

            var response = cortes.Select(c => new CortesDto(c.CorteID, c.FechaHora, c.TotalVendido, c.TotalVentas));
            return new SuccessObtenerResumenDeCortesPorDiaResponse(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el resumen de cortes por día.");
            return new FailureObtenerResumenDeCortesPorDiaResponse("Error interno al obtener el resumen de cortes por día.");
        }
    }
}