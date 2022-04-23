using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class UsersRoleDto : IBaseEntityDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
}