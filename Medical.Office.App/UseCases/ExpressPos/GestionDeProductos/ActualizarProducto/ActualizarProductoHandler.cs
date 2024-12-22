using Common.Common.CleanArch;
using Medical.Office.App.Dtos.EspressPos;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ActualizarProducto;

internal sealed class ActualizarProductoHandler : IInteractor<ActualizarProductoRequest, ActualizarProductoResponse>
{
    private readonly ILogger<ActualizarProductoHandler> _logger;
    private readonly POSInterfacesRepository.IProductoService _productoService;

    public ActualizarProductoHandler(ILogger<ActualizarProductoHandler> logger, POSInterfacesRepository.IProductoService productoService)
    {
        _logger = logger;
        _productoService = productoService;
    }

    public async Task<ActualizarProductoResponse> Handle(ActualizarProductoRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.ProductoID <= 0 || string.IsNullOrWhiteSpace(request.Nombre) || request.Precio <= 0 || request.Stock < 0)
        {
            return new FailureActualizarProductoResponse("Datos no válidos para actualizar el producto.");
        }

        try
        {
            await _productoService.ActualizarProductoAsync(request.ProductoID, request.Nombre, request.Precio, request.Stock);
            var producto = new ProductosDto(request.ProductoID, request.Nombre, request.Precio, request.Stock);
            return new SuccessActualizarProductoResponse(producto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar el producto.");
            return new FailureActualizarProductoResponse("Error interno al actualizar el producto.");
        }
    }
}