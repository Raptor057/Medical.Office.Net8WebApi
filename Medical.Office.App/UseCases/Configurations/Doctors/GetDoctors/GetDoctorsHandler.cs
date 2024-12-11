using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.Doctors.GetDoctors.Response;
using Medical.Office.Domain.Entities.MedicalOffice;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Configurations.Doctors.GetDoctors
{
    internal sealed class GetDoctorsHandler : IInteractor<GetDoctorsRequest,GetDoctorsResponse>
    {
        private readonly ILogger<GetDoctorsHandler> _logger;
        private readonly IConfigurationsRepository _configurations;

        public GetDoctorsHandler(ILogger<GetDoctorsHandler> logger, IConfigurationsRepository configurations)
        {
            _logger = logger;
            _configurations=configurations;
        }

        public async Task<GetDoctorsResponse> Handle(GetDoctorsRequest request, CancellationToken cancellationToken)
        {
            if (request == null) 
            {
                return new FailureGetDoctorsResponse("Datos no recibidos.");
            }

            if(request.IDDoctor > 1)
            {
               var Doctor = await _configurations.GetDoctorAsync(request.IDDoctor).ConfigureAwait(false);

                if (Doctor == null) 
                {
                    return new FailureGetDoctorsResponse($"Doctor con ID #{request.IDDoctor} no encontrado.");
                }

                var DoctorData = new DoctorsDto(0,Doctor.FirstName, Doctor.LastName, Doctor.Specialty, Doctor.PhoneNumber, Doctor.Email,DateTime.Now,DateTime.Now);

                return new SuccessGetDoctorsResponse(DoctorData);
            }

            if (request.IDDoctor == 0)
            {
                var Doctor = await _configurations.GetDoctorsAsync().ConfigureAwait(false);

                var DoctorList = Doctor.Select(D => new DoctorsDto(
                    D.ID,
                    D.FirstName,
                    D.LastName,
                    D.Specialty,
                    D.PhoneNumber,
                    D.Email,
                    D.CreatedAt,
                    D.UpdatedAt));
                    
                return new SuccessGetDoctorsListResponse(DoctorList);
            }
            return new FailureGetDoctorsResponse("Error al obtener datos.");
        }
    }
}
