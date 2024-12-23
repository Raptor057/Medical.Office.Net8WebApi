using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerTodosLosProductos.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.ObtenerTodosLosProductos;

public class ObtenerTodosLosProductosPresenter<T> : IPresenter<ObtenerTodosLosProductosResponse>
    where T : ObtenerTodosLosProductosResponse
{
    private readonly GenericViewModel<ObtenerTodosLosProductosController> _viewModel;

    public ObtenerTodosLosProductosPresenter(GenericViewModel<ObtenerTodosLosProductosController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(ObtenerTodosLosProductosResponse notification, CancellationToken cancellationToken)
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