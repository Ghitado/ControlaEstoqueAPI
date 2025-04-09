namespace ControlaEstoque.Communication.Responses.Sale;

public record ResponseSaleJson(
    Guid Id,
    string Buyer,
    bool Paid,
    string Description,
    DateTime DateSale,
    decimal TotalValue,
    IEnumerable<ResponseSaleItemJson> Items
);
