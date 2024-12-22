using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.EliminarVenta.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.EliminarVenta;

internal sealed class EliminarVentaHandler : IInteractor<EliminarVentaRequest, EliminarVentaResponse>
{
    private readonly ILogger<EliminarVentaHandler> _logger;
    private readonly POSInterfacesRepository.IVentaService _ventaService;

    public EliminarVentaHandler(ILogger<EliminarVentaHandler> logger, POSInterfacesRepository.IVentaService ventaService)
    {
        _logger = logger;
        _ventaService = ventaService;
    }

    public async Task<EliminarVentaResponse> Handle(EliminarVentaRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.VentaID <= 0)
        {
            return new FailureEliminarVentaResponse("Datos no válidos para eliminar la venta.");
        }

        try
        {
            await _ventaService.EliminarVentaAsync(request.VentaID);
            return new SuccessEliminarVentaResponse(request.VentaID);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al eliminar la venta.");
            return new FailureEliminarVentaResponse("Error interno al eliminar la venta.");
        }
    }
}