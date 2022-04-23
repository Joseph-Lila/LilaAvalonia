using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public class StageMapper
{
    public static Stage CastFromDto(StageDto item)
    {
        return new Stage()
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description
        };
    }

    public static StageDto CastToDto(Stage item)
    {
        return new StageDto()
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description
        };
    }

    public static List<Stage> CastFromDto(List<StageDto> items)
    {
        var result = new List<Stage>();
        foreach (var item in items)
        {
            result.Add(new Stage()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description
            });
        }
        return result;
    }

    public static List<StageDto> CastToDto(List<Stage> items)
    {
        var result = new List<StageDto>();
        foreach (var item in items)
        {
            result.Add(new StageDto()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description
            });
        }
        return result;
    }
}