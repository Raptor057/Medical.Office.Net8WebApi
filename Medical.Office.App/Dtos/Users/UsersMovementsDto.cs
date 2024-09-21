namespace Medical.Office.App.Dtos.Users
{
    public class UsersMovementsDto
    {
        public long Id { get; set; }

        public string Usr { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string Movement { get; set; }

        public DateTime? DateTimeSnap { get; set; }

    }
}
