namespace ControlaEstoque.Communication.Requests.Sale;

public record RequestRegisterSaleJson(
    string Buyer,
    bool Paid,
    string Description,
    IEnumerable<RequestSaleItemJson> Items
);
