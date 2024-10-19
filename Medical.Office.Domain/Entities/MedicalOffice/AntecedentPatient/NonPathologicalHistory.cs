namespace Medical.Office.Domain.Entities.MedicalOffice.AntecedentPatient
{
    public class NonPathologicalHistory
    {
        public long Id { get; set; }

        public long IDPatient { get; set; }

        public bool? PhysicalActivity { get; set; }

        public bool? Smoking { get; set; }

        public bool? Alcoholism { get; set; }

        public bool? SubstanceAbuse { get; set; }

        public string SubstanceAbuseData { get; set; }

        public bool? RecentVaccination { get; set; }

        public string RecentVaccinationData { get; set; }

        public bool? Others { get; set; }

        public string OthersData { get; set; }

        public DateTime? DateTimeSnap { get; set; }

    }
}
