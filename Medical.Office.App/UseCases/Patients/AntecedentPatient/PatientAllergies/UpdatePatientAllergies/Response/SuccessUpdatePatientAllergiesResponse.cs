using Common.Common;
using Medical.Office.App.Dtos.Patients.AntecedentPatient.PatientAllergies;

namespace Medical.Office.App.UseCases.Patients.AntecedentPatient.PatientAllergies.UpdatePatientAllergies.Response;

public record SuccessUpdatePatientAllergiesResponse(PatientAllergiesDto PatientAllergies) : UpdatePatientAllergiesResponse, ISuccess;