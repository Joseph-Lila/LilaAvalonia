using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public static class OrdersServiceMapper
{
    public static OrdersService CastFromDto(OrdersServiceDto item)
    {
        return new OrdersService()
        {
            Id = item.Id,
            DeparturesAddress = item.DeparturesAddress,
            DestinationsAddress = item.DestinationsAddress,
            BeginCityId = item.BeginCityId,
            EndCityId = item.EndCityId,
            MyOrderId = item.MyOrderId,
            QuantityRadius = item.QuantityRadius,
            QuantityWeight = item.QuantityWeight,
        };
    }

    public static OrdersServiceDto CastToDto(OrdersService item)
    {
        return new OrdersServiceDto()
        {
            Id = item.Id,
            DeparturesAddress = item.DeparturesAddress,
            DestinationsAddress = item.DestinationsAddress,
            BeginCityId = item.BeginCityId,
            EndCityId = item.EndCityId,
            MyOrderId = item.MyOrderId,
            QuantityRadius = item.QuantityRadius,
            QuantityWeight = item.QuantityWeight,
        };
    }

    public static List<OrdersService> CastFromDto(List<OrdersServiceDto> items)
    {
        var result = new List<OrdersService>();
        foreach (var item in items)
        {
            result.Add(CastFromDto(item));
        }
        return result;
    }

    public static List<OrdersServiceDto> CastToDto(List<OrdersService> items)
    {
        var result = new List<OrdersServiceDto>();
        foreach (var item in items)
        {
            result.Add(CastToDto(item));
        }
        return result;
    }
}