namespace Medical.Office.Domain.Entities.MedicalOffice
{
    public class UsersMovements
    {
        public long Id { get; set; }

        public string Usr { get; set; }

        public string UsrName { get; set; }

        public string UsrRole { get; set; }

        public string UsrMovement { get; set; }
        
        public string? UsrToken { get; set; }

        public DateTime? DateTimeSnap { get; set; }

    }
}
