namespace Medical.Office.Domain.Entities.MedicalOffice.AntecedentPatient
{
    public class MedicalHistoryNotes
    {
        public long Id { get; set; }

        public long? IDPatient { get; set; }

        public string MedicalHistoryNotesData { get; set; }

        public DateTime? DateTimeSnap { get; set; }

    }
}
