using Common.Common;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.UpdateActiveMedications.Response;

public record SuccessUpdateActiveMedicationsResponse(ActiveMedicationsDto ActiveMedications) : UpdateActiveMedicationsResponse, ISuccess;