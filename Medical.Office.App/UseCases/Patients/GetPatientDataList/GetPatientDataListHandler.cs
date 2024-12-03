using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.GetPatientDataList.Responses;
using Medical.Office.Domain.Repository;


namespace Medical.Office.App.UseCases.Patients.GetPatientDataList
{
    internal sealed class GetPatientDataListHandler : IInteractor<GetPatientDataListRequest, GetPatientDataListResponse>
    {
        private readonly IPatientsData _patients;

        public GetPatientDataListHandler(IPatientsData patients)
        {
            _patients=patients;
        }

        public async Task<GetPatientDataListResponse> Handle(GetPatientDataListRequest request, CancellationToken cancellationToken)
        {

            if (request == null)
            {
                return new FailureGetPatientDataListResponse("La variable [IDPatient] es null");
            }
            else if(request.IDPatient == 0)
            {
                var PatientData = await _patients.GetPatientsDataListAsync().ConfigureAwait(false);
                if (PatientData == null)
                {
                    return new FailureGetPatientDataListResponse($"No se encontraron pacientes");
                }
                var patientDataListDto = PatientData.Select(p =>
                    new GetShortPatientsDto(
                        p.ID,
                        p.Name,
                        p.FathersSurname,
                        p.MothersSurname,
                        p.DateOfBirth,
                        p.PhoneNumber,
                        p.Email,
                        p.Photo
                    )).ToList();
                return new SuccessGetShortPatientDataListResponse(new GetShortPatientsDtoList(patientDataListDto));

            }
            else if(request.IDPatient > 0)
            {
                var PatientData = await _patients.GetPatientDataByIDPatientAsync(request.IDPatient).ConfigureAwait(false);
                if (PatientData == null)
                {
                    return new FailureGetPatientDataListResponse($"No se encontro el paciente con ID {request.IDPatient}");
                }
                var patientDataDto = new GetPatientsDto(
                                    PatientData.ID,
                                    PatientData.Name,
                                    PatientData.FathersSurname,
                                    PatientData.MothersSurname,
                                    PatientData.DateOfBirth,
                                    PatientData.Gender,
                                    PatientData.Address,
                                    PatientData.Country,
                                    PatientData.City,
                                    PatientData.State,
                                    PatientData.ZipCode,
                                    PatientData.OutsideNumber,
                                    PatientData.InsideNumber,
                                    PatientData.PhoneNumber,
                                    PatientData.Email,
                                    PatientData.EmergencyContactName,
                                    PatientData.EmergencyContactPhone,
                                    PatientData.InsuranceProvider,
                                    PatientData.PolicyNumber,
                                    PatientData.BloodType,
                                    PatientData.DateCreated,
                                    PatientData.LastUpdated,
                                    PatientData.Photo,
                                    PatientData.InternalNotes);
                return new SuccessGetPatientDataResponse(patientDataDto);
            }
            else
            {
                return new FailureGetPatientDataListResponse("Ocurrio un error inesperado.");
            }
        }
    }
}
