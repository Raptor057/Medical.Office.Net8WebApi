using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Users.RegisterUsers.Responses;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Medical.Office.Net8WebApi.EndPoints.Users.RegisterUsers
{
    public sealed class RegisterUsersPresenter<T> : IPresenter<RegisterUsersSuccessResponse>, IPresenter<RegisterUsersFailureResponse>
        where T : RegisterUsersSuccessResponse //RegisterUsersResponse
    {
        private readonly GenericViewModel<RegisterUsersController> _viewModel;

        public RegisterUsersPresenter(GenericViewModel<RegisterUsersController> viewModel)
        {
            _viewModel=viewModel;
        }

        public  Task Handle(RegisterUsersSuccessResponse notification, CancellationToken cancellationToken)
        {
            _viewModel.OK(notification.registerUsersDto);
            return Task.CompletedTask;
        }

        public Task Handle(RegisterUsersFailureResponse notification, CancellationToken cancellationToken)
        {
            _viewModel.Fail(notification.Message);
            return Task.CompletedTask;
        }
    }
}
