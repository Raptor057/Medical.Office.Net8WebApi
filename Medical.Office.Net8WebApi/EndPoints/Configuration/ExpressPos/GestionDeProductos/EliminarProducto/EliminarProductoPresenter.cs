using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.EliminarProducto.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.EliminarProducto;

public class EliminarProductoPresenter<T> : IPresenter<EliminarProductoResponse>
    where T : EliminarProductoResponse
{
    private readonly GenericViewModel<EliminarProductoController> _viewModel;

    public EliminarProductoPresenter(GenericViewModel<EliminarProductoController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(EliminarProductoResponse notification, CancellationToken cancellationToken)
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