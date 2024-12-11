using Common.Common;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.Domain.Entities.MedicalOffice;

namespace Medical.Office.App.UseCases.Patients.FilesPatients.GetPatientFile.Responses;

public record SuccessGetPatientFileResponse(PatientsFilesDto PatientFile) : GetPatientFileResponse ,ISuccess;
public record SuccessGetPatientFilesListResponse(IEnumerable<PatientsFilesDto> PatientFile) : GetPatientFileResponse ,ISuccess;