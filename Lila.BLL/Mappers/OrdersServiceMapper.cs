using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public class OrdersServiceMapper
{
    public static OrdersService CastFromDto(OrdersServiceDto item)
    {
        return new OrdersService()
        {
            Id = item.Id,
            BeginCityId = item.BeginCityId,
            DeparturesAddress = item.DeparturesAddress,
            DestinationsAddress = item.DestinationsAddress,
            EndCityId = item.EndCityId,
            MyOrderId = item.MyOrderId,
            QuantityRadius = item.QuantityRadius,
            QuantityWeight = item.QuantityWeight,
            ServiceId = item.ServiceId,
            TotalCost = item.TotalCost
        };
    }

    public static OrdersServiceDto CastToDto(OrdersService item)
    {
        return new OrdersServiceDto()
        {
            Id = item.Id,
            BeginCityId = item.BeginCityId,
            DeparturesAddress = item.DeparturesAddress,
            DestinationsAddress = item.DestinationsAddress,
            EndCityId = item.EndCityId,
            MyOrderId = item.MyOrderId,
            QuantityRadius = item.QuantityRadius,
            QuantityWeight = item.QuantityWeight,
            ServiceId = item.ServiceId,
            TotalCost = item.TotalCost
        };
    }

    public static List<OrdersService> CastFromDto(List<OrdersServiceDto> items)
    {
        var result = new List<OrdersService>();
        foreach (var item in items)
        {
            result.Add(new OrdersService()
            {
                Id = item.Id,
                BeginCityId = item.BeginCityId,
                DeparturesAddress = item.DeparturesAddress,
                DestinationsAddress = item.DestinationsAddress,
                EndCityId = item.EndCityId,
                MyOrderId = item.MyOrderId,
                QuantityRadius = item.QuantityRadius,
                QuantityWeight = item.QuantityWeight,
                ServiceId = item.ServiceId,
                TotalCost = item.TotalCost
            });
        }
        return result;
    }

    public static List<OrdersServiceDto> CastToDto(List<OrdersService> items)
    {
        var result = new List<OrdersServiceDto>();
        foreach (var item in items)
        {
            result.Add(new OrdersServiceDto()
            {
                Id = item.Id,
                BeginCityId = item.BeginCityId,
                DeparturesAddress = item.DeparturesAddress,
                DestinationsAddress = item.DestinationsAddress,
                EndCityId = item.EndCityId,
                MyOrderId = item.MyOrderId,
                QuantityRadius = item.QuantityRadius,
                QuantityWeight = item.QuantityWeight,
                ServiceId = item.ServiceId,
                TotalCost = item.TotalCost
            });
        }
        return result;
    }
}