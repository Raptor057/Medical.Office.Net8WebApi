using Medical.Office.Domain.Entities.POS;
using Medical.Office.Domain.Repository;
using Medical.Office.Infra.DataSources;

namespace Medical.Office.Infra.Repositories;

public class PosRepository : IPosRepository
{
    private readonly MedicalOfficeSqlLocalDB _db;

    public PosRepository(MedicalOfficeSqlLocalDB db)
    {
        _db = db;
    }

    public async Task DeleteCashMovementAsync(int cashMovementId)
    {
        CashMovements cashMovement = new()
        {
            CashMovementId = cashMovementId
        };

        await _db.DeleteCashMovementAsync(cashMovement).ConfigureAwait(false);
    }

    public async Task DeleteCashRegisterAsync(int cashRegisterId)
    {
        CashRegisters cashRegister = new()
        {
            CashRegisterId = cashRegisterId
        };

        await _db.DeleteCashRegisterAsync(cashRegister).ConfigureAwait(false);
    }

    public async Task DeleteInventoryMovementAsync(int movementId)
    {
        InventoryMovements inventoryMovement = new()
        {
            MovementId = movementId
        };

        await _db.DeleteInventoryMovementAsync(inventoryMovement).ConfigureAwait(false);
    }


    public async Task DeletePaymentTypeAsync(int id)
    {
        PaymentTypes paymentType = new()
        {
            Id = id
        };

        await _db.DeletePaymentTypeAsync(paymentType).ConfigureAwait(false);
    }

    public async Task DeleteProductAsync(int productId)
    {
        Products product = new()
        {
            ProductId = productId
        };

        await _db.DeleteProductAsync(product).ConfigureAwait(false);
    }

    public async Task DeleteProductCategoryAsync(int productCategoryId)
    {
        ProductCategories productCategory = new()
        {
            ProductCategoryId = productCategoryId
        };

        await _db.DeleteProductCategoryAsync(productCategory).ConfigureAwait(false);
    }

    public async Task DeletePromotionAsync(int promotionId)
    {
        Promotions promotion = new()
        {
            PromotionId = promotionId
        };

        await _db.DeletePromotionAsync(promotion).ConfigureAwait(false);
    }


    public async Task DeleteReturnDetailAsync(int returnDetailId)
    {
        ReturnDetails returnDetail = new()
        {
            ReturnDetailId = returnDetailId
        };

        await _db.DeleteReturnDetailAsync(returnDetail).ConfigureAwait(false);
    }

    public async Task DeleteReturnProductAsync(int returnId)
    {
        ReturnsProducts returnProduct = new()
        {
            ReturnId = returnId
        };

        await _db.DeleteReturnProductAsync(returnProduct).ConfigureAwait(false);
    }

    public async Task DeleteReturnStatusAsync(int returnStatusId)
    {
        ReturnStatuses returnStatus = new()
        {
            ReturnStatusId = returnStatusId
        };

        await _db.DeleteReturnStatusAsync(returnStatus).ConfigureAwait(false);
    }

    public async Task DeleteSaleAsync(int saleId)
    {
        Sales sale = new()
        {
            SaleId = saleId
        };

        await _db.DeleteSaleAsync(sale).ConfigureAwait(false);
    }

    public async Task DeleteSaleDetailAsync(int saleDetailId)
    {
        SaleDetails saleDetail = new()
        {
            SaleDetailId = saleDetailId
        };

        await _db.DeleteSaleDetailAsync(saleDetail).ConfigureAwait(false);
    }


    public async Task DeleteSalesPromotionAsync(int salePromotionId)
    {
        SalesPromotions salesPromotion = new()
        {
            SalePromotionId = salePromotionId
        };

        await _db.DeleteSalesPromotionAsync(salesPromotion).ConfigureAwait(false);
    }

    public async Task DeleteSaleStatusAsync(int saleStatusId)
    {
        SaleStatuses saleStatus = new()
        {
            SaleStatusId = saleStatusId
        };

        await _db.DeleteSaleStatusAsync(saleStatus).ConfigureAwait(false);
    }


    public async Task<CashMovements> GetCashMovementByIdAsync(int cashMovementId)
    {
        CashMovements cashMovement = new()
        {
            CashMovementId = cashMovementId
        };

        return await _db.GetCashMovementByIdAsync(cashMovement).ConfigureAwait(false);
    }

