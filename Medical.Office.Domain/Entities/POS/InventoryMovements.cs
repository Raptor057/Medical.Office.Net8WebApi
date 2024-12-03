namespace Medical.Office.Domain.Entities.POS
{
    public class InventoryMovements
    {
        public int MovementId { get; set; }

        public int ProductId { get; set; }

        public string MovementType { get; set; }

        public int Quantity { get; set; }

        public DateTime MovementDate { get; set; }

        public string Description { get; set; }

    }
}
