using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Users.RegisterUsers.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Users.RegisterUsers
{
    public sealed class RegisterUsersPresenter<T> : IPresenter<RegisterUsersResponse>
        where T : RegisterUsersResponse
    {
        private readonly GenericViewModel<RegisterUsersController> _viewModel;

        public RegisterUsersPresenter(GenericViewModel<RegisterUsersController> viewModel)
        {
            _viewModel=viewModel;
        }

        public async Task Handle(RegisterUsersResponse notification, CancellationToken cancellationToken)
        {
            if (notification is IFailure failure) 
            {
                _viewModel.Fail(failure.Message);
            }
            else if(notification is SuccessRegisterUsersResponse successRegisterUsersResponse)
            {
                _viewModel.OK(successRegisterUsersResponse);
            }
        }
    }
}
