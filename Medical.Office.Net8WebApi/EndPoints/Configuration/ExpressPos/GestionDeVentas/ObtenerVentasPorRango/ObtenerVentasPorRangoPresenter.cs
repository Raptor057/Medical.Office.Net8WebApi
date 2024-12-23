using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeVentas.ObtenerVentasPorRango.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeVentas.ObtenerVentasPorRango;

public class ObtenerVentasPorRangoPresenter<T> : IPresenter<ObtenerVentasPorRangoResponse>
    where T : ObtenerVentasPorRangoResponse
{
    private readonly GenericViewModel<ObtenerVentasPorRangoController> _viewModel;

    public ObtenerVentasPorRangoPresenter(GenericViewModel<ObtenerVentasPorRangoController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(ObtenerVentasPorRangoResponse notification, CancellationToken cancellationToken)
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