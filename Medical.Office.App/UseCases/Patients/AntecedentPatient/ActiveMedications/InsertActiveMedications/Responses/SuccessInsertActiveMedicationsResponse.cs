using Common.Common;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.InsertActiveMedications.Responses
{
    public record SuccessInsertActiveMedicationsResponse(ActiveMedicationsDto ActiveMedicationsDto) : InsertActiveMedicationsResponse , ISuccess;
}
