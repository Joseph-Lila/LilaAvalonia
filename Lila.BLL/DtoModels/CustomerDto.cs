namespace Lila.BLL.DtoModels;

public class CustomerDto
{
    public int CustomerId { get; set; }
    public string Login { get; set; } = "";
    public string Password { get; set; } = "";
    public string Email { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public int CityId { get; set; }
    public string CityTitle { get; set; } = "";
    public string Country { get; set; } = "";
    public string Street { get; set; } = "";
    public int HomeNumber { get; set; }
    public int FlatNumber { get; set; }
    public string LastName { get; set; } = "";
    public string Name { get; set; } = "";
    public string MiddleName { get; set; } = "";
}