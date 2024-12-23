using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GeneracionDeReportes.ObtenerVentasPorDia.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GeneracionDeReportes.ObtenerDetalleDeVentas;

public class ObtenerVentasPorDiaPresenter<T> : IPresenter<ObtenerVentasPorDiaResponse>
    where T : ObtenerVentasPorDiaResponse
{
    private readonly GenericViewModel<ObtenerVentasPorDiaController> _viewModel;

    public ObtenerVentasPorDiaPresenter(GenericViewModel<ObtenerVentasPorDiaController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(ObtenerVentasPorDiaResponse notification, CancellationToken cancellationToken)
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