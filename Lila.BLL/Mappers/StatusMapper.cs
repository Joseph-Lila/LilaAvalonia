using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public class StatusMapper
{
    public static Status CastFromDto(StatusDto item)
    {
        return new Status()
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description
        };
    }

    public static StatusDto CastToDto(Status item)
    {
        return new StatusDto()
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description
        };
    }

    public static List<Status> CastFromDto(List<StatusDto> items)
    {
        var result = new List<Status>();
        foreach (var item in items)
        {
            result.Add(new Status()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description
            });
        }
        return result;
    }

    public static List<StatusDto> CastToDto(List<Status> items)
    {
        var result = new List<StatusDto>();
        foreach (var item in items)
        {
            result.Add(new StatusDto()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description
            });
        }
        return result;
    }
}