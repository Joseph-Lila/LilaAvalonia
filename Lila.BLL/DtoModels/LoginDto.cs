namespace Lila.BLL.DtoModels;

public class LoginDto
{
    public string Login { get; set; } = "";
    public string Password { get; set; } = "";
    public string Email { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public List<string>? Roles { get; set; }
}