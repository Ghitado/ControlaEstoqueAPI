namespace ControlaEstoque.Communication.Responses.Sale;

public record ResponseSaleItemJson(
    Guid Id,
    Guid SaleId,
    Guid ProductId,
    int Quantity,
    decimal UnitPrice
);
