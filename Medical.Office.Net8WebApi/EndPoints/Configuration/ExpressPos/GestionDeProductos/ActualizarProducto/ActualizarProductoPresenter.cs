using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ActualizarProducto;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.ActualizarProducto;

public class ActualizarProductoPresenter<T> : IPresenter<ActualizarProductoResponse>
    where T : ActualizarProductoResponse
{
    private readonly GenericViewModel<ActualizarProductoController> _viewModel;

    public ActualizarProductoPresenter(GenericViewModel<ActualizarProductoController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(ActualizarProductoResponse notification, CancellationToken cancellationToken)
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