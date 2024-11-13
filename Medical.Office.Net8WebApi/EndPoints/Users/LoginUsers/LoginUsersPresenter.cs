using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Users.LoginUsers.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Users.UsersLogin
{
    public sealed class LoginUsersPresenter<T> : IPresenter<LoginUsersResponse>
        where T : LoginUsersResponse
    {
        private readonly GenericViewModel<LoginUsersController> _viewModel;

        public LoginUsersPresenter(GenericViewModel<LoginUsersController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(LoginUsersResponse notification, CancellationToken cancellationToken)
        {
            if(notification is IFailure failure)
            {
                _viewModel.Fail(failure.Message);
                await Task.CompletedTask;
            }
            else if (notification is SuccessLoginUsersResponse success)
            {
                _viewModel.OK(success);
                await Task.CompletedTask;
            }
        }
    }
}
