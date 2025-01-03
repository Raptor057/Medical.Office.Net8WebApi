using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Users.UpdateUsers.Response;

namespace Medical.Office.Net8WebApi.EndPoints.Users.UpdateUsers;

public class UpdateUsersPresenter<T> : IPresenter<UpdateUsersResponse>
where T : UpdateUsersResponse
{
    private readonly GenericViewModel<UpdateUsersController> _viewModel;
    public UpdateUsersPresenter(GenericViewModel<UpdateUsersController> viewModel)
    {
        _viewModel=viewModel;
    }
    
    public async Task Handle(UpdateUsersResponse notification, CancellationToken cancellationToken)
    {
        if (notification is IFailure failure)
        {
            _viewModel.Fail(failure.Message);
            await Task.CompletedTask;
        }
        else if (notification is ISuccess successRegisterUsersResponse)
        {
            _viewModel.OK(successRegisterUsersResponse);
            await Task.CompletedTask;
        }
    }
}