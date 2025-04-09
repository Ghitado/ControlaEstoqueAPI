namespace ControlaEstoque.Communication.Requests.Product;

public record RequestRegisterProductJson(
    string Name,
    decimal Price,
    int Stock,
    string Image
);