    public async Task<IEnumerable<CashMovements>> GetCashMovementsAsync()
    {
        return await _db.GetCashMovementsAsync().ConfigureAwait(false);
    }

    public async Task<CashRegisters> GetCashRegisterByIdAsync(int cashRegisterId)
    {
        CashRegisters cashRegister = new()
        {
            CashRegisterId = cashRegisterId
        };

        return await _db.GetCashRegisterByIdAsync(cashRegister).ConfigureAwait(false);
    }

    public async Task<IEnumerable<CashRegisters>> GetCashRegistersAsync()
    {
        return await _db.GetCashRegistersAsync().ConfigureAwait(false);
    }

    public async Task<InventoryMovements> GetInventoryMovementByIdAsync(int movementId)
    {
        InventoryMovements inventoryMovement = new()
        {
            MovementId = movementId
        };

        return await _db.GetInventoryMovementByIdAsync(inventoryMovement).ConfigureAwait(false);
    }


    public async Task<IEnumerable<InventoryMovements>> GetInventoryMovementsAsync()
    {
        return await _db.GetInventoryMovementsAsync().ConfigureAwait(false);
    }

    public async Task<PaymentTypes> GetPaymentTypeByIdAsync(int id)
    {
        PaymentTypes paymentType = new()
        {
            Id = id
        };

        return await _db.GetPaymentTypeByIdAsync(paymentType).ConfigureAwait(false);
    }

    public async Task<IEnumerable<PaymentTypes>> GetPaymentTypesAsync()
    {
        return await _db.GetPaymentTypesAsync().ConfigureAwait(false);
    }

    public async Task<Products> GetProductByIdAsync(int productId)
    {
        Products product = new()
        {
            ProductId = productId
        };

        return await _db.GetProductByIdAsync(product).ConfigureAwait(false);
    }

    public async Task<IEnumerable<ProductCategories>> GetProductCategoriesAsync()
    {
        return await _db.GetProductCategoriesAsync().ConfigureAwait(false);
    }


