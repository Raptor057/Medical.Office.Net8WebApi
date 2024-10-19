namespace Medical.Office.Domain.Entities.MedicalOffice
{
    public class PatientData
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string FathersSurname { get; set; }

        public string MothersSurname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string OutsideNumber { get; set; }

        public string InsideNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string EmergencyContactName { get; set; }

        public string EmergencyContactPhone { get; set; }

        public string InsuranceProvider { get; set; }

        public string PolicyNumber { get; set; }

        public string BloodType { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? LastUpdated { get; set; }

        public byte[] Photo { get; set; }

        public string InternalNotes { get; set; }

    }
}
