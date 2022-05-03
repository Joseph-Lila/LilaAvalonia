using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public static class ServiceMapper
{
    public static Service CastFromDto(ServiceDto item)
    {
        return new Service()
        {
            Id = item.Id,
            Description = item.Description,
            Title = item.Title,
            CostRadius = item.CostRadius,
            CostWeight = item.CostWeight,
        };
    }

    public static ServiceDto CastToDto(Service item)
    {
        return new ServiceDto()
        {
            Id = item.Id,
            Description = item.Description,
            Title = item.Title,
            CostRadius = item.CostRadius,
            CostWeight = item.CostWeight,
        };
    }

    public static List<Service> CastFromDto(List<ServiceDto> items)
    {
        var result = new List<Service>();
        foreach (var item in items)
        {
            result.Add(CastFromDto(item));
        }
        return result;
    }

    public static List<ServiceDto> CastToDto(List<Service> items)
    {
        var result = new List<ServiceDto>();
        foreach (var item in items)
        {
            result.Add(CastToDto(item));
        }
        return result;
    }
}