    public async Task<ProductCategories> GetProductCategoryByIdAsync(int productCategoryId)
    {
        ProductCategories productCategory = new()
        {
            ProductCategoryId = productCategoryId
        };

        return await _db.GetProductCategoryByIdAsync(productCategory).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Products>> GetProductsAsync()
    {
        return await _db.GetProductsAsync().ConfigureAwait(false);
    }

    public async Task<Promotions> GetPromotionByIdAsync(int promotionId)
    {
        Promotions promotion = new()
        {
            PromotionId = promotionId
        };

        return await _db.GetPromotionByIdAsync(promotion).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Promotions>> GetPromotionsAsync()
    {
        return await _db.GetPromotionsAsync().ConfigureAwait(false);
    }

    public async Task<ReturnDetails> GetReturnDetailByIdAsync(int returnDetailId)
    {
        ReturnDetails returnDetail = new()
        {
            ReturnDetailId = returnDetailId
        };

        return await _db.GetReturnDetailByIdAsync(returnDetail).ConfigureAwait(false);
    }


    public async Task<IEnumerable<ReturnDetails>> GetReturnDetailsAsync()
    {
        return await _db.GetReturnDetailsAsync().ConfigureAwait(false);
    }

    public async Task<ReturnsProducts> GetReturnProductByIdAsync(int returnId)
    {
        ReturnsProducts returnProduct = new()
        {
            ReturnId = returnId
        };

        return await _db.GetReturnProductByIdAsync(returnProduct).ConfigureAwait(false);
    }

    public async Task<IEnumerable<ReturnsProducts>> GetReturnsProductsAsync()
    {
        return await _db.GetReturnsProductsAsync().ConfigureAwait(false);
    }

    public async Task<ReturnStatuses> GetReturnStatusByIdAsync(int returnStatusId)
    {
        ReturnStatuses returnStatus = new()
        {
            ReturnStatusId = returnStatusId
        };

        return await _db.GetReturnStatusByIdAsync(returnStatus).ConfigureAwait(false);
    }

    public async Task<IEnumerable<ReturnStatuses>> GetReturnStatusesAsync()
    {
        return await _db.GetReturnStatusesAsync().ConfigureAwait(false);
    }


    public async Task<Sales> GetSaleByIdAsync(int saleId)
    {
        Sales sale = new()
        {
            SaleId = saleId
        };

        return await _db.GetSaleByIdAsync(sale).ConfigureAwait(false);
    }

    public async Task<SaleDetails> GetSaleDetailByIdAsync(int saleDetailId)
    {
        SaleDetails saleDetail = new()
        {
            SaleDetailId = saleDetailId
        };

        return await _db.GetSaleDetailByIdAsync(saleDetail).ConfigureAwait(false);
    }

    public async Task<IEnumerable<SaleDetails>> GetSaleDetailsAsync()
    {
        return await _db.GetSaleDetailsAsync().ConfigureAwait(false);
    }

    public async Task<IEnumerable<Sales>> GetSalesAsync()
    {
        return await _db.GetSalesAsync().ConfigureAwait(false);
    }

    public async Task<SalesPromotions> GetSalesPromotionByIdAsync(int salePromotionId)
    {
        SalesPromotions salesPromotion = new()
        {
            SalePromotionId = salePromotionId
        };

        return await _db.GetSalesPromotionByIdAsync(salesPromotion).ConfigureAwait(false);
    }


    public async Task<IEnumerable<SalesPromotions>> GetSalesPromotionsAsync()
    {
        return await _db.GetSalesPromotionsAsync().ConfigureAwait(false);
    }

    public async Task<SaleStatuses> GetSaleStatusByIdAsync(int saleStatusId)
    {
        SaleStatuses saleStatus = new()
        {
            SaleStatusId = saleStatusId
        };

        return await _db.GetSaleStatusByIdAsync(saleStatus).ConfigureAwait(false);
    }

    public async Task<IEnumerable<SaleStatuses>> GetSaleStatusesAsync()
    {
        return await _db.GetSaleStatusesAsync().ConfigureAwait(false);
    }

    public async Task InsertCashMovementAsync(int cashRegisterId, DateTime movementDate, string movementType, decimal amount, string description)
    {
        CashMovements cashMovement = new()
        {
            CashRegisterId = cashRegisterId,
            MovementDate = movementDate,
            MovementType = movementType,
            Amount = amount,
            Description = description
        };

        await _db.InsertCashMovementAsync(cashMovement).ConfigureAwait(false);
    }

    public async Task InsertCashRegisterAsync(string registerName, string registerStatus, DateTime openingDate, DateTime? closingDate, decimal initialBalance, decimal? finalBalance)
    {
        CashRegisters cashRegister = new()
        {
            RegisterName = registerName,
            RegisterStatus = registerStatus,
            OpeningDate = openingDate,
            ClosingDate = closingDate,
            InitialBalance = initialBalance,
            FinalBalance = finalBalance
        };

        await _db.InsertCashRegisterAsync(cashRegister).ConfigureAwait(false);
    }


    public async Task InsertInventoryMovementAsync(int productId, string movementType, int quantity, DateTime movementDate, string description)
    {
        InventoryMovements inventoryMovement = new()
        {
            ProductId = productId,
            MovementType = movementType,
            Quantity = quantity,
            MovementDate = movementDate,
            Description = description
        };

        await _db.InsertInventoryMovementAsync(inventoryMovement).ConfigureAwait(false);
    }

    public async Task InsertPaymentTypeAsync(string paymentTypeName)
    {
        PaymentTypes paymentType = new()
        {
            PaymentTypeName = paymentTypeName
        };

        await _db.InsertPaymentTypeAsync(paymentType).ConfigureAwait(false);
    }

    public async Task InsertProductAsync(string productName, string description, decimal price, int stock, string productCategoryName, string idOrBarcode)
    {
        Products product = new()
        {
            ProductName = productName,
            Description = description,
            Price = price,
            Stock = stock,
            ProductCategoryName = productCategoryName,
            IDORBarcode = idOrBarcode
        };

        await _db.InsertProductAsync(product).ConfigureAwait(false);
    }

    public async Task InsertProductCategoryAsync(string categoryName)
    {
        ProductCategories productCategory = new()
        {
            CategoryName = categoryName
        };

        await _db.InsertProductCategoryAsync(productCategory).ConfigureAwait(false);
    }

    public async Task InsertPromotionAsync(string promotionName, string description, DateTime startDate, DateTime endDate, string promotionType, decimal value)
    {
        Promotions promotion = new()
        {
            PromotionName = promotionName,
            Description = description,
            StartDate = startDate,
            EndDate = endDate,
            PromotionType = promotionType,
            Value = value
        };

        await _db.InsertPromotionAsync(promotion).ConfigureAwait(false);
    }


    public async Task InsertReturnDetailAsync(int returnId, int productId, int quantity, decimal unitPrice, decimal subtotal)
    {
        ReturnDetails returnDetail = new()
        {
            ReturnId = returnId,
            ProductId = productId,
            Quantity = quantity,
            UnitPrice = unitPrice,
            Subtotal = subtotal
        };

        await _db.InsertReturnDetailAsync(returnDetail).ConfigureAwait(false);
    }

    public async Task InsertReturnProductAsync(int saleId, DateTime returnDate, decimal refundedAmount, string returnStatusName)
    {
        ReturnsProducts returnProduct = new()
        {
            SaleId = saleId,
            ReturnDate = returnDate,
            RefundedAmount = refundedAmount,
            ReturnStatusName = returnStatusName
        };

        await _db.InsertReturnProductAsync(returnProduct).ConfigureAwait(false);
    }

    public async Task InsertReturnStatusAsync(string statusName)
    {
        ReturnStatuses returnStatus = new()
        {
            StatusName = statusName
        };

        await _db.InsertReturnStatusAsync(returnStatus).ConfigureAwait(false);
    }

    public async Task InsertSaleAsync(long idPatient, DateTime saleDate, decimal totalAmount, string paymentType, string saleStatus, long userId)
    {
        Sales sale = new()
        {
            IDPatient = idPatient,
            SaleDate = saleDate,
            TotalAmount = totalAmount,
            PaymentType = paymentType,
            SaleStatus = saleStatus,
            UserId = userId
        };

        await _db.InsertSaleAsync(sale).ConfigureAwait(false);
    }

    public async Task InsertSaleDetailAsync(int saleId, int productId, int quantity, decimal unitPrice, decimal subtotal)
    {
        SaleDetails saleDetail = new()
        {
            SaleId = saleId,
            ProductId = productId,
            Quantity = quantity,
            UnitPrice = unitPrice,
            Subtotal = subtotal
        };

        await _db.InsertSaleDetailAsync(saleDetail).ConfigureAwait(false);
    }


    public async Task InsertSalesPromotionAsync(int saleId, int promotionId, decimal discountApplied)
    {
        SalesPromotions salesPromotion = new()
        {
            SaleId = saleId,
            PromotionId = promotionId,
            DiscountApplied = discountApplied
        };

        await _db.InsertSalesPromotionAsync(salesPromotion).ConfigureAwait(false);
    }

    public async Task InsertSaleStatusAsync(string statusName)
    {
        SaleStatuses saleStatus = new()
        {
            StatusName = statusName
        };

        await _db.InsertSaleStatusAsync(saleStatus).ConfigureAwait(false);
    }

    public async Task UpdateCashMovementAsync(int cashMovementId, int cashRegisterId, DateTime movementDate, string movementType, decimal amount, string description)
    {
        CashMovements cashMovement = new()
        {
            CashMovementId = cashMovementId,
            CashRegisterId = cashRegisterId,
            MovementDate = movementDate,
            MovementType = movementType,
            Amount = amount,
            Description = description
        };

        await _db.UpdateCashMovementAsync(cashMovement).ConfigureAwait(false);
    }

    public async Task UpdateCashRegisterAsync(int cashRegisterId, string registerName, string registerStatus, DateTime openingDate, DateTime? closingDate, decimal initialBalance, decimal? finalBalance)
    {
        CashRegisters cashRegister = new()
        {
            CashRegisterId = cashRegisterId,
            RegisterName = registerName,
            RegisterStatus = registerStatus,
            OpeningDate = openingDate,
            ClosingDate = closingDate,
            InitialBalance = initialBalance,
            FinalBalance = finalBalance
        };

        await _db.UpdateCashRegisterAsync(cashRegister).ConfigureAwait(false);
    }

    public async Task UpdateInventoryMovementAsync(int movementId, int productId, string movementType, int quantity, DateTime movementDate, string description)
    {
        InventoryMovements inventoryMovement = new()
        {
            MovementId = movementId,
            ProductId = productId,
            MovementType = movementType,
            Quantity = quantity,
            MovementDate = movementDate,
            Description = description
        };

        await _db.UpdateInventoryMovementAsync(inventoryMovement).ConfigureAwait(false);
    }


    public async Task UpdatePaymentTypeAsync(int id, string paymentTypeName)
    {
        PaymentTypes paymentType = new()
        {
            Id = id,
            PaymentTypeName = paymentTypeName
        };

        await _db.UpdatePaymentTypeAsync(paymentType).ConfigureAwait(false);
    }

    public async Task UpdateProductAsync(int productId, string productName, string description, decimal price, int stock, string productCategoryName, string idOrBarcode)
    {
        Products product = new()
        {
            ProductId = productId,
            ProductName = productName,
            Description = description,
            Price = price,
            Stock = stock,
            ProductCategoryName = productCategoryName,
            IDORBarcode = idOrBarcode
        };

        await _db.UpdateProductAsync(product).ConfigureAwait(false);
    }

    public async Task UpdateProductCategoryAsync(int productCategoryId, string categoryName)
    {
        ProductCategories productCategory = new()
        {
            ProductCategoryId = productCategoryId,
            CategoryName = categoryName
        };

        await _db.UpdateProductCategoryAsync(productCategory).ConfigureAwait(false);
    }

    public async Task UpdatePromotionAsync(int promotionId, string promotionName, string description, DateTime startDate, DateTime endDate, string promotionType, decimal value)
    {
        Promotions promotion = new()
        {
            PromotionId = promotionId,
            PromotionName = promotionName,
            Description = description,
            StartDate = startDate,
            EndDate = endDate,
            PromotionType = promotionType,
            Value = value
        };

        await _db.UpdatePromotionAsync(promotion).ConfigureAwait(false);
    }

    public async Task UpdateReturnDetailAsync(int returnDetailId, int returnId, int productId, int quantity, decimal unitPrice, decimal subtotal)
    {
        ReturnDetails returnDetail = new()
        {
            ReturnDetailId = returnDetailId,
            ReturnId = returnId,
            ProductId = productId,
            Quantity = quantity,
            UnitPrice = unitPrice,
            Subtotal = subtotal
        };

        await _db.UpdateReturnDetailAsync(returnDetail).ConfigureAwait(false);
    }


    public async Task UpdateReturnProductAsync(int returnId, int saleId, DateTime returnDate, decimal refundedAmount, string returnStatusName)
    {
        ReturnsProducts returnProduct = new()
        {
            ReturnId = returnId,
            SaleId = saleId,
            ReturnDate = returnDate,
            RefundedAmount = refundedAmount,
            ReturnStatusName = returnStatusName
        };

        await _db.UpdateReturnProductAsync(returnProduct).ConfigureAwait(false);
    }

    public async Task UpdateReturnStatusAsync(int returnStatusId, string statusName)
    {
        ReturnStatuses returnStatus = new()
        {
            ReturnStatusId = returnStatusId,
            StatusName = statusName
        };

        await _db.UpdateReturnStatusAsync(returnStatus).ConfigureAwait(false);
    }

    public async Task UpdateSaleAsync(int saleId, long idPatient, DateTime saleDate, decimal totalAmount, string paymentType, string saleStatus, long userId)
    {
        Sales sale = new()
        {
            SaleId = saleId,
            IDPatient = idPatient,
            SaleDate = saleDate,
            TotalAmount = totalAmount,
            PaymentType = paymentType,
            SaleStatus = saleStatus,
            UserId = userId
        };

        await _db.UpdateSaleAsync(sale).ConfigureAwait(false);
    }

    public async Task UpdateSaleDetailAsync(int saleDetailId, int saleId, int productId, int quantity, decimal unitPrice, decimal subtotal)
    {
        SaleDetails saleDetail = new()
        {
            SaleDetailId = saleDetailId,
            SaleId = saleId,
            ProductId = productId,
            Quantity = quantity,
            UnitPrice = unitPrice,
            Subtotal = subtotal
        };

        await _db.UpdateSaleDetailAsync(saleDetail).ConfigureAwait(false);
    }

    public async Task UpdateSalesPromotionAsync(int salePromotionId, int saleId, int promotionId, decimal discountApplied)
    {
        SalesPromotions salesPromotion = new()
        {
            SalePromotionId = salePromotionId,
            SaleId = saleId,
            PromotionId = promotionId,
            DiscountApplied = discountApplied
        };

        await _db.UpdateSalesPromotionAsync(salesPromotion).ConfigureAwait(false);
    }

    public async Task UpdateSaleStatusAsync(int saleStatusId, string statusName)
    {
        SaleStatuses saleStatus = new()
        {
            SaleStatusId = saleStatusId,
            StatusName = statusName
        };

        await _db.UpdateSaleStatusAsync(saleStatus).ConfigureAwait(false);
    }
}
