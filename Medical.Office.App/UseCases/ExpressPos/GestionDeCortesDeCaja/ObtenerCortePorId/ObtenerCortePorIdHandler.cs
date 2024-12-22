using Common.Common.CleanArch;
using Medical.Office.App.Dtos.EspressPos;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerCortePorId;

internal sealed class ObtenerCortePorIdHandler : IInteractor<ObtenerCortePorIdRequest, ObtenerCortePorIdResponse>
{
    private readonly ILogger<ObtenerCortePorIdHandler> _logger;
    private readonly POSInterfacesRepository.ICorteService _corteService;

    public ObtenerCortePorIdHandler(ILogger<ObtenerCortePorIdHandler> logger, POSInterfacesRepository.ICorteService corteService)
    {
        _logger = logger;
        _corteService = corteService;
    }

    public async Task<ObtenerCortePorIdResponse> Handle(ObtenerCortePorIdRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.CorteID <= 0)
        {
            return new FailureObtenerCortePorIdResponse("ID de corte no válido.");
        }

        try
        {
            var corte = await _corteService.ObtenerCortePorIdAsync(request.CorteID);

            if (corte == null)
            {
                return new FailureObtenerCortePorIdResponse("Corte no encontrado.");
            }

            var response = new CortesDto(corte.CorteID, corte.FechaHora, corte.TotalVendido, corte.TotalVentas);
            return new SuccessObtenerCortePorIdResponse(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el corte por ID.");
            return new FailureObtenerCortePorIdResponse("Error interno al obtener el corte.");
        }
    }
}