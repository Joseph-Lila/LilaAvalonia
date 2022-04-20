namespace Lila.Domain;

public class User : BaseEntity
{
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    
    public override string ToString()
    {
        return $"{Id}. ~~~ {Login} ~~~ {Password} ~~~ {Email} ~~~ {PhoneNumber}";
    }
}