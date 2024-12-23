using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerCortesPorRango.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeCortesDeCaja.ObtenerCortesPorRango;

public class ObtenerCortesPorRangoPresenter<T> : IPresenter<ObtenerCortesPorRangoResponse>
    where T : ObtenerCortesPorRangoResponse
{
    private readonly GenericViewModel<ObtenerCortesPorRangoController> _viewModel;

    public ObtenerCortesPorRangoPresenter(GenericViewModel<ObtenerCortesPorRangoController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(ObtenerCortesPorRangoResponse notification, CancellationToken cancellationToken)
    {
        if (notification is IFailure failure)
        {
            _viewModel.Fail(failure.Message);
            await Task.CompletedTask;
        }
        else if (notification is ISuccess response)
        {
            _viewModel.OK(response);
            await Task.CompletedTask;
        }
    }
}