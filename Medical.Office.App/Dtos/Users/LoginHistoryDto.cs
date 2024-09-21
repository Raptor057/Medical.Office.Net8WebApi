namespace Medical.Office.App.Dtos.Users
{
    public class LoginHistoryDto
    {
        public long Id { get; set; }

        public string Usr { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public DateTime? DateTimeSnap { get; set; }
    }
}
