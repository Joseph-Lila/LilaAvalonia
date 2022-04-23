using Lila.Domain.Interfaces;

namespace Lila.Domain;

public class Employee : IBaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? PassportData { get; set; }
    public double? Salary { get; set; }
    public string? Requirements { get; set; }
    public string? Duties { get; set; }
    public int StatusId { get; set; }
}