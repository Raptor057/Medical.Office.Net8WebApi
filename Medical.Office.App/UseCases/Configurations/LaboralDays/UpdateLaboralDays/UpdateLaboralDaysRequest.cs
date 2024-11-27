using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.App.Dtos.Configurations;
using Medical.Office.App.UseCases.Configurations.LaboralDays.UpdateLaboralDays.Response;

namespace Medical.Office.App.UseCases.Configurations.LaboralDays.UpdateLaboralDays
{
    public sealed class UpdateLaboralDaysRequest : IRequest<UpdateLaboralDaysResponse>
    {

        public LaboralDaysDto LaboralDays { get; set; }
        public UpdateLaboralDaysRequest(LaboralDaysDto  laboralDays )
        {
            LaboralDays=laboralDays;
        }

        public static void Validations(LaboralDaysDto laboralDays, ErrorList errors)
        {
            if (laboralDays == null)
            {
                errors.Add("No se agrego ninguna dato");
                return;
            }
            if (laboralDays.Laboral == null)
            {

            }
            if (laboralDays.OpeningTime == TimeSpan.Zero || laboralDays.ClosingTime == TimeSpan.Zero)
            {
                errors.Add($"El horario de apertura {laboralDays.OpeningTime} o de cierre {laboralDays.ClosingTime} no son validos no pueden ser {TimeSpan.Zero} ");
            }
        }
        public static bool CanUpdate(LaboralDaysDto laboralDays, out ErrorList errors)
        {
            errors = new ErrorList();
            Validations(laboralDays, errors);
            return errors.IsEmpty;
        }

        public static UpdateLaboralDaysRequest Update(LaboralDaysDto laboralDays)
        {
            if (!CanUpdate(laboralDays, out ErrorList errors)) throw errors.AsException();
            return new UpdateLaboralDaysRequest(laboralDays);
        }

    }
}
