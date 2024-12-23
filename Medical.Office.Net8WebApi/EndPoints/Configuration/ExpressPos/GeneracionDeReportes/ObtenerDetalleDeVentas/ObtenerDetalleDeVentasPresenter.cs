using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerDetalleDeVentas.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GeneracionDeReportes.ObtenerDetalleDeVentas;

public class ObtenerDetalleDeVentasPresenter<T> : IPresenter<ObtenerDetalleDeVentasResponse>
    where T : ObtenerDetalleDeVentasResponse
{
    private readonly GenericViewModel<ObtenerDetalleDeVentasController> _viewModel;

    public ObtenerDetalleDeVentasPresenter(GenericViewModel<ObtenerDetalleDeVentasController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(ObtenerDetalleDeVentasResponse notification, CancellationToken cancellationToken)
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