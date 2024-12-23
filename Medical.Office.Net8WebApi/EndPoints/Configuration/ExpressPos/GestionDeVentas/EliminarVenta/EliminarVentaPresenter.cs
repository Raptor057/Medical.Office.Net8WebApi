using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.EliminarVenta.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeVentas.EliminarVenta;

public class EliminarVentaPresenter<T> : IPresenter<EliminarVentaResponse>
    where T : EliminarVentaResponse
{
    private readonly GenericViewModel<EliminarVentaController> _viewModel;

    public EliminarVentaPresenter(GenericViewModel<EliminarVentaController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(EliminarVentaResponse notification, CancellationToken cancellationToken)
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