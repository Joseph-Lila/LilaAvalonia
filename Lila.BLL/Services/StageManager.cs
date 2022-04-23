using Lila.BLL.DtoModels;
using Lila.BLL.Services.Interfaces;

namespace Lila.BLL.Services;

public class StageManager : IStageManager
{
    public List<StageDto?> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<StageDto?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Create(StageDto? item)
    {
        throw new NotImplementedException();
    }

    public Task Update(StageDto? item)
    {
        throw new NotImplementedException();
    }
}