using Common.Common;

namespace Medical.Office.App.UseCases.Configurations.Doctors.UpdateDoctors.Response
{
    public record FailureUpdateDoctorsResponse(string Message) : UpdateDoctorsResponse,IFailure;
}
