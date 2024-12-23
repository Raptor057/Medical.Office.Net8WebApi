using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.RegistrarCorte.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeCortesDeCaja.RegistrarCorte;

public class RegistrarCortePresenter<T> : IPresenter<RegistrarCorteResponse>
    where T : RegistrarCorteResponse
{
    private readonly GenericViewModel<RegistrarCorteController> _viewModel;

    public RegistrarCortePresenter(GenericViewModel<RegistrarCorteController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(RegistrarCorteResponse notification, CancellationToken cancellationToken)
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