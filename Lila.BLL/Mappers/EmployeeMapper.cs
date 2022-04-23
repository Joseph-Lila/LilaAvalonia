using Lila.BLL.DtoModels;
using Lila.Domain;

namespace Lila.BLL.Mappers;

public class EmployeeMapper
{
    public static Employee CastFromDto(EmployeeDto item)
    {
        return new Employee()
        {
            Id = item.Id,
            Duties = item.Duties,
            PassportData = item.PassportData,
            Requirements = item.Requirements,
            Salary = item.Salary,
            StatusId = item.StatusId,
            UserId = item.UserId
        };
    }

    public static EmployeeDto CastToDto(Employee item)
    {
        return new EmployeeDto()
        {
            Id = item.Id,
            Duties = item.Duties,
            PassportData = item.PassportData,
            Requirements = item.Requirements,
            Salary = item.Salary,
            StatusId = item.StatusId,
            UserId = item.UserId
        };
    }

    public static List<Employee> CastFromDto(List<EmployeeDto> items)
    {
        var result = new List<Employee>();
        foreach (var item in items)
        {
            result.Add(new Employee()
            {
                Id = item.Id,
                Duties = item.Duties,
                PassportData = item.PassportData,
                Requirements = item.Requirements,
                Salary = item.Salary,
                StatusId = item.StatusId,
                UserId = item.UserId
            });
        }
        return result;
    }

    public static List<EmployeeDto> CastToDto(List<Employee> items)
    {
        var result = new List<EmployeeDto>();
        foreach (var item in items)
        {
            result.Add(new EmployeeDto()
            {
                Id = item.Id,
                Duties = item.Duties,
                PassportData = item.PassportData,
                Requirements = item.Requirements,
                Salary = item.Salary,
                StatusId = item.StatusId,
                UserId = item.UserId
            });
        }
        return result;
    }
}