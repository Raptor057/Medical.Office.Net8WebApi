using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductosConBajoStock.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.ObtenerProductosConBajoStock;

public class ObtenerProductosConBajoStockPresenter<T> : IPresenter<ObtenerProductosConBajoStockResponse>
    where T : ObtenerProductosConBajoStockResponse
{
    private readonly GenericViewModel<ObtenerProductosConBajoStockController> _viewModel;

    public ObtenerProductosConBajoStockPresenter(GenericViewModel<ObtenerProductosConBajoStockController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(ObtenerProductosConBajoStockResponse notification, CancellationToken cancellationToken)
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