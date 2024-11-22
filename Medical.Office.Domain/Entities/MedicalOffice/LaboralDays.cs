namespace Medical.Office.Domain.Entities.MedicalOffice
{
    public class LaboralDays
    {
        public int Id { get; set; }

        public string Days { get; set; }

        public bool Laboral { get; set; }

        public TimeSpan OpeningTime { get; set; }

        public TimeSpan ClosingTime { get; set; }

    }
}
