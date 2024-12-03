namespace Medical.Office.App.Dtos.POS
{
    public record ProductsDto(

        int ProductId,
        string ProductName,
        string Description,
        decimal Price,
        int Stock,
        string ProductCategoryName,
        string IDORBarcode
    );
}
