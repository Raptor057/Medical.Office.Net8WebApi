using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.UpdateActiveMedications.Response;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.ActiveMedications.UpdateActiveMedications;

public record UpdateActiveMedicationsRequest(ActiveMedicationsDto ActiveMedications) : IRequest<UpdateActiveMedicationsResponse>;