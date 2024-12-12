using Common.Common;

namespace Medical.Office.App.UseCases.Configurations.Doctors.InsertDoctors.Response
{
    public record FailureInsertDoctorsResponse(string Message) : InsertDoctorsResponse, IFailure;
}
