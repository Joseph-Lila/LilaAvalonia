using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("UsersRoles")]
public class UsersRole : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; } // FK
    public User? User { get; set; } // nav. property
    public int RoleId { get; set; } // FK
    public Role? Role { get; set; } // nav. property
}