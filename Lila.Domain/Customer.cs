using Lila.Domain.Interfaces;

namespace Lila.Domain;

public class Customer : IBaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? Country { get; set; }
    public string? Street { get; set; }
    public int HomeNumber { get; set; }
    public int FlatNumber { get; set; }
    public string? LastName { get; set; }
    public string? Name { get; set; }
    public string? MiddleName { get; set; }
}