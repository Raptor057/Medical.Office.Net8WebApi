using System.Diagnostics;

namespace Medical.Office.App.Dtos.Patients.AntecedentPatient.ActiveMedications
{
    //[DebuggerDisplay("{Name}")]
    public record ActiveMedicationsDto(long Id,long IDPatient,string AactiveMedicationsData,DateTime? DateTimeSnap);
}
