using Medical.Office.Domain.Entities.POS;

namespace Medical.Office.Domain.Repository;

public interface IPosRepository
{

// CashMovements
        //Task<IEnumerable<CashMovements>> GetCashMovementsAsync();
        //Task<CashMovements> GetCashMovementByIdAsync(CashMovements cashMovements);
        //Task InsertCashMovementAsync(CashMovements cashMovements);
        //Task UpdateCashMovementAsync(CashMovements cashMovements);
        //Task DeleteCashMovementAsync(CashMovements cashMovements);

    // CashMovements
    Task<IEnumerable<CashMovements>> GetCashMovementsAsync();

    Task<CashMovements> GetCashMovementByIdAsync(int cashMovementId);

    Task InsertCashMovementAsync(int cashRegisterId, DateTime movementDate, string movementType, decimal amount, string description);

    Task UpdateCashMovementAsync(int cashMovementId, int cashRegisterId, DateTime movementDate, string movementType, decimal amount, string description);

    Task DeleteCashMovementAsync(int cashMovementId);


    // CashRegisters
    //Task<IEnumerable<CashRegisters>> GetCashRegistersAsync();
    //Task<CashRegisters> GetCashRegisterByIdAsync(CashRegisters cashRegisters);
    //Task InsertCashRegisterAsync(CashRegisters cashRegisters);
    //Task UpdateCashRegisterAsync(CashRegisters cashRegisters);
    //Task DeleteCashRegisterAsync(CashRegisters cashRegisters);

    // CashRegisters
    Task<IEnumerable<CashRegisters>> GetCashRegistersAsync();

    Task<CashRegisters> GetCashRegisterByIdAsync(int cashRegisterId);

    Task InsertCashRegisterAsync(string registerName, string registerStatus, DateTime openingDate, DateTime? closingDate, decimal initialBalance, decimal? finalBalance);

    Task UpdateCashRegisterAsync(int cashRegisterId, string registerName, string registerStatus, DateTime openingDate, DateTime? closingDate, decimal initialBalance, decimal? finalBalance);

    Task DeleteCashRegisterAsync(int cashRegisterId);


    // InventoryMovements
    //Task<IEnumerable<InventoryMovements>> GetInventoryMovementsAsync();
    //    Task<InventoryMovements> GetInventoryMovementByIdAsync(InventoryMovements inventoryMovements);
    //    Task InsertInventoryMovementAsync(InventoryMovements inventoryMovements);
    //    Task UpdateInventoryMovementAsync(InventoryMovements inventoryMovements);
    //    Task DeleteInventoryMovementAsync(InventoryMovements inventoryMovements);

    // InventoryMovements
    Task<IEnumerable<InventoryMovements>> GetInventoryMovementsAsync();

    Task<InventoryMovements> GetInventoryMovementByIdAsync(int movementId);

    Task InsertInventoryMovementAsync(int productId, string movementType, int quantity, DateTime movementDate, string description);

    Task UpdateInventoryMovementAsync(int movementId, int productId, string movementType, int quantity, DateTime movementDate, string description);

    Task DeleteInventoryMovementAsync(int movementId);


    // PaymentTypes
    //Task<IEnumerable<PaymentTypes>> GetPaymentTypesAsync();
    //    Task<PaymentTypes> GetPaymentTypeByIdAsync(PaymentTypes paymentTypes);
    //    Task InsertPaymentTypeAsync(PaymentTypes paymentTypes);
    //    Task UpdatePaymentTypeAsync(PaymentTypes paymentTypes);
    //    Task DeletePaymentTypeAsync(PaymentTypes paymentTypes);
    // PaymentTypes
    Task<IEnumerable<PaymentTypes>> GetPaymentTypesAsync();

    Task<PaymentTypes> GetPaymentTypeByIdAsync(int id);

    Task InsertPaymentTypeAsync(string paymentTypeName);

    Task UpdatePaymentTypeAsync(int id, string paymentTypeName);

    Task DeletePaymentTypeAsync(int id);


    // ProductCategories
    //Task<IEnumerable<ProductCategories>> GetProductCategoriesAsync();
    //    Task<ProductCategories> GetProductCategoryByIdAsync(ProductCategories productCategories);
    //    Task InsertProductCategoryAsync(ProductCategories productCategories);
    //    Task UpdateProductCategoryAsync(ProductCategories productCategories);
    //    Task DeleteProductCategoryAsync(ProductCategories productCategories);
    // ProductCategories
    Task<IEnumerable<ProductCategories>> GetProductCategoriesAsync();

