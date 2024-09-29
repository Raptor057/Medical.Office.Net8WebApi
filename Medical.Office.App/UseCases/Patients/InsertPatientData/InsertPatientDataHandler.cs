using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Patients;
using Medical.Office.App.UseCases.Patients.InsertPatientData.Responses;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Patients.InsertPatientData
{
    internal sealed class InsertPatientDataHandler: IInteractor<InsertPatientDataRequest,InsertPatientDataResponse>
    {
        private readonly IPatientsData _patients;

        public InsertPatientDataHandler(IPatientsData patients) 
        {
            _patients=patients;
        }

        public async Task<InsertPatientDataResponse> Handle(InsertPatientDataRequest request, CancellationToken cancellationToken)
        {
            var Patient = new InsertPatientsDto
            (
            request.Name,
            request.FathersSurname,
            request.MothersSurname,
            request.DateOfBirth,
            request.Gender,
            request.Address,
            request.Country,
            request.City,
            request.State,
            request.ZipCode,
            request.OutsideNumber,
            request.InsideNumber,
            request.PhoneNumber,
            request.Email,
            request.EmergencyContactName,
            request.EmergencyContactPhone,
            request.InsuranceProvider,
            request.PolicyNumber,
            request.BloodType,
            request.Photo,
            request.InternalNotes);

            await _patients.InsertPatientDataAsync(Patient.Name,Patient.FathersSurname,Patient.MothersSurname,Patient.DateOfBirth,Patient.Gender,Patient.Address,Patient.Country,Patient.City,Patient.State,Patient.ZipCode,Patient.OutsideNumber,Patient.InsideNumber,Patient.PhoneNumber,Patient.Email,Patient.EmergencyContactName,Patient.EmergencyContactPhone,Patient.InsuranceProvider,Patient.PolicyNumber,Patient.BloodType,Patient.Photo,Patient.InternalNotes).ConfigureAwait(false);

            return new SuccessInsertPatientDataResponse(Patient);
        }
    }
}
