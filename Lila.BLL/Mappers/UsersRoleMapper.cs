using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public class UsersRoleMapper
{
    public static UsersRole CastFromDto(UsersRoleDto item)
    {
        return new UsersRole()
        {
            Id = item.Id,
            RoleId = item.RoleId,
            UserId = item.UserId
        };
    }

    public static UsersRoleDto CastToDto(UsersRole item)
    {
        return new UsersRoleDto()
        {
            Id = item.Id,
            RoleId = item.RoleId,
            UserId = item.UserId
        };
    }

    public static List<UsersRole> CastFromDto(List<UsersRoleDto> items)
    {
        var result = new List<UsersRole>();
        foreach (var item in items)
        {
            result.Add(new UsersRole()
            {
                Id = item.Id,
                RoleId = item.RoleId,
                UserId = item.UserId
            });
        }
        return result;
    }

    public static List<UsersRoleDto> CastToDto(List<UsersRole> items)
    {
        var result = new List<UsersRoleDto>();
        foreach (var item in items)
        {
            result.Add(new UsersRoleDto()
            {
                Id = item.Id,
                RoleId = item.RoleId,
                UserId = item.UserId
            });
        }
        return result;
    }
}