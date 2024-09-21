namespace Medical.Office.Domain.Entities.MedicalOffice
{
    public class LoginHistory
    {
        public long Id { get; set; }

        public string Usr { get; set; }

        public string UsrName { get; set; }

        public string? UsrToken { get; set; }

        public DateTime? DateTimeSnap { get; set; }

    }
}
