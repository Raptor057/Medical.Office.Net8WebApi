using Common.Common.CleanArch;
using Medical.Office.App.Dtos.EspressPos;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerTodosLosProductos.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerTodosLosProductos;

internal sealed class ObtenerTodosLosProductosHandler : IInteractor<ObtenerTodosLosProductosRequest, ObtenerTodosLosProductosResponse>
{
    private readonly ILogger<ObtenerTodosLosProductosHandler> _logger;
    private readonly POSInterfacesRepository.IProductoService _productoService;

    public ObtenerTodosLosProductosHandler(ILogger<ObtenerTodosLosProductosHandler> logger, POSInterfacesRepository.IProductoService productoService)
    {
        _logger = logger;
        _productoService = productoService;
    }

    public async Task<ObtenerTodosLosProductosResponse> Handle(ObtenerTodosLosProductosRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var productos = await _productoService.ObtenerTodosLosProductosAsync();

            if (!productos.Any())
            {
                return new FailureObtenerTodosLosProductosResponse("No se encontraron productos.");
            }

            var response = productos.Select(p => new ProductosDto(p.ProductoID, p.Nombre, p.Precio, p.Stock));
            return new SuccessObtenerTodosLosProductosResponse(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener todos los productos.");
            return new FailureObtenerTodosLosProductosResponse("Error interno al obtener productos.");
        }
    }
}