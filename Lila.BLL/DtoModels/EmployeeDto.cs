using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class EmployeeDto : IBaseEntityDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? PassportData { get; set; }
    public double? Salary { get; set; }
    public string? Requirements { get; set; }
    public string? Duties { get; set; }
    public int StatusId { get; set; }
}