namespace ControlaEstoque.Communication.Requests.Sale;

public record RequestSaleJson(
    string Buyer,
    bool Paid,
    string Description,
    IEnumerable<RequestSaleItemJson> Items
);
