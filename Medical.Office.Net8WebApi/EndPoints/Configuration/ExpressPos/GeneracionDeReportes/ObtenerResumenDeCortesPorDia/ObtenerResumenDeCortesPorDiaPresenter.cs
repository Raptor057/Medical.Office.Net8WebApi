using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerResumenDeCortesPorDia.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GeneracionDeReportes.ObtenerResumenDeCortesPorDia;

public class ObtenerResumenDeCortesPorDiaPresenter<T> : IPresenter<ObtenerResumenDeCortesPorDiaResponse>
    where T : ObtenerResumenDeCortesPorDiaResponse
{
    private readonly GenericViewModel<ObtenerResumenDeCortesPorDiaController> _viewModel;

    public ObtenerResumenDeCortesPorDiaPresenter(GenericViewModel<ObtenerResumenDeCortesPorDiaController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(ObtenerResumenDeCortesPorDiaResponse notification, CancellationToken cancellationToken)
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