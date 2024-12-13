
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.Doctors.UpdateDoctors.Response;
using Medical.Office.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace Medical.Office.App.UseCases.Configurations.Doctors.UpdateDoctors
{
    internal class UpdateDoctorsHandler : IInteractor<UpdateDoctorsRequest,UpdateDoctorsResponse>
    {
        private readonly ILogger<UpdateDoctorsHandler> _logger;
        private readonly IConfigurationsRepository _repository;

        public UpdateDoctorsHandler(ILogger<UpdateDoctorsHandler> logger, IConfigurationsRepository repository)
        {
            _logger=logger;
            _repository=repository;
        }
        

        public async Task<UpdateDoctorsResponse> Handle(UpdateDoctorsRequest request, CancellationToken cancellationToken)
        {
            if (request == null) 
            {
                return new FailureUpdateDoctorsResponse("No se recibieron datos");
            }
            var DataDoctor = request.Doctor;
            await _repository.UpdateDoctorAsync(DataDoctor.FirstName, DataDoctor.LastName, DataDoctor.Specialty, DataDoctor.PhoneNumber, DataDoctor.Email);

            var Doctors = await _repository.GetDoctorsAsync();
            var LastDoctor = Doctors.OrderByDescending(D => D.UpdatedAt).FirstOrDefault();

            var LastUpdateDoctor = new DoctorsDto(LastDoctor.ID, LastDoctor.FirstName, LastDoctor.LastName, LastDoctor.Specialty, LastDoctor.PhoneNumber, LastDoctor.Email, LastDoctor.CreatedAt, LastDoctor.UpdatedAt);

            return new SuccessUpdateDoctorsResponse(LastUpdateDoctor);
        }
    }
}
