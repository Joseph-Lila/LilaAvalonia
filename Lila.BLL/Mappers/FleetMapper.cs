using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public static class FleetMapper
{
    public static Fleet CastFromDto(FleetDto item)
    {
        return new Fleet()
        {
            Id = item.Id,
            Address = item.Address,
            CityId = item.CityId,
            Description = item.Description,
            Square = item.Square,
            StarsQuantity = item.StarsQuantity,
            Title = item.Title,
        };
    }

    public static FleetDto CastToDto(Fleet item)
    {
        return new FleetDto()
        {
            Id = item.Id,
            Address = item.Address,
            CityId = item.CityId,
            Description = item.Description,
            Square = item.Square,
            StarsQuantity = item.StarsQuantity,
            Title = item.Title,
        };
    }

    public static List<Fleet> CastFromDto(List<FleetDto> items)
    {
        var result = new List<Fleet>();
        foreach (var item in items)
        {
            result.Add(CastFromDto(item));
        }
        return result;
    }

    public static List<FleetDto> CastToDto(List<Fleet> items)
    {
        var result = new List<FleetDto>();
        foreach (var item in items)
        {
            result.Add(CastToDto(item));
        }
        return result;
    }
}