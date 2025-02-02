namespace ControlaEstoque.Application.Interfaces;
public interface IMapper<TEntity, TDTO>
{
    TEntity MapToEntity(TDTO dto);
    TDTO MapToDTO(TEntity entity);
    IEnumerable<TDTO> MapToDTOList(IEnumerable<TEntity> entity);
}

