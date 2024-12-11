using Common.Common;
using Medical.Office.App.Dtos.Configurations;

namespace Medical.Office.App.UseCases.Configurations.Doctors.UpdateDoctors.Response
{
    public record SuccessUpdateDoctorsResponse(DoctorsDto Doctor) : UpdateDoctorsResponse, ISuccess;

}
