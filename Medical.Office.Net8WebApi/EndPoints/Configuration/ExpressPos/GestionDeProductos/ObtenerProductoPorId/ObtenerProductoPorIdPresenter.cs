using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeProductos.ObtenerProductoPorId.Request;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeProductos.ObtenerProductoPorId;

public class ObtenerProductoPorIdPresenter<T> : IPresenter<ObtenerProductoPorIdResponse>
    where T : ObtenerProductoPorIdResponse
{
    private readonly GenericViewModel<ObtenerProductoPorIdController> _viewModel;

    public ObtenerProductoPorIdPresenter(GenericViewModel<ObtenerProductoPorIdController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(ObtenerProductoPorIdResponse notification, CancellationToken cancellationToken)
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