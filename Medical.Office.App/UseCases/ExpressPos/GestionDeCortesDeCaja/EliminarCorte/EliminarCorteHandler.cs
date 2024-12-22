using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.EliminarCorte.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.EliminarCorte;

internal sealed class EliminarCorteHandler : IInteractor<EliminarCorteRequest, EliminarCorteResponse>
{
    private readonly ILogger<EliminarCorteHandler> _logger;
    private readonly POSInterfacesRepository.ICorteService _corteService;

    public EliminarCorteHandler(ILogger<EliminarCorteHandler> logger, POSInterfacesRepository.ICorteService corteService)
    {
        _logger = logger;
        _corteService = corteService;
    }

    public async Task<EliminarCorteResponse> Handle(EliminarCorteRequest request, CancellationToken cancellationToken)
    {
        if (request == null || request.CorteID <= 0)
        {
            return new FailureEliminarCorteResponse("ID de corte no válido para eliminar.");
        }

        try
        {
            await _corteService.EliminarCorteAsync(request.CorteID);
            return new SuccessEliminarCorteResponse(request.CorteID);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al eliminar el corte.");
            return new FailureEliminarCorteResponse("Error interno al eliminar el corte.");
        }
    }
}