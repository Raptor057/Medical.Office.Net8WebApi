namespace Medical.Office.Domain.DataSources.Entities.MedicalOffice
{
    public class PatientData
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string FathersSurname { get; set; }

        public string MothersSurname { get; set; }

        public DateTime DateOfBirth_ { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string OutsideNumber { get; set; }

        public string InsideNumber { get; set; }

        public string PhoneNumber_ { get; set; }

        public string Email_ { get; set; }

        public string EmergencyContactName_ { get; set; }

        public string EmergencyContactPhone_ { get; set; }

        public string InsuranceProvider_ { get; set; }

        public string PolicyNumber_ { get; set; }

        public string BloodType_ { get; set; }

        public DateTime? DateCreated_ { get; set; }

        public DateTime? LastUpdated_ { get; set; }

        public byte[] Photo { get; set; }

        public string InternalNotes { get; set; }

    }
}
