using Medical.Office.Domain.Entities.POS;

namespace Medical.Office.Domain.Repository;

public interface IPosRepository
{

// CashMovements
        Task<IEnumerable<CashMovements>> GetCashMovementsAsync();
        Task<CashMovements> GetCashMovementByIdAsync(CashMovements cashMovements);
        Task InsertCashMovementAsync(CashMovements cashMovements);
        Task UpdateCashMovementAsync(CashMovements cashMovements);
        Task DeleteCashMovementAsync(CashMovements cashMovements);

        // CashRegisters
        Task<IEnumerable<CashRegisters>> GetCashRegistersAsync();
        Task<CashRegisters> GetCashRegisterByIdAsync(CashRegisters cashRegisters);
        Task InsertCashRegisterAsync(CashRegisters cashRegisters);
        Task UpdateCashRegisterAsync(CashRegisters cashRegisters);
        Task DeleteCashRegisterAsync(CashRegisters cashRegisters);

        // InventoryMovements
        Task<IEnumerable<InventoryMovements>> GetInventoryMovementsAsync();
        Task<InventoryMovements> GetInventoryMovementByIdAsync(InventoryMovements inventoryMovements);
        Task InsertInventoryMovementAsync(InventoryMovements inventoryMovements);
        Task UpdateInventoryMovementAsync(InventoryMovements inventoryMovements);
        Task DeleteInventoryMovementAsync(InventoryMovements inventoryMovements);

        // PaymentTypes
        Task<IEnumerable<PaymentTypes>> GetPaymentTypesAsync();
        Task<PaymentTypes> GetPaymentTypeByIdAsync(PaymentTypes paymentTypes);
        Task InsertPaymentTypeAsync(PaymentTypes paymentTypes);
        Task UpdatePaymentTypeAsync(PaymentTypes paymentTypes);
        Task DeletePaymentTypeAsync(PaymentTypes paymentTypes);

        // ProductCategories
        Task<IEnumerable<ProductCategories>> GetProductCategoriesAsync();
        Task<ProductCategories> GetProductCategoryByIdAsync(ProductCategories productCategories);
        Task InsertProductCategoryAsync(ProductCategories productCategories);
        Task UpdateProductCategoryAsync(ProductCategories productCategories);
        Task DeleteProductCategoryAsync(ProductCategories productCategories);

        // Products
        Task<IEnumerable<Products>> GetProductsAsync();
        Task<Products> GetProductByIdAsync(Products products);
        Task InsertProductAsync(Products products);
        Task UpdateProductAsync(Products products);
        Task DeleteProductAsync(Products products);

        // Promotions
        Task<IEnumerable<Promotions>> GetPromotionsAsync();
        Task<Promotions> GetPromotionByIdAsync(Promotions promotions);
        Task InsertPromotionAsync(Promotions promotions);
        Task UpdatePromotionAsync(Promotions promotions);
        Task DeletePromotionAsync(Promotions promotions);

        // ReturnDetails
        Task<IEnumerable<ReturnDetails>> GetReturnDetailsAsync();
        Task<ReturnDetails> GetReturnDetailByIdAsync(ReturnDetails returnDetails);
        Task InsertReturnDetailAsync(ReturnDetails returnDetails);
        Task UpdateReturnDetailAsync(ReturnDetails returnDetails);
        Task DeleteReturnDetailAsync(ReturnDetails returnDetails);

        // ReturnsProducts
        Task<IEnumerable<ReturnsProducts>> GetReturnsProductsAsync();
        Task<ReturnsProducts> GetReturnProductByIdAsync(ReturnsProducts returnsProducts);
        Task InsertReturnProductAsync(ReturnsProducts returnsProducts);
        Task UpdateReturnProductAsync(ReturnsProducts returnsProducts);
        Task DeleteReturnProductAsync(ReturnsProducts returnsProducts);

        // ReturnStatuses
        Task<IEnumerable<ReturnStatuses>> GetReturnStatusesAsync();
        Task<ReturnStatuses> GetReturnStatusByIdAsync(ReturnStatuses returnStatuses);
        Task InsertReturnStatusAsync(ReturnStatuses returnStatuses);
        Task UpdateReturnStatusAsync(ReturnStatuses returnStatuses);
        Task DeleteReturnStatusAsync(ReturnStatuses returnStatuses);

        // SaleDetails
        Task<IEnumerable<SaleDetails>> GetSaleDetailsAsync();
        Task<SaleDetails> GetSaleDetailByIdAsync(SaleDetails saleDetails);
        Task InsertSaleDetailAsync(SaleDetails saleDetails);
        Task UpdateSaleDetailAsync(SaleDetails saleDetails);
        Task DeleteSaleDetailAsync(SaleDetails saleDetails);

        // Sales
        Task<IEnumerable<Sales>> GetSalesAsync();
        Task<Sales> GetSaleByIdAsync(Sales sales);
        Task InsertSaleAsync(Sales sales);
        Task UpdateSaleAsync(Sales sales);
        Task DeleteSaleAsync(Sales sales);

        // SalesPromotions
        Task<IEnumerable<SalesPromotions>> GetSalesPromotionsAsync();
        Task<SalesPromotions> GetSalesPromotionByIdAsync(SalesPromotions salesPromotions);
        Task InsertSalesPromotionAsync(SalesPromotions salesPromotions);
        Task UpdateSalesPromotionAsync(SalesPromotions salesPromotions);
        Task DeleteSalesPromotionAsync(SalesPromotions salesPromotions);

        // SaleStatuses
        Task<IEnumerable<SaleStatuses>> GetSaleStatusesAsync();
        Task<SaleStatuses> GetSaleStatusByIdAsync(SaleStatuses saleStatuses);
        Task InsertSaleStatusAsync(SaleStatuses saleStatuses);
        Task UpdateSaleStatusAsync(SaleStatuses saleStatuses);
        Task DeleteSaleStatusAsync(SaleStatuses saleStatuses);
}