using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public static class TransportKindMapper
{
    public static TransportsKind CastFromDto(TransportsKindDto item)
    {
        return new TransportsKind()
        {
            Id = item.Id,
            Description = item.Description,
            Title = item.Title,
            LiftingCapacity = item.LiftingCapacity,
            Volume = item.Volume,
        };
    }

    public static TransportsKindDto CastToDto(TransportsKind item)
    {
        return new TransportsKindDto()
        {
            Id = item.Id,
            Description = item.Description,
            Title = item.Title,
            LiftingCapacity = item.LiftingCapacity,
            Volume = item.Volume,
        };
    }

    public static List<TransportsKind> CastFromDto(List<TransportsKindDto> items)
    {
        var result = new List<TransportsKind>();
        foreach (var item in items)
        {
            result.Add(CastFromDto(item));
        }
        return result;
    }

    public static List<TransportsKindDto> CastToDto(List<TransportsKind> items)
    {
        var result = new List<TransportsKindDto>();
        foreach (var item in items)
        {
            result.Add(CastToDto(item));
        }
        return result;
    }
}