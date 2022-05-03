using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public static class UserMapper
{
    public static User CastFromDto(UserDto item)
    {
        return new User()
        {
            Id = item.Id,
            Email = item.Email,
            Login = item.Login,
            Password = item.Password,
            PhoneNumber = item.PhoneNumber,
        };
    }

    public static UserDto CastToDto(User item)
    {
        return new UserDto()
        {
            Id = item.Id,
            Email = item.Email,
            Login = item.Login,
            Password = item.Password,
            PhoneNumber = item.PhoneNumber,
        };
    }

    public static List<User> CastFromDto(List<UserDto> items)
    {
        var result = new List<User>();
        foreach (var item in items)
        {
            result.Add(CastFromDto(item));
        }
        return result;
    }

    public static List<UserDto> CastToDto(List<User> items)
    {
        var result = new List<UserDto>();
        foreach (var item in items)
        {
            result.Add(CastToDto(item));
        }
        return result;
    }
}