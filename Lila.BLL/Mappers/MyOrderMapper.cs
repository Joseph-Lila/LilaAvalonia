using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public class MyOrderMapper
{
    public static MyOrder CastFromDto(MyOrderDto item)
    {
        return new MyOrder()
        {
            Id = item.Id,
            Commissions = item.Commissions,
            CourierId = item.CourierId,
            CustomerId = item.CustomerId,
            Executions = item.Executions,
            OperatorId = item.OperatorId,
            StageId = item.StageId,
            StatusId = item.StatusId
        };
    }

    public static MyOrderDto CastToDto(MyOrder item)
    {
        return new MyOrderDto()
        {
            Id = item.Id,
            Commissions = item.Commissions,
            CourierId = item.CourierId,
            CustomerId = item.CustomerId,
            Executions = item.Executions,
            OperatorId = item.OperatorId,
            StageId = item.StageId,
            StatusId = item.StatusId
        };
    }

    public static List<MyOrder> CastFromDto(List<MyOrderDto> items)
    {
        var result = new List<MyOrder>();
        foreach (var item in items)
        {
            result.Add(new MyOrder()
            {
                Id = item.Id,
                Commissions = item.Commissions,
                CourierId = item.CourierId,
                CustomerId = item.CustomerId,
                Executions = item.Executions,
                OperatorId = item.OperatorId,
                StageId = item.StageId,
                StatusId = item.StatusId
            });
        }
        return result;
    }

    public static List<MyOrderDto> CastToDto(List<MyOrder> items)
    {
        var result = new List<MyOrderDto>();
        foreach (var item in items)
        {
            result.Add(new MyOrderDto()
            {
                Id = item.Id,
                Commissions = item.Commissions,
                CourierId = item.CourierId,
                CustomerId = item.CustomerId,
                Executions = item.Executions,
                OperatorId = item.OperatorId,
                StageId = item.StageId,
                StatusId = item.StatusId
            });
        }
        return result;
    }
}