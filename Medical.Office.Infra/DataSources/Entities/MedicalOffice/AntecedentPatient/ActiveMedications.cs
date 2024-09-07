using System.Diagnostics;

namespace Medical.Office.Infra.DataSources.Entities.MedicalOffice.AntecedentPatient
{
    [DebuggerDisplay("{Name}")]
    public class ActiveMedications
    {
        public long Id { get; set; }

        //[Required]
        public long IDPatient { get; set; }

        public string AactiveMedicationsData { get; set; }

        public DateTime? DateTimeSnap { get; set; }
    }
}
