using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications.Responses
{
    public record FailureInsertActiveMedicationsResponse(string Message) : InsertActiveMedicationsResponse,IFailure;
}
