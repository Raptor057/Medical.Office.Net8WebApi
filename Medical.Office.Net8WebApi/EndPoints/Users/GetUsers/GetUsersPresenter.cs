using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Users.GetUsers.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Users.GetUsers
{
    public sealed class GetUsersPresenter<T> : IPresenter<GetUsersResponse>
        where T : GetUsersResponse
    {
        private readonly GenericViewModel<GetUsersController> _viewModel;

        public GetUsersPresenter(GenericViewModel<GetUsersController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(GetUsersResponse notification, CancellationToken cancellationToken)
        {
            if (notification is IFailure failure)
            {
                _viewModel.Fail(failure.Message);
                await Task.CompletedTask;
            }
            else if (notification is SuccesGetUsersByIDResponse success)
            {
                _viewModel.OK(success);
                await Task.CompletedTask;
            }
            else if (notification is SuccessGetUsersListResponse successlist)
            {
                _viewModel.OK(successlist);
                await Task.CompletedTask;
            }
        }
    }
}
