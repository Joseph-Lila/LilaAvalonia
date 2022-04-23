using Lila.BLL.DtoModels;
using Lila.BLL.Services.Interfaces;

namespace Lila.BLL.Services;

public class CustomersCityManager : ICustomersCityManager
{
    public List<CustomersCityDto?> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<CustomersCityDto?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Create(CustomersCityDto? item)
    {
        throw new NotImplementedException();
    }

    public Task Update(CustomersCityDto? item)
    {
        throw new NotImplementedException();
    }
}