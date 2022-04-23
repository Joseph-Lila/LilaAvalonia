using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public class TransportKindMapper
{
    public static TransportsKind CastFromDto(TransportsKindDto item)
    {
        return new TransportsKind()
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            LiftingCapacity = item.LiftingCapacity,
            Volume = item.Volume
        };
    }

    public static TransportsKindDto CastToDto(TransportsKind item)
    {
        return new TransportsKindDto()
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description,
            LiftingCapacity = item.LiftingCapacity,
            Volume = item.Volume
        };
    }

    public static List<TransportsKind> CastFromDto(List<TransportsKindDto> items)
    {
        var result = new List<TransportsKind>();
        foreach (var item in items)
        {
            result.Add(new TransportsKind()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                LiftingCapacity = item.LiftingCapacity,
                Volume = item.Volume
            });
        }
        return result;
    }

    public static List<TransportsKindDto> CastToDto(List<TransportsKind> items)
    {
        var result = new List<TransportsKindDto>();
        foreach (var item in items)
        {
            result.Add(new TransportsKindDto()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                LiftingCapacity = item.LiftingCapacity,
                Volume = item.Volume
            });
        }
        return result;
    }
}