using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public static class CityMapper
{
    public static City CastFromDto(CityDto item)
    {
            return new City()
            {
                Id = item.Id,
                Title = item.Title!
            };
    }

    public static CityDto CastToDto(City item)
    {
            return new CityDto()
            {
                Id = item.Id,
                Title = item.Title
            };
    }

    public static List<City> CastFromDto(List<CityDto> items)
    {
        var result = new List<City>();
        foreach (var item in items)
        {
                result.Add(new City()
                {
                    Id = item.Id,
                    Title = item.Title!
                });
        }
        return result;
    }

    public static List<CityDto> CastToDto(List<City> items)
    {
        var result = new List<CityDto>();
        foreach (var item in items)
        {
                result.Add(new CityDto()
                {
                    Id = item.Id,
                    Title = item.Title
                });
        }
        return result;
    }
}