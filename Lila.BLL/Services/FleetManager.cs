using Lila.BLL.DtoModels;
using Lila.BLL.Services.Interfaces;

namespace Lila.BLL.Services;

public class FleetManager : IFleetManager
{
    public List<FleetDto?> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<FleetDto?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Create(FleetDto? item)
    {
        throw new NotImplementedException();
    }

    public Task Update(FleetDto? item)
    {
        throw new NotImplementedException();
    }
}