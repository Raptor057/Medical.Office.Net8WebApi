// RegistrarVentaHandler.cs
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.EspressPos;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.RegistrarVenta.Response;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.RegistrarVenta.Response.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.GestionDeVentas.RegistrarVenta
{
    internal sealed class RegistrarVentaHandler : IInteractor<RegistrarVentaRequest, RegistrarVentaResponse>
    {
        private readonly ILogger<RegistrarVentaHandler> _logger;
        private readonly POSInterfacesRepository.IVentaService _ventaService;

        public RegistrarVentaHandler(ILogger<RegistrarVentaHandler> logger,
            POSInterfacesRepository.IVentaService ventaService)
        {
            _logger = logger;
            _ventaService = ventaService;
        }

        public async Task<RegistrarVentaResponse> Handle(RegistrarVentaRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.Productos == null || !request.Productos.Any())
            {
                return new FailureRegistrarVentaResponse("Datos no válidos para registrar la venta.");
            }

            try
            {
                // Registrar la venta
                var TotalVentaAndId = await _ventaService.RegistrarVentaAsync(request.FechaHora, request.Productos);

                // Crear el DTO de respuesta
                var response = new VentasDto(TotalVentaAndId.VentaID, request.FechaHora, TotalVentaAndId.TotalVenta);
                return new SuccessRegistrarVentaResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar la venta.");
                return new FailureRegistrarVentaResponse("Error interno al registrar la venta.");
            }
        }

    }
}