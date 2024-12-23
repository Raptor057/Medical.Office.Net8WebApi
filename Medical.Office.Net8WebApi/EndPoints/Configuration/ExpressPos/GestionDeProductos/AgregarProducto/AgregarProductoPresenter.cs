using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.AgregarProducto.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.ActualizarProducto;

public class AgregarProductoPresenter<T> : IPresenter<AgregarProductoResponse>
    where T : AgregarProductoResponse
{
    private readonly GenericViewModel<AgregarProductoController> _viewModel;

    public AgregarProductoPresenter(GenericViewModel<AgregarProductoController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(AgregarProductoResponse notification, CancellationToken cancellationToken)
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