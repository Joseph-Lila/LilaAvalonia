using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public static class CustomerMapper
{
    public static Customer CastFromDto(CustomerDto item)
    {
        return new Customer()
        {
            Id = item.Id,
            Country = item.Country,
            FlatNumber = item.FlatNumber,
            HomeNumber = item.HomeNumber,
            LastName = item.LastName,
            MiddleName = item.MiddleName,
            Name = item.Name,
            Street = item.Street,
            UserId = item.UserId
        };
    }

    public static CustomerDto CastToDto(Customer item)
    {
        return new CustomerDto()
        {
            Id = item.Id,
            Country = item.Country,
            FlatNumber = item.FlatNumber,
            HomeNumber = item.HomeNumber,
            LastName = item.LastName,
            MiddleName = item.MiddleName,
            Name = item.Name,
            Street = item.Street,
            UserId = item.UserId
        };
    }

    public static List<Customer> CastFromDto(List<CustomerDto> items)
    {
        var result = new List<Customer>();
        foreach (var item in items)
        {
            result.Add(CastFromDto(item));
        }
        return result;
    }

    public static List<CustomerDto> CastToDto(List<Customer> items)
    {
        var result = new List<CustomerDto>();
        foreach (var item in items)
        {
            result.Add(CastToDto(item));
        }
        return result;
    }
}