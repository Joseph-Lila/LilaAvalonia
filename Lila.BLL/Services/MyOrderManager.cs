using Lila.BLL.DtoModels;
using Lila.BLL.Services.Interfaces;

namespace Lila.BLL.Services;

public class MyOrderManager
{
    public List<MyOrderDto?> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<MyOrderDto?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Task> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Create(MyOrderDto? item)
    {
        throw new NotImplementedException();
    }

    public Task Update(MyOrderDto? item)
    {
        throw new NotImplementedException();
    }
}