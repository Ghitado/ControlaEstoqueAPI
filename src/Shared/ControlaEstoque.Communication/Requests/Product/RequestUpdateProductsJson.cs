namespace ControlaEstoque.Communication.Requests.Product;

public record RequestUpdateProductsJson(
    IDictionary<Guid, int> Products
);
