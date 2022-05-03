using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public static class RoleMapper
{
    public static Role CastFromDto(RoleDto item)
    {
        return new Role()
        {
            Id = item.Id,
            Description = item.Description,
            Title = item.Title,
        };
    }

    public static RoleDto CastToDto(Role item)
    {
        return new RoleDto()
        {
            Id = item.Id,
            Description = item.Description,
            Title = item.Title,
        };
    }

    public static List<Role> CastFromDto(List<RoleDto> items)
    {
        var result = new List<Role>();
        foreach (var item in items)
        {
            result.Add(CastFromDto(item));
        }
        return result;
    }

    public static List<RoleDto> CastToDto(List<Role> items)
    {
        var result = new List<RoleDto>();
        foreach (var item in items)
        {
            result.Add(CastToDto(item));
        }
        return result;
    }
}