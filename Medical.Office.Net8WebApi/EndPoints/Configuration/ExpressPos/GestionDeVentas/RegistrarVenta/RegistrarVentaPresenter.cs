using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.RegistrarVenta.Response.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeVentas.RegistrarVenta;

public class RegistrarVentaPresenter<T> : IPresenter<RegistrarVentaResponse>
    where T : RegistrarVentaResponse
{
    private readonly GenericViewModel<RegistrarVentaController> _viewModel;

    public RegistrarVentaPresenter(GenericViewModel<RegistrarVentaController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(RegistrarVentaResponse notification, CancellationToken cancellationToken)
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