using Common.Common;
using System.Text.RegularExpressions;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.Positions.InsertPositions;
using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Configurations.Specialties.InsertSpecialties.Responses;

namespace Medical.Office.App.UseCases.Configurations.Specialties.InsertSpecialties
{
    public sealed class InsertSpecialtiesRequest : IRequest<InsertSpecialtiesResponse>
    {
        public string Specialtie {  get; set; }

        public InsertSpecialtiesRequest(string specialtie)
        {
            Specialtie = specialtie;
        }

        public static void Validations(SpecialtiesDto Specialtie, ErrorList errors)
        {
            string pattern = "^[A-Z][a-z]*$";

            if (Specialtie == null)
            {
                errors.Add("No se agrego ninguna posicion");
                return;
            }
            if (string.IsNullOrEmpty(Specialtie.Specialty) || string.IsNullOrWhiteSpace(Specialtie.Specialty))
            {
                errors.Add("No se agrego ninguna posicion");
            }
            if (!Regex.IsMatch(Specialtie.Specialty, pattern))
            {
                errors.Add("Formato de texto invalido, el nombre de la especialidad debe comenzar con una letra mayúscula y el resto en minúsculas y sin numeros");
            }
        }

        public static bool CanInsert(SpecialtiesDto Specialtie, out ErrorList errors)
        {
            errors = new ErrorList();
            Validations(Specialtie, errors);
            return errors.IsEmpty;
        }

        public static InsertPositionsRequest Create(SpecialtiesDto Specialtie)
        {
            if (!CanInsert(Specialtie, out ErrorList errors)) throw errors.AsException();
            return new InsertPositionsRequest(Specialtie.Specialty);
        }

    }
}
