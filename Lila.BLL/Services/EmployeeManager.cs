using Lila.BLL.DtoModels;
using Lila.BLL.Services.Interfaces;

namespace Lila.BLL.Services;

public class EmployeeManager : IEmployeeManager
{
    public List<EmployeeDto?> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDto?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Create(EmployeeDto? item)
    {
        throw new NotImplementedException();
    }

    public Task Update(EmployeeDto? item)
    {
        throw new NotImplementedException();
    }
}