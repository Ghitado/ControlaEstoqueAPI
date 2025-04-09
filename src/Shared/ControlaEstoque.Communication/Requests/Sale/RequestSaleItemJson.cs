namespace ControlaEstoque.Communication.Requests.Sale;

public record RequestSaleItemJson(
    Guid ProductId,
    int Quantity
);
