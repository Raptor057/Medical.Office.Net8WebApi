using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.ExpressPos.GestionDeCortesDeCaja.EliminarCorte.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.ExpressPos.GestionDeCortesDeCaja.EliminarCorte;

public class EliminarCortePresenter<T> : IPresenter<EliminarCorteResponse>
    where T : EliminarCorteResponse
{
    private readonly GenericViewModel<EliminarCorteController> _viewModel;

    public EliminarCortePresenter(GenericViewModel<EliminarCorteController> viewModel)
    {
        _viewModel = viewModel;
    }

    public async Task Handle(EliminarCorteResponse notification, CancellationToken cancellationToken)
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