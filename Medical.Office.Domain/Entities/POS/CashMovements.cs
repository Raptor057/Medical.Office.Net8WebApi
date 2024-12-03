namespace Medical.Office.Domain.Entities.POS
{
    public class CashMovements
    {
        public int CashMovementId { get; set; }

        public int CashRegisterId { get; set; }

        public DateTime MovementDate { get; set; }

        public string MovementType { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

    }
}
