using Microsoft.AspNetCore.Http;

namespace ControlaEstoque.Communication.Requests.Product;

public record RequestRegisterProductFormData(
    string Name,
    decimal Price,
    int Stock,
    IFormFile? Image
) : RequestProductJson(Name, Price, Stock);