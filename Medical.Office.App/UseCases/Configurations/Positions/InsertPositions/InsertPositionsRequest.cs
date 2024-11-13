using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.Positions.InsertPositions.Responses;
using System.Text.RegularExpressions;

namespace Medical.Office.App.UseCases.Configurations.Positions.InsertPositions
{
    public sealed class InsertPositionsRequest : IRequest<InsertPositionsResponse>
    {
        public string PositionName { get; set; }
        public InsertPositionsRequest(string positionName)
        {
            PositionName = positionName;
        }

        public static void Validations(PositionsDto positions, ErrorList errors)
        {
            string pattern = "^[A-Z][a-z]*$";

            if (positions == null) 
            {
                errors.Add("No se agrego ninguna posicion");
                return;
            }
            if (string.IsNullOrEmpty(positions.PositionName) || string.IsNullOrWhiteSpace(positions.PositionName))
            {
                errors.Add("No se agrego ninguna posicion");
            }
            if (!Regex.IsMatch(positions.PositionName, pattern))
            {
                errors.Add("Formato de texto invalido, el nombre de la posición debe comenzar con una letra mayúscula y el resto en minúsculas y sin numeros");
            }
        }

        public static bool CanInsert(PositionsDto positions, out ErrorList errors) 
        {
            errors = new ErrorList();
            Validations(positions, errors);
            return errors.IsEmpty;
        }

        public static InsertPositionsRequest Create(PositionsDto positions) 
        {
            if (!CanInsert(positions, out ErrorList errors)) throw errors.AsException();
            return new InsertPositionsRequest(positions.PositionName);
        }
    }
}
