using Common.Common.CleanArch;
using Common.Common;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications.Responses;
using MediatR;

namespace Medical.Office.Net8WebApi.EndPoints.Patients.AntecedentPatient
{
    // Clase base genérica para presenters
    public abstract class BasePresenter<T> : INotificationHandler<T>
        where T : INotification
    {
        public abstract Task Handle(T notification, CancellationToken cancellationToken);
    }


    // Presenter específico para InsertActiveMedicationsResponse
    public sealed class AntecedentPatientPresenter : BasePresenter<InsertActiveMedicationsResponse>
    {
        private readonly GenericViewModel<AntecedentPatientController> _viewModel;

        public AntecedentPatientPresenter(GenericViewModel<AntecedentPatientController> viewModel)
        {
            _viewModel = viewModel;
        }

        public override async Task Handle(InsertActiveMedicationsResponse notification, CancellationToken cancellationToken)
        {
            if (notification is IFailure failure)
            {
                _viewModel.Fail(failure.Message);
                await Task.CompletedTask;
            }
            else if (notification is ISuccess success)
            {
                _viewModel.OK(success);
                await Task.CompletedTask;
            }
        }
    }

    // Otro presenter específico para otro tipo de respuesta
    //public sealed class AnotherPresenter : BasePresenter<AnotherResponseType>
    //{
    //    private readonly GenericViewModel<AnotherController> _viewModel;

    //    public AnotherPresenter(GenericViewModel<AnotherController> viewModel)
    //    {
    //        _viewModel = viewModel;
    //    }

    //    public override async Task Handle(AnotherResponseType notification, CancellationToken cancellationToken)
    //    {
    //        if (notification is IFailure failure)
    //        {
    //            _viewModel.Fail(failure.Message);
    //            await Task.CompletedTask;
    //        }
    //        else if (notification is ISuccess success)
    //        {
    //            _viewModel.OK(success);
    //            await Task.CompletedTask;
    //        }
    //    }
    //}
}
