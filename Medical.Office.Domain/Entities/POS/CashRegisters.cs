namespace Medical.Office.Domain.Entities.POS
{
    public class CashRegisters
    {
        public int CashRegisterId { get; set; }

        public string RegisterName { get; set; }

        public string RegisterStatus { get; set; }

        public DateTime OpeningDate { get; set; }

        public DateTime? ClosingDate { get; set; }

        public decimal InitialBalance { get; set; }

        public decimal? FinalBalance { get; set; }

    }
}
