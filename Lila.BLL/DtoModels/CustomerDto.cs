using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class CustomerDto : IBaseEntityDto
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