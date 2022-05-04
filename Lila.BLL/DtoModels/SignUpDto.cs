using System.ComponentModel.DataAnnotations;

namespace Lila.BLL.DtoModels;

public class SignUpDto
{
    [Required]
    public string Login { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";
    [Required]
    public string Email { get; set; } = "";
    [Required]
    public string PhoneNumber { get; set; } = "";
    [Required]
    public string Country { get; set; } = "";
    [Required]
    public string Street { get; set; } = "";
    [Required]
    public int HomeNumber { get; set; }
    [Required]
    public int FlatNumber { get; set; }
    [Required]
    public string LastName { get; set; } = "";
    [Required]
    public string Name { get; set; } = "";
    [Required]
    public string MiddleName { get; set; } = "";
    [Required]
    public string CityTitle { get; set; } = "";
}