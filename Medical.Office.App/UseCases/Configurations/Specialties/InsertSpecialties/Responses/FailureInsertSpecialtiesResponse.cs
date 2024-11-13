using Common.Common;

namespace Medical.Office.App.UseCases.Configurations.Specialties.InsertSpecialties.Responses
{
    public record FailureInsertSpecialtiesResponse(string Message) : InsertSpecialtiesResponse,IFailure;
}
