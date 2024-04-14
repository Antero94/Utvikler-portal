namespace Utvikler_portal.JobbModul.Mappers.Interface;

public interface IMapper<TModel, TDto>
{
    TDto MapToDTO(TModel model);

    TModel MapToModel(TDto dto);
}
