using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Configurations.Doctors.GetDoctors.Response;

namespace Medical.Office.App.UseCases.Configurations.Doctors.GetDoctors
{
    public record GetDoctorsRequest(long IDDoctor) : IRequest<GetDoctorsResponse>;
}
