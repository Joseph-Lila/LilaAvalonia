using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("Users")]
public class User : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public string Login { get; set; } = "";
    public string Password { get; set; } = "";
    public string Email { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    // ---
    public List<UsersRole> UsersRoles { get; set; } = new();
    public List<Customer> Customers { get; set; } = new();
    public List<Employee> Employees { get; set; } = new();
}