    Task<ProductCategories> GetProductCategoryByIdAsync(int productCategoryId);

    Task InsertProductCategoryAsync(string categoryName);

    Task UpdateProductCategoryAsync(int productCategoryId, string categoryName);

    Task DeleteProductCategoryAsync(int productCategoryId);


    // Products
    //Task<IEnumerable<Products>> GetProductsAsync();
    //    Task<Products> GetProductByIdAsync(Products products);
    //    Task InsertProductAsync(Products products);
    //    Task UpdateProductAsync(Products products);
    //    Task DeleteProductAsync(Products products);
    // Products
    Task<IEnumerable<Products>> GetProductsAsync();

    Task<Products> GetProductByIdAsync(int productId);

    Task InsertProductAsync(string productName, string description, decimal price, int stock, string productCategoryName, string idOrBarcode);

    Task UpdateProductAsync(int productId, string productName, string description, decimal price, int stock, string productCategoryName, string idOrBarcode);

    Task DeleteProductAsync(int productId);



    // Promotions
    //Task<IEnumerable<Promotions>> GetPromotionsAsync();
    //    Task<Promotions> GetPromotionByIdAsync(Promotions promotions);
    //    Task InsertPromotionAsync(Promotions promotions);
    //    Task UpdatePromotionAsync(Promotions promotions);
    //    Task DeletePromotionAsync(Promotions promotions);

    // Promotions
    Task<IEnumerable<Promotions>> GetPromotionsAsync();

    Task<Promotions> GetPromotionByIdAsync(int promotionId);

    Task InsertPromotionAsync(string promotionName, string description, DateTime startDate, DateTime endDate, string promotionType, decimal value);

    Task UpdatePromotionAsync(int promotionId, string promotionName, string description, DateTime startDate, DateTime endDate, string promotionType, decimal value);

    Task DeletePromotionAsync(int promotionId);




    // ReturnDetails
    //Task<IEnumerable<ReturnDetails>> GetReturnDetailsAsync();
    //    Task<ReturnDetails> GetReturnDetailByIdAsync(ReturnDetails returnDetails);
    //    Task InsertReturnDetailAsync(ReturnDetails returnDetails);
    //    Task UpdateReturnDetailAsync(ReturnDetails returnDetails);
    //    Task DeleteReturnDetailAsync(ReturnDetails returnDetails);

    // ReturnDetails
    Task<IEnumerable<ReturnDetails>> GetReturnDetailsAsync();

    Task<ReturnDetails> GetReturnDetailByIdAsync(int returnDetailId);

    Task InsertReturnDetailAsync(int returnId, int productId, int quantity, decimal unitPrice, decimal subtotal);

    Task UpdateReturnDetailAsync(int returnDetailId, int returnId, int productId, int quantity, decimal unitPrice, decimal subtotal);

    Task DeleteReturnDetailAsync(int returnDetailId);



    // ReturnsProducts
    //Task<IEnumerable<ReturnsProducts>> GetReturnsProductsAsync();
    //    Task<ReturnsProducts> GetReturnProductByIdAsync(ReturnsProducts returnsProducts);
    //    Task InsertReturnProductAsync(ReturnsProducts returnsProducts);
    //    Task UpdateReturnProductAsync(ReturnsProducts returnsProducts);
    //    Task DeleteReturnProductAsync(ReturnsProducts returnsProducts);

    // ReturnsProducts
    Task<IEnumerable<ReturnsProducts>> GetReturnsProductsAsync();

    Task<ReturnsProducts> GetReturnProductByIdAsync(int returnId);

    Task InsertReturnProductAsync(int saleId, DateTime returnDate, decimal refundedAmount, string returnStatusName);

    Task UpdateReturnProductAsync(int returnId, int saleId, DateTime returnDate, decimal refundedAmount, string returnStatusName);

    Task DeleteReturnProductAsync(int returnId);



