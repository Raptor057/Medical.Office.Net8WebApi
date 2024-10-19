namespace Medical.Office.Domain.Entities.MedicalOffice.AntecedentPatient
{
    public class PatientAllergies
    {
        public long Id { get; set; }

        public long IDPatient { get; set; }

        public string Allergies { get; set; }

        public DateTime? DateTimeSnap { get; set; }

    }
}
