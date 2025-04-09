namespace ControlaEstoque.Communication.Requests.Product;

public record RequestProductJson(
    string Name,
    decimal Price,
    int Stock
);
