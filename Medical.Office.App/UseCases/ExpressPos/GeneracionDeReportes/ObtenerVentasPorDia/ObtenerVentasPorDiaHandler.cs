using Common.Common.CleanArch;
using Medical.Office.App.Dtos.EspressPos.Viesw;
using Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerVentasPorDia.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerVentasPorDia;

internal sealed class ObtenerVentasPorDiaHandler : IInteractor<ObtenerVentasPorDiaRequest, ObtenerVentasPorDiaResponse>
{
    private readonly ILogger<ObtenerVentasPorDiaHandler> _logger;
    private readonly POSInterfacesRepository.IReporteService _reporteService;

    public ObtenerVentasPorDiaHandler(ILogger<ObtenerVentasPorDiaHandler> logger, POSInterfacesRepository.IReporteService reporteService)
    {
        _logger = logger;
        _reporteService = reporteService;
    }

    public async Task<ObtenerVentasPorDiaResponse> Handle(ObtenerVentasPorDiaRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.FechaInicio == default || request.FechaFin == default)
        {
            return new FailureObtenerVentasPorDiaResponse("Rango de fechas no válido.");
        }

        try
        {
            var ventas = await _reporteService.ObtenerVentasPorDiaAsync(request.FechaInicio, request.FechaFin);

            if (!ventas.Any())
            {
                return new FailureObtenerVentasPorDiaResponse("No se encontraron ventas en el rango especificado.");
            }

            var response = ventas.Select(v => new VentasPorDiaDto(v.Fecha, v.TotalVentas, v.TotalVendido));
            return new SuccessObtenerVentasPorDiaResponse(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener ventas por día.");
            return new FailureObtenerVentasPorDiaResponse("Error interno al obtener ventas por día.");
        }
    }
}