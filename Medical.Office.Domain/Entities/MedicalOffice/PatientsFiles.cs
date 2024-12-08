namespace Medical.Office.Domain.Entities.MedicalOffice
{
    public class PatientsFiles
    {
        public long Id { get; set; }

        public long IDPatient { get; set; }

        public string FileName { get; set; }

        public string FileType { get; set; }

        public string FileExtension { get; set; }

        public string Description { get; set; }

        public byte[] FileData { get; set; }

        public DateTime DateTimeUploaded { get; set; }

    }
}
