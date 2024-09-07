namespace Medical.Office.Infra.DataSources.Entities.MedicalOffice
{
    public class OfficeSetup
    {
        public int Id { get; set; }

        public string NameOfOffice { get; set; }

        public string Address { get; set; }

        public TimeSpan OpeningTime { get; set; }

        public TimeSpan ClosingTime { get; set; }

    }

}
