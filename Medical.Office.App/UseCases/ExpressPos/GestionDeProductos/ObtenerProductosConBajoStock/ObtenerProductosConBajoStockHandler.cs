using Common.Common.CleanArch;
using Medical.Office.App.Dtos.EspressPos;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductosConBajoStock.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductosConBajoStock;

internal sealed class ObtenerProductosConBajoStockHandler : IInteractor<ObtenerProductosConBajoStockRequest, ObtenerProductosConBajoStockResponse>
{
    private readonly ILogger<ObtenerProductosConBajoStockHandler> _logger;
    private readonly POSInterfacesRepository.IProductoService _productoService;

    public ObtenerProductosConBajoStockHandler(ILogger<ObtenerProductosConBajoStockHandler> logger, POSInterfacesRepository.IProductoService productoService)
    {
        _logger = logger;
        _productoService = productoService;
    }

    public async Task<ObtenerProductosConBajoStockResponse> Handle(ObtenerProductosConBajoStockRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.LimiteStock <= 0)
        {
            return new FailureObtenerProductosConBajoStockResponse("Límite de stock no válido.");
        }

        try
        {
            var productos = await _productoService.ObtenerProductosConBajoStockAsync(request.LimiteStock);

            if (!productos.Any())
            {
                return new FailureObtenerProductosConBajoStockResponse("No se encontraron productos con bajo stock.");
            }

            var response = productos.Select(p => new ProductosDto(p.ProductoID, p.Nombre, p.Precio, p.Stock));
            return new SuccessObtenerProductosConBajoStockResponse(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener productos con bajo stock.");
            return new FailureObtenerProductosConBajoStockResponse("Error interno al obtener productos con bajo stock.");
        }
    }
}