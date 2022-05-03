using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lila.Domain.Interfaces;

namespace Lila.Domain;

[Table("Employees")]
public class Employee : IBaseEntity
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; } // FK
    public User? User { get; set; } // nav. property
    public string PassportData { get; set; } = "";
    public double Salary { get; set; }
    public string Requirements { get; set; } = "";
    public string Duties { get; set; } = "";
    public int StatusId { get; set; } // FK
    public Status? Status { get; set; } // nav. property
}