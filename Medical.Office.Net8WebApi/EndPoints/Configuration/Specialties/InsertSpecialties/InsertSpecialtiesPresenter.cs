using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Configurations.Specialties.InsertSpecialties.Responses;

namespace Medical.Office.Net8WebApi.EndPoints.Configuration.Specialties.InsertSpecialties
{
    public sealed class InsertSpecialtiesPresenter<T> : IPresenter<InsertSpecialtiesResponse> 
        where T : InsertSpecialtiesResponse
    {
        private readonly GenericViewModel<InsertSpecialtiesController> _viewModel;

        public InsertSpecialtiesPresenter(GenericViewModel<InsertSpecialtiesController> viewModel)
        {
            _viewModel=viewModel;
        }
        public async Task Handle(InsertSpecialtiesResponse notification, CancellationToken cancellationToken)
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
