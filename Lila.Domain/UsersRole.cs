using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("UsersRoles")]
public class UsersRole : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    // ---
    public int UserId { get; set; }
    public User? User { get; set; }
    // ---
    public int RoleId { get; set; }
    public Role? Role { get; set; }
}