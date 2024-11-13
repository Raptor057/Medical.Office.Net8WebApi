namespace Medical.Office.Net8WebApi.EndPoints.Configuration.OfficeSetup.InsertOfficeSetup
{
    public class InsertOfficeSetupRequestBody
    {
        public string NameOfOffice { get; set; }

        public string Address { get; set; }

        public string OpeningTime { get; set; }

        public string ClosingTime { get; set; }
    }
}
