using Lila.BLL.DtoModels;
using Lila.BLL.Services.Interfaces;

namespace Lila.BLL.Services;

public class OrdersServiceManager : IOrdersServiceManager
{
    public List<ServiceDto?> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceDto?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Create(ServiceDto? item)
    {
        throw new NotImplementedException();
    }

    public Task Update(ServiceDto? item)
    {
        throw new NotImplementedException();
    }
}