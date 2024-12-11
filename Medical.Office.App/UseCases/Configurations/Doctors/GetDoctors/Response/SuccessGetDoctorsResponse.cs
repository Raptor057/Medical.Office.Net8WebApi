using Common.Common;
using Medical.Office.App.Dtos.Configurations;

namespace Medical.Office.App.UseCases.Configurations.Doctors.GetDoctors.Response
{
    public record SuccessGetDoctorsResponse(DoctorsDto Doctor) : GetDoctorsResponse,ISuccess;
    public record SuccessGetDoctorsListResponse(IEnumerable<DoctorsDto> Doctors) : GetDoctorsResponse, ISuccess;

}
