namespace Medical.Office.Infra.DataSources.Entities.MedicalOffice
{
    public class Doctors
    {
        public long ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Specialty { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
