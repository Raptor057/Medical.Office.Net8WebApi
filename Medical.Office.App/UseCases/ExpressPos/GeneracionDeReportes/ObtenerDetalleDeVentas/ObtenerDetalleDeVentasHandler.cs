using Common.Common.CleanArch;
using Medical.Office.App.Dtos.EspressPos.Viesw;
using Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerDetalleDeVentas.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerDetalleDeVentas;
/*
internal sealed class ObtenerDetalleDeVentasHandler : IInteractor<ObtenerDetalleDeVentasRequest, ObtenerDetalleDeVentasResponse>
{
    private readonly ILogger<ObtenerDetalleDeVentasHandler> _logger;
    private readonly POSInterfacesRepository.IReporteService _reporteService;

    public ObtenerDetalleDeVentasHandler(ILogger<ObtenerDetalleDeVentasHandler> logger, POSInterfacesRepository.IReporteService reporteService)
    {
        _logger = logger;
        _reporteService = reporteService;
    }

    public async Task<ObtenerDetalleDeVentasResponse> Handle(ObtenerDetalleDeVentasRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.VentaID <= 0)
        {
            return new FailureObtenerDetalleDeVentasResponse("ID de venta no válido.");
        }

        try
        {
            //var detalles = await _reporteService.ObtenerDetalleDeVentaAsync(request.VentaID);

            if (!detalles.Any())
            {
                return new FailureObtenerDetalleDeVentasResponse("No se encontraron detalles para la venta especificada.");
            }

            var response = detalles.Select(d => new DetalleDeVentasDto(d.VentaID, d.FechaHora, d.Producto, d.Cantidad, d.Subtotal));
            return new SuccessObtenerDetalleDeVentasResponse(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el detalle de la venta.");
            return new FailureObtenerDetalleDeVentasResponse("Error interno al obtener el detalle de la venta.");
        }
    }
}*/