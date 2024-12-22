using Common.Common.CleanArch;
using Medical.Office.App.Dtos.EspressPos;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentasPorRango.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentasPorRango;

internal sealed class ObtenerVentasPorRangoHandler : IInteractor<ObtenerVentasPorRangoRequest, ObtenerVentasPorRangoResponse>
{
    private readonly ILogger<ObtenerVentasPorRangoHandler> _logger;
    private readonly POSInterfacesRepository.IVentaService _ventaService;

    public ObtenerVentasPorRangoHandler(ILogger<ObtenerVentasPorRangoHandler> logger, POSInterfacesRepository.IVentaService ventaService)
    {
        _logger = logger;
        _ventaService = ventaService;
    }

    public async Task<ObtenerVentasPorRangoResponse> Handle(ObtenerVentasPorRangoRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.FechaInicio == default || request.FechaFin == default)
        {
            return new FailureObtenerVentasPorRangoResponse("Rango de fechas no válido.");
        }

        try
        {
            var ventas = await _ventaService.ObtenerVentasPorRangoAsync(request.FechaInicio, request.FechaFin);

            if (!ventas.Any())
            {
                return new FailureObtenerVentasPorRangoResponse("No se encontraron ventas en el rango especificado.");
            }

            var response = ventas.Select(v => new VentasDto(v.VentaID, v.FechaHora, v.Total));
            return new SuccessObtenerVentasPorRangoResponse(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener ventas por rango.");
            return new FailureObtenerVentasPorRangoResponse("Error interno al obtener ventas.");
        }
    }
}