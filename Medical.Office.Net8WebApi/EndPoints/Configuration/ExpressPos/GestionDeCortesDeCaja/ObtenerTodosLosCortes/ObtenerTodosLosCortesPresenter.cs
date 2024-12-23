using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.ObtenerTodosLosCortes.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeCortesDeCaja.ObtenerTodosLosCortes;

public class ObtenerTodosLosCortesPresenter<T> : IPresenter<ObtenerTodosLosCortesResponse>
    where T : ObtenerTodosLosCortesResponse
{
    private readonly GenericViewModel<ObtenerTodosLosCortesController> _viewModel;

    public ObtenerTodosLosCortesPresenter(GenericViewModel<ObtenerTodosLosCortesController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(ObtenerTodosLosCortesResponse notification, CancellationToken cancellationToken)
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