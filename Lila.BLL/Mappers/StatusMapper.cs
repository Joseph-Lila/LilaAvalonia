using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public static class StatusMapper
{
    public static Status CastFromDto(StatusDto item)
    {
        return new Status()
        {
            Id = item.Id,
            Description = item.Description,
            Title = item.Title,
        };
    }

    public static StatusDto CastToDto(Status item)
    {
        return new StatusDto()
        {
            Id = item.Id,
            Description = item.Description,
            Title = item.Title,
        };
    }

    public static List<Status> CastFromDto(List<StatusDto> items)
    {
        var result = new List<Status>();
        foreach (var item in items)
        {
            result.Add(CastFromDto(item));
        }
        return result;
    }

    public static List<StatusDto> CastToDto(List<Status> items)
    {
        var result = new List<StatusDto>();
        foreach (var item in items)
        {
            result.Add(CastToDto(item));
        }
        return result;
    }
}