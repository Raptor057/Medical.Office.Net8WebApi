using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.UpdateActiveMedications.Response;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.FamilyHistory.UpdateActiveMedications;

public record class UpdateActiveMedicationsRequest(ActiveMedicationsDto ActiveMedications): IRequest<UpdateActiveMedicationsResponse>;