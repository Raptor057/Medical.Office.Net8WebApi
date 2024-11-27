using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Configurations.Positions.InsertPositions.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.Positions.InsertPositions
{
    public sealed class InsertPositionsPresenter<T> : IPresenter<InsertPositionsResponse> 
        where T : InsertPositionsResponse
    {
        private readonly GenericViewModel<InsertPositionsController> _viewModel;

        public InsertPositionsPresenter(GenericViewModel<InsertPositionsController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(InsertPositionsResponse notification, CancellationToken cancellationToken)
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
}
