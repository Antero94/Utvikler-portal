using System;

namespace Utvikler_portal.JobSeekerModul.Maps.Interfaces;

public interface IMaps<TModel, TDTO>
{
    TDTO MapToDTO(TModel model);

    TModel MapToModel(TDTO dto);
}