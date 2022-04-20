namespace Lila.Domain;

public class Employee : BaseEntity
{
    public int UserId { get; set; }
    public string? PassportData { get; set; }
    public double? Salary { get; set; }
    public string? Requirements { get; set; }
    public string? Duties { get; set; }
    public int StatusId { get; set; }
}