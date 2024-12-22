using Common.Common.CleanArch;
using Medical.Office.App.Dtos.EspressPos;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.AgregarProducto.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.AgregarProducto;

internal sealed class AgregarProductoHandler : IInteractor<AgregarProductoRequest, AgregarProductoResponse>
{
    private readonly ILogger<AgregarProductoHandler> _logger;
    private readonly POSInterfacesRepository.IProductoService _productoService;

    public AgregarProductoHandler(ILogger<AgregarProductoHandler> logger, POSInterfacesRepository.IProductoService productoService)
    {
        _logger = logger;
        _productoService = productoService;
    }

    public async Task<AgregarProductoResponse> Handle(AgregarProductoRequest request, CancellationToken cancellationToken)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.Nombre) || request.Precio <= 0 || request.Stock < 0)
        {
            return new FailureAgregarProductoResponse("Datos no válidos para agregar el producto.");
        }

        try
        {
            await _productoService.AgregarProductoAsync(request.Nombre, request.Precio, request.Stock);
            var producto = new ProductosDto(0, request.Nombre, request.Precio, request.Stock);
            return new SuccessAgregarProductoResponse(producto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar el producto.");
            return new FailureAgregarProductoResponse("Error interno al agregar el producto.");
        }
    }
}