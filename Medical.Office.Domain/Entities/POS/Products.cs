namespace Medical.Office.Domain.Entities.POS
{
    public class Products
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string ProductCategoryName { get; set; }

        public string IDORBarcode { get; set; }

    }
}
