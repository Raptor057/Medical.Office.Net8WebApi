using Common.Common;

namespace Medical.Office.App.UseCases.Configurations.Specialties.InsertSpecialties.Responses
{
    public record SuccessInsertSpecialtiesResponse(string Specialtie) : InsertSpecialtiesResponse, ISuccess;
}
