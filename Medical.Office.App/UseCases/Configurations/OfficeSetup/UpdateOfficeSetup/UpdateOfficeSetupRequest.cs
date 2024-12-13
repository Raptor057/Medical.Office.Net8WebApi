using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.OfficeSetup.InsertOfficeSetup;
using Medical.Office.App.UseCases.Configurations.OfficeSetup.UpdateOfficeSetup.Responses;

namespace Medical.Office.App.UseCases.Configurations.OfficeSetup.UpdateOfficeSetup
{
    public sealed class UpdateOfficeSetupRequest : IRequest<UpdateOfficeSetupResponse>
    {
        public string NameOfOffice { get; set; }
        public string Address { get; set; }

        //public InsertOfficeSetupRequest(string nameOfOffice, string address, TimeSpan openingTime, TimeSpan closingTime)
        public UpdateOfficeSetupRequest(OfficeSetupDto officeSetup)
        {
            NameOfOffice = officeSetup.NameOfOffice;
            Address = officeSetup.Address;
        }

        public static void Validations(OfficeSetupDto officeSetup, ErrorList errors)
        {
            if (officeSetup == null)
            {
                errors.Add("No se ingreso ningun dato");
                return;
            }
            if (string.IsNullOrEmpty(officeSetup.NameOfOffice))
            {
                errors.Add("No se ingreso nombre del consultorio");
            }
            if (string.IsNullOrEmpty(officeSetup.Address))
            {
                errors.Add("No se ingreso una direccion");
            }
        }

        public static bool CanInsert(OfficeSetupDto officeSetup, out ErrorList errors)
        {
            errors = new();
            Validations(officeSetup, errors);
            return errors.IsEmpty;
        }

        public static UpdateOfficeSetupRequest Create(OfficeSetupDto officeSetup)
        {
            if (!CanInsert(officeSetup, out ErrorList errors)) throw errors.AsException();
            return new UpdateOfficeSetupRequest(officeSetup);
        }
    }
}
