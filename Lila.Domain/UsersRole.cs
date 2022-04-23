using Lila.Domain.Interfaces;

namespace Lila.Domain;

public class UsersRole : IBaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
}