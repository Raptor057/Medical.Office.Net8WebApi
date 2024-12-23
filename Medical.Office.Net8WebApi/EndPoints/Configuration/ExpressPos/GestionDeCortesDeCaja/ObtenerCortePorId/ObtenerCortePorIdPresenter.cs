using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerCortePorId;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeCortesDeCaja.ObtenerCortePorId;

public class ObtenerCortePorIdPresenter<T> : IPresenter<ObtenerCortePorIdResponse>
    where T : ObtenerCortePorIdResponse
{
    private readonly GenericViewModel<ObtenerCortePorIdController> _viewModel;

    public ObtenerCortePorIdPresenter(GenericViewModel<ObtenerCortePorIdController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(ObtenerCortePorIdResponse notification, CancellationToken cancellationToken)
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