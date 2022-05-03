using Lila.BLL.DtoModels.Interfaces;

namespace Lila.BLL.DtoModels;

public class EmployeeDto : IBaseEntityDto
{
    public int Id { get; set; }
    public int UserId { get; set; } // FK
    public UserDto? User { get; set; } // nav. property
    public string PassportData { get; set; } = "";
    public double Salary { get; set; }
    public string Requirements { get; set; } = "";
    public string Duties { get; set; } = "";
    public int StatusId { get; set; } // FK
    public StatusDto? Status { get; set; } // nav. property
}