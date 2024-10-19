namespace Medical.Office.Domain.Entities.MedicalOffice.AntecedentPatient
{
    public class FamilyHistory
    {
        public long Id { get; set; }

        public long IDPatient { get; set; }

        public bool? Diabetes { get; set; }

        public bool? Cardiopathies { get; set; }

        public bool? Hypertension { get; set; }

        public bool? ThyroidDiseases { get; set; }

        public bool? ChronicKidneyDisease { get; set; }

        public bool? Others { get; set; }

        public string OthersData { get; set; }

        public DateTime? DateTimeSnap { get; set; }

    }
}
