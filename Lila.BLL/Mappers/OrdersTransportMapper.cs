using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public class OrdersTransportMapper
{
    public static OrdersTransport CastFromDto(OrdersTransportDto item)
    {
        return new OrdersTransport()
        {
            Id = item.Id,
            MyOrderId = item.MyOrderId,
            TransportId = item.TransportId
        };
    }

    public static OrdersTransportDto CastToDto(OrdersTransport item)
    {
        return new OrdersTransportDto()
        {
            Id = item.Id,
            MyOrderId = item.MyOrderId,
            TransportId = item.TransportId
        };
    }

    public static List<OrdersTransport> CastFromDto(List<OrdersTransportDto> items)
    {
        var result = new List<OrdersTransport>();
        foreach (var item in items)
        {
            result.Add(new OrdersTransport()
            {
                Id = item.Id,
                MyOrderId = item.MyOrderId,
                TransportId = item.TransportId
            });
        }
        return result;
    }

    public static List<OrdersTransportDto> CastToDto(List<OrdersTransport> items)
    {
        var result = new List<OrdersTransportDto>();
        foreach (var item in items)
        {
            result.Add(new OrdersTransportDto()
            {
                Id = item.Id,
                MyOrderId = item.MyOrderId,
                TransportId = item.TransportId
            });
        }
        return result;
    }
}