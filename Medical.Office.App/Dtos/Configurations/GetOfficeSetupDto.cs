namespace Medical.Office.App.Dtos.Configurations
{
    public class GetOfficeSetupDto
    {
        public string NameOfOffice { get; set; }

        public string Address { get; set; }

        public TimeSpan OpeningTime { get; set; }

        public TimeSpan ClosingTime { get; set; }
    }
}
