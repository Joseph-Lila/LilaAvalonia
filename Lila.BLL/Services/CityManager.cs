using Lila.BLL.DtoModels;
using Lila.BLL.Services.Interfaces;

namespace Lila.BLL.Services;

public class CityManager : ICityManager
{
    public List<CityDto?> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<CityDto?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Create(CityDto? item)
    {
        throw new NotImplementedException();
    }

    public Task Update(CityDto? item)
    {
        throw new NotImplementedException();
    }
}