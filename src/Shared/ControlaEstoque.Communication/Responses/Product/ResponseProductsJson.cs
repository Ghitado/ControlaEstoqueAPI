namespace ControlaEstoque.Communication.Responses.Product;

public record ResponseProductsJson(
    IEnumerable<ResponseProductJson> Products
);
