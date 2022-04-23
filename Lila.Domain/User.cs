using Lila.Domain.Interfaces;

namespace Lila.Domain;

public class User : IBaseEntity
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}