    // ReturnStatuses
    //Task<IEnumerable<ReturnStatuses>> GetReturnStatusesAsync();
    //    Task<ReturnStatuses> GetReturnStatusByIdAsync(ReturnStatuses returnStatuses);
    //    Task InsertReturnStatusAsync(ReturnStatuses returnStatuses);
    //    Task UpdateReturnStatusAsync(ReturnStatuses returnStatuses);
    //    Task DeleteReturnStatusAsync(ReturnStatuses returnStatuses);
    // ReturnStatuses
    Task<IEnumerable<ReturnStatuses>> GetReturnStatusesAsync();

    Task<ReturnStatuses> GetReturnStatusByIdAsync(int returnStatusId);

    Task InsertReturnStatusAsync(string statusName);

    Task UpdateReturnStatusAsync(int returnStatusId, string statusName);

    Task DeleteReturnStatusAsync(int returnStatusId);



    // SaleDetails
    //Task<IEnumerable<SaleDetails>> GetSaleDetailsAsync();
    //    Task<SaleDetails> GetSaleDetailByIdAsync(SaleDetails saleDetails);
    //    Task InsertSaleDetailAsync(SaleDetails saleDetails);
    //    Task UpdateSaleDetailAsync(SaleDetails saleDetails);
    //    Task DeleteSaleDetailAsync(SaleDetails saleDetails);
    // SaleDetails
    Task<IEnumerable<SaleDetails>> GetSaleDetailsAsync();

    Task<SaleDetails> GetSaleDetailByIdAsync(int saleDetailId);

    Task InsertSaleDetailAsync(int saleId, int productId, int quantity, decimal unitPrice, decimal subtotal);

    Task UpdateSaleDetailAsync(int saleDetailId, int saleId, int productId, int quantity, decimal unitPrice, decimal subtotal);

    Task DeleteSaleDetailAsync(int saleDetailId);



    // Sales
    //Task<IEnumerable<Sales>> GetSalesAsync();
    //    Task<Sales> GetSaleByIdAsync(Sales sales);
    //    Task InsertSaleAsync(Sales sales);
    //    Task UpdateSaleAsync(Sales sales);
    //    Task DeleteSaleAsync(Sales sales);
    // Sales
    Task<IEnumerable<Sales>> GetSalesAsync();

    Task<Sales> GetSaleByIdAsync(int saleId);

    Task InsertSaleAsync(long idPatient, DateTime saleDate, decimal totalAmount, string paymentType, string saleStatus, long userId);

    Task UpdateSaleAsync(int saleId, long idPatient, DateTime saleDate, decimal totalAmount, string paymentType, string saleStatus, long userId);

    Task DeleteSaleAsync(int saleId);



    // SalesPromotions
    //Task<IEnumerable<SalesPromotions>> GetSalesPromotionsAsync();
    //    Task<SalesPromotions> GetSalesPromotionByIdAsync(SalesPromotions salesPromotions);
    //    Task InsertSalesPromotionAsync(SalesPromotions salesPromotions);
    //    Task UpdateSalesPromotionAsync(SalesPromotions salesPromotions);
    //    Task DeleteSalesPromotionAsync(SalesPromotions salesPromotions);
    // SalesPromotions
    Task<IEnumerable<SalesPromotions>> GetSalesPromotionsAsync();

    Task<SalesPromotions> GetSalesPromotionByIdAsync(int salePromotionId);

    Task InsertSalesPromotionAsync(int saleId, int promotionId, decimal discountApplied);

    Task UpdateSalesPromotionAsync(int salePromotionId, int saleId, int promotionId, decimal discountApplied);

    Task DeleteSalesPromotionAsync(int salePromotionId);



    // SaleStatuses
    //Task<IEnumerable<SaleStatuses>> GetSaleStatusesAsync();
    //    Task<SaleStatuses> GetSaleStatusByIdAsync(SaleStatuses saleStatuses);
    //    Task InsertSaleStatusAsync(SaleStatuses saleStatuses);
    //    Task UpdateSaleStatusAsync(SaleStatuses saleStatuses);
    //    Task DeleteSaleStatusAsync(SaleStatuses saleStatuses);
    // SaleStatuses
    Task<IEnumerable<SaleStatuses>> GetSaleStatusesAsync();

    Task<SaleStatuses> GetSaleStatusByIdAsync(int saleStatusId);

    Task InsertSaleStatusAsync(string statusName);

    Task UpdateSaleStatusAsync(int saleStatusId, string statusName);

    Task DeleteSaleStatusAsync(int saleStatusId);

}