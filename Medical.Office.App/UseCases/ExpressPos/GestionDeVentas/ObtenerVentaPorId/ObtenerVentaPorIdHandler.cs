using Common.Common.CleanArch;
using Medical.Office.App.Dtos.EspressPos;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentaPorId.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentaPorId;

internal sealed class ObtenerVentaPorIdHandler : IInteractor<ObtenerVentaPorIdRequest, ObtenerVentaPorIdResponse>
{
    private readonly ILogger<ObtenerVentaPorIdHandler> _logger;
    private readonly POSInterfacesRepository.IVentaService _ventaService;

    public ObtenerVentaPorIdHandler(ILogger<ObtenerVentaPorIdHandler> logger, POSInterfacesRepository.IVentaService ventaService)
    {
        _logger = logger;
        _ventaService = ventaService;
    }

    public async Task<ObtenerVentaPorIdResponse> Handle(ObtenerVentaPorIdRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.VentaID <= 0)
        {
            return new FailureObtenerVentaPorIdResponse("ID de venta no válido.");
        }

        try
        {
            var venta = await _ventaService.ObtenerVentaPorIdAsync(request.VentaID);

            if (venta == null)
            {
                return new FailureObtenerVentaPorIdResponse("Venta no encontrada.");
            }

            var response = new VentasDto(venta.VentaID, venta.FechaHora, venta.Total);
            return new SuccessObtenerVentaPorIdResponse(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener la venta por ID.");
            return new FailureObtenerVentaPorIdResponse("Error interno al obtener la venta.");
        }
    }
}