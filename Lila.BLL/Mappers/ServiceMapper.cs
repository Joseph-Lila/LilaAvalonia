using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public class ServiceMapper
{
    public static Service CastFromDto(ServiceDto item)
    {
        return new Service()
        {
            Id = item.Id,
            Title = item.Title,
            CostRadius = item.CostRadius,
            CostWeight = item.CostWeight,
            Description = item.Description
        };
    }

    public static ServiceDto CastToDto(Service item)
    {
        return new ServiceDto()
        {
            Id = item.Id,
            Title = item.Title,
            CostRadius = item.CostRadius,
            CostWeight = item.CostWeight,
            Description = item.Description
        };
    }

    public static List<Service> CastFromDto(List<ServiceDto> items)
    {
        var result = new List<Service>();
        foreach (var item in items)
        {
            result.Add(new Service()
            {
                Id = item.Id,
                Title = item.Title,
                CostRadius = item.CostRadius,
                CostWeight = item.CostWeight,
                Description = item.Description
            });
        }
        return result;
    }

    public static List<ServiceDto> CastToDto(List<Service> items)
    {
        var result = new List<ServiceDto>();
        foreach (var item in items)
        {
            result.Add(new ServiceDto()
            {
                Id = item.Id,
                Title = item.Title,
                CostRadius = item.CostRadius,
                CostWeight = item.CostWeight,
                Description = item.Description
            });
        }
        return result;
    }
}