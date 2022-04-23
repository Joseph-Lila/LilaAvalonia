using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class UserDto : IBaseEntityDto
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}