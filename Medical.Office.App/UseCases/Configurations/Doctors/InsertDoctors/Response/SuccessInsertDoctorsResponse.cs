using Common.Common;
using Medical.Office.App.Dtos.Configurations;

namespace Medical.Office.App.UseCases.Configurations.Doctors.InsertDoctors.Response
{
    public record SuccessInsertDoctorsResponse(DoctorsDto Doctor) : InsertDoctorsResponse,ISuccess;
}
