using ControlaEstoque.API.Models.DTOs;

namespace ControlaEstoque.API.Services.Sale;

public interface ISaleService
{
    Task<SaleDTO?> GetById(Guid id);
    Task<IEnumerable<SaleDTO>> GetAll();
    Task Add(SaleInputDTO saleDto);
    Task Update(Guid id, SaleInputDTO saleDto);
    Task Delete(Guid id);
}
