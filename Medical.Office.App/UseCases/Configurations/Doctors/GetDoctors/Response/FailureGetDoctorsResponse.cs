using Common.Common;

namespace Medical.Office.App.UseCases.Configurations.Doctors.GetDoctors.Response
{
    public record FailureGetDoctorsResponse(string Message): GetDoctorsResponse,IFailure;
}
