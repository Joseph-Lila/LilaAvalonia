using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class UsersRoleDto : IBaseEntityDto
{
    public int Id { get; set; }
    public int UserId { get; set; } // FK
    public UserDto? User { get; set; } // nav. property
    public int RoleId { get; set; } // FK
    public RoleDto? Role { get; set; } // nav. property
}