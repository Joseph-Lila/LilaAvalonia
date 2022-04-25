using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public static class CityMapper
{
    public static async Task<City?> CastFromDto(CityDto? item)
    {
        if (item != null)
            return new City()
            {
                Id = item.Id,
                Title = item.Title
            };
        return null;
    }

    public static async Task<CityDto?> CastToDto(City? item)
    {
        if (item != null)
            return new CityDto()
            {
                Id = item.Id,
                Title = item.Title
            };
        return null;
    }

    public static List<City?> CastFromDto(List<CityDto?> items)
    {
        var result = new List<City?>();
        foreach (var item in items)
        {
            if (item != null)
                result.Add(new City()
                {
                    Id = item.Id,
                    Title = item.Title
                });
        }
        return result;
    }

    public static List<CityDto?> CastToDto(List<City> items)
    {
        var result = new List<CityDto?>();
        foreach (var item in items)
        {
            if (item != null)
                result.Add(new CityDto()
                {
                    Id = item.Id,
                    Title = item.Title
                });
        }
        return result;
    }
}