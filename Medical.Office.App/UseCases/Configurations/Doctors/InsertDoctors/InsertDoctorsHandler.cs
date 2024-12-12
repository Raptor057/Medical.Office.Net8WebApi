using Common.Common.CleanArch;
using Microsoft.Extensions.Logging;
using Medical.Office.Domain.Repository;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.Doctors.InsertDoctors.Response;

namespace Medical.Office.App.UseCases.Configurations.Doctors.InsertDoctors
{
    internal sealed class InsertDoctorsHandler : IInteractor<InsertDoctorsRequest, InsertDoctorsResponse>
    {
        private readonly ILogger<InsertDoctorsHandler> _logger;
        private readonly IConfigurationsRepository _repository;

        public InsertDoctorsHandler(ILogger<InsertDoctorsHandler> logger, IConfigurationsRepository repository)
        {
            _logger=logger;
            _repository=repository;
        }

        public async Task<InsertDoctorsResponse> Handle(InsertDoctorsRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new FailureInsertDoctorsResponse("No se recibieron datos");    
            }

            var DoctorData = request.Doctor;

            await _repository.InsertDoctorAsync(DoctorData.FirstName, DoctorData.LastName, DoctorData.Specialty, DoctorData.PhoneNumber, DoctorData.Email).ConfigureAwait(false);

            var Response = new DoctorsDto(0, DoctorData.FirstName, DoctorData.LastName, DoctorData.Specialty, DoctorData.PhoneNumber, DoctorData.Email,DateTime.Now,DateTime.Now);

            return new SuccessInsertDoctorsResponse(Response);
        }
    }
}
