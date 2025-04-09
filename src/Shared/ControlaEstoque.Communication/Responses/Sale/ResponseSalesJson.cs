namespace ControlaEstoque.Communication.Responses.Sale;

public record ResponseSalesJson(
    IEnumerable<ResponseSaleJson> Sales
);
