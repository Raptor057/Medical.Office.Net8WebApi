using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ActualizarStock.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.ActualizarStock;

public class ActualizarStockPresenter<T> : IPresenter<ActualizarStockResponse>
    where T : ActualizarStockResponse
{
    private readonly GenericViewModel<ActualizarStockController> _viewModel;

    public ActualizarStockPresenter(GenericViewModel<ActualizarStockController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(ActualizarStockResponse notification, CancellationToken cancellationToken)
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