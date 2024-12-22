using Common.Common.CleanArch;
using Medical.Office.App.Dtos.EspressPos;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductoPorId.Request;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductoPorId;

internal sealed class ObtenerProductoPorIdHandler : IInteractor<ObtenerProductoPorIdRequest, ObtenerProductoPorIdResponse>
{
    private readonly ILogger<ObtenerProductoPorIdHandler> _logger;
    private readonly POSInterfacesRepository.IProductoService _productoService;

    public ObtenerProductoPorIdHandler(ILogger<ObtenerProductoPorIdHandler> logger, POSInterfacesRepository.IProductoService productoService)
    {
        _logger = logger;
        _productoService = productoService;
    }

    public async Task<ObtenerProductoPorIdResponse> Handle(ObtenerProductoPorIdRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.ProductoID <= 0)
        {
            return new FailureObtenerProductoPorIdResponse("ID de producto no válido.");
        }

        try
        {
            var producto = await _productoService.ObtenerProductoPorIdAsync(request.ProductoID);

            if (producto == null)
            {
                return new FailureObtenerProductoPorIdResponse("Producto no encontrado.");
            }

            var response = new ProductosDto(producto.ProductoID, producto.Nombre, producto.Precio, producto.Stock);
            return new SuccessObtenerProductoPorIdResponse(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el producto por ID.");
            return new FailureObtenerProductoPorIdResponse("Error interno al obtener el producto.");
        }
    }
}