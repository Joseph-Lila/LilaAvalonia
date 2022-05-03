using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public static class CustomersCityMapper
{
    public static CustomersCity CastFromDto(CustomersCityDto item)
    {
        return new CustomersCity()
        {
            Id = item.Id,
            CityId = item.CityId,
            CustomerId = item.CustomerId,
        };
    }

    public static CustomersCityDto CastToDto(CustomersCity item)
    {
        return new CustomersCityDto()
        {
            Id = item.Id,
            CityId = item.CityId,
            CustomerId = item.CustomerId,
        };
    }

    public static List<CustomersCity> CastFromDto(List<CustomersCityDto> items)
    {
        var result = new List<CustomersCity>();
        foreach (var item in items)
        {
            result.Add(CastFromDto(item));
        }
        return result;
    }

    public static List<CustomersCityDto> CastToDto(List<CustomersCity> items)
    {
        var result = new List<CustomersCityDto>();
        foreach (var item in items)
        {
            result.Add(CastToDto(item));
        }
        return result;
    }
}