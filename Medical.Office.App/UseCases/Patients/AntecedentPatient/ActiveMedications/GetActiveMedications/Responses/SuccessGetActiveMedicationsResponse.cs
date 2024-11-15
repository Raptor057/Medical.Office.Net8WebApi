using Common.Common;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.GetActiveMedications.Responses
{
    public record SuccessGetActiveMedicationsResponse(ActiveMedicationsDto ActiveMedicationsDto) : GetActiveMedicationsResponse, ISuccess;
}
