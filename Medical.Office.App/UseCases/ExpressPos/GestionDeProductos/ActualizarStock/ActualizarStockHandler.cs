using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ActualizarStock.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ActualizarStock;

internal sealed class ActualizarStockHandler : IInteractor<ActualizarStockRequest, ActualizarStockResponse>
{
    private readonly ILogger<ActualizarStockHandler> _logger;
    private readonly POSInterfacesRepository.IProductoService _productoService;

    public ActualizarStockHandler(ILogger<ActualizarStockHandler> logger, POSInterfacesRepository.IProductoService productoService)
    {
        _logger = logger;
        _productoService = productoService;
    }

    public async Task<ActualizarStockResponse> Handle(ActualizarStockRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.ProductoID <= 0 || request.NuevoStock < 0)
        {
            return new FailureActualizarStockResponse("Datos no válidos para actualizar el stock.");
        }

        try
        {
            await _productoService.ActualizarStockAsync(request.ProductoID, request.NuevoStock);
            return new SuccessActualizarStockResponse(request.ProductoID, request.NuevoStock);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar el stock del producto.");
            return new FailureActualizarStockResponse("Error interno al actualizar el stock.");
        }
    }
}