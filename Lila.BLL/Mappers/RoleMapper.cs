using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public class RoleMapper
{
    public static Role CastFromDto(RoleDto item)
    {
        return new Role()
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description
        };
    }

    public static RoleDto CastToDto(Role item)
    {
        return new RoleDto()
        {
            Id = item.Id,
            Title = item.Title,
            Description = item.Description
        };
    }

    public static List<Role> CastFromDto(List<RoleDto> items)
    {
        var result = new List<Role>();
        foreach (var item in items)
        {
            result.Add(new Role()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description
            });
        }
        return result;
    }

    public static List<RoleDto> CastToDto(List<Role> items)
    {
        var result = new List<RoleDto>();
        foreach (var item in items)
        {
            result.Add(new RoleDto()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description
            });
        }
        return result;
    }
}