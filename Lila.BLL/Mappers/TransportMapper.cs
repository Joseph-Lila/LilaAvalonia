using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public class TransportMapper
{
    public static Transport CastFromDto(TransportDto item)
    {
        return new Transport()
        {
            Id = item.Id,
            FleetId = item.FleetId,
            KindId = item.KindId
        };
    }

    public static TransportDto CastToDto(Transport item)
    {
        return new TransportDto()
        {
            Id = item.Id,
            FleetId = item.FleetId,
            KindId = item.KindId
        };
    }

    public static List<Transport> CastFromDto(List<TransportDto> items)
    {
        var result = new List<Transport>();
        foreach (var item in items)
        {
            result.Add(new Transport()
            {
                Id = item.Id,
                FleetId = item.FleetId,
                KindId = item.KindId
            });
        }
        return result;
    }

    public static List<TransportDto> CastToDto(List<Transport> items)
    {
        var result = new List<TransportDto>();
        foreach (var item in items)
        {
            result.Add(new TransportDto()
            {
                Id = item.Id,
                FleetId = item.FleetId,
                KindId = item.KindId
            });
        }
        return result;
    }
}