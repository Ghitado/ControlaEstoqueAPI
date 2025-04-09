namespace ControlaEstoque.Communication.Responses.Product;

public record ResponseProductJson(
    Guid Id,
    string Name,
    decimal Price,
    int Stock,
    string? ImageUrl
);
