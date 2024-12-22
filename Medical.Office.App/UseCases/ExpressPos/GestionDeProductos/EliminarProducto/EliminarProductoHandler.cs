using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.EliminarProducto.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.EliminarProducto;

internal sealed class EliminarProductoHandler : IInteractor<EliminarProductoRequest, EliminarProductoResponse>
{
    private readonly ILogger<EliminarProductoHandler> _logger;
    private readonly POSInterfacesRepository.IProductoService _productoService;

    public EliminarProductoHandler(ILogger<EliminarProductoHandler> logger, POSInterfacesRepository.IProductoService productoService)
    {
        _logger = logger;
        _productoService = productoService;
    }

    public async Task<EliminarProductoResponse> Handle(EliminarProductoRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.ProductoID <= 0)
        {
            return new FailureEliminarProductoResponse("ID de producto no válido para eliminar.");
        }

        try
        {
            await _productoService.EliminarProductoAsync(request.ProductoID);
            return new SuccessEliminarProductoResponse(request.ProductoID);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al eliminar el producto.");
            return new FailureEliminarProductoResponse("Error interno al eliminar el producto.");
        }
    }
}