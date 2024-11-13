using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.OfficeSetup.InsertOfficeSetup.Responses;

namespace Medical.Office.App.UseCases.Configurations.OfficeSetup.InsertOfficeSetup
{
    public sealed class InsertOfficeSetupRequest : IRequest<InsertOfficeSetupResponse>
    {
        public string NameOfOffice { get; set; }
        public string Address { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }

        //public InsertOfficeSetupRequest(string nameOfOffice, string address, TimeSpan openingTime, TimeSpan closingTime)
        public InsertOfficeSetupRequest(OfficeSetupDto officeSetup)
        {
            NameOfOffice = officeSetup.NameOfOffice;
            Address= officeSetup.Address;
            OpeningTime= officeSetup.OpeningTime;
            ClosingTime= officeSetup.ClosingTime;
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
            if (officeSetup.OpeningTime == null || officeSetup.OpeningTime == TimeSpan.Zero)
            {
                errors.Add("No se ingreso hora de apertura");
            }
            if (officeSetup.ClosingTime == null || officeSetup.ClosingTime == TimeSpan.Zero)
            {
                errors.Add("No se ingreso hora de cierre");
            }
        }

        public static bool CanInsert(OfficeSetupDto officeSetup , out ErrorList errors)
        {
            errors = new();
            Validations(officeSetup, errors);
            return errors.IsEmpty;
        }

        public static InsertOfficeSetupRequest Create(OfficeSetupDto officeSetup)
        {
            if (!CanInsert(officeSetup, out ErrorList errors)) throw errors.AsException();
            return new InsertOfficeSetupRequest(officeSetup);
        }

    }
}