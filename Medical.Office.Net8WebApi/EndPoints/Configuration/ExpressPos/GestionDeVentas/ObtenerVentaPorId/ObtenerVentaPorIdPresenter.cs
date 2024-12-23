using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentaPorId.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeVentas.ObtenerVentaPorId;

public class ObtenerVentaPorIdPresenter<T> : IPresenter<ObtenerVentaPorIdResponse>
    where T : ObtenerVentaPorIdResponse
{
    private readonly GenericViewModel<ObtenerVentaPorIdController> _viewModel;

    public ObtenerVentaPorIdPresenter(GenericViewModel<ObtenerVentaPorIdController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(ObtenerVentaPorIdResponse notification, CancellationToken cancellationToken)
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