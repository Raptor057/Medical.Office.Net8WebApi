using Common.Common;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.GetActiveMedications.Responses
{
    public record FailureGetActiveMedicationsResponse(string Message): GetActiveMedicationsResponse,IFailure;
}
