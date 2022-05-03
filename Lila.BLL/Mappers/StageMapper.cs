using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public static class StageMapper
{
    public static Stage CastFromDto(StageDto item)
    {
        return new Stage()
        {
            Id = item.Id,
            Description = item.Description,
            Title = item.Title,
        };
    }

    public static StageDto CastToDto(Stage item)
    {
        return new StageDto()
        {
            Id = item.Id,
            Description = item.Description,
            Title = item.Title,
        };
    }

    public static List<Stage> CastFromDto(List<StageDto> items)
    {
        var result = new List<Stage>();
        foreach (var item in items)
        {
            result.Add(CastFromDto(item));
        }
        return result;
    }

    public static List<StageDto> CastToDto(List<Stage> items)
    {
        var result = new List<StageDto>();
        foreach (var item in items)
        {
            result.Add(CastToDto(item));
        }
        return result;
    }
}