using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PatientAllergies;
using Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.UpdatePatientAllergies.Response;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.UpdatePatientAllergies;

public record class UpdatePatientAllergiesRequest(PatientAllergiesDto PatientAllergies) : IRequest<UpdatePatientAllergiesResponse>;