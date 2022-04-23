using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public class FleetMapper
{
    public static Fleet CastFromDto(FleetDto item)
    {
        return new Fleet()
        {
            Address = item.Address,
            Description = item.Description,
            Id = item.Id,
            Square = item.Square,
            StarsQuantity = item.StarsQuantity,
            Title = item.Title
        };
    }

    public static FleetDto CastToDto(Fleet item)
    {
        return new FleetDto()
        {
            Address = item.Address,
            Description = item.Description,
            Id = item.Id,
            Square = item.Square,
            StarsQuantity = item.StarsQuantity,
            Title = item.Title
        };
    }

    public static List<Fleet> CastFromDto(List<FleetDto> items)
    {
        var result = new List<Fleet>();
        foreach (var item in items)
        {
            result.Add(new Fleet()
            {
                Id = item.Id,
                Title = item.Title
            });
        }
        return result;
    }

    public static List<FleetDto> CastToDto(List<Fleet> items)
    {
        var result = new List<FleetDto>();
        foreach (var item in items)
        {
            result.Add(new FleetDto()
            {
                Id = item.Id,
                Title = item.Title
            });
        }
        return result;
    }
}