using Lila.BLL.DtoModels;
using Lila.BLL.Services.Interfaces;

namespace Lila.BLL.Services;

public class TransportsKindManager : ITransportKindManager
{
    public List<TransportsKindDto?> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<TransportsKindDto?> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Create(TransportsKindDto? item)
    {
        throw new NotImplementedException();
    }

    public Task Update(TransportsKindDto? item)
    {
        throw new NotImplementedException();
    